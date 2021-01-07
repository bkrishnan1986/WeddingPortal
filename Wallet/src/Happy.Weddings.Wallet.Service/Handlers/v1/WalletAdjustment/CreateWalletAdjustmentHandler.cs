#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | CreateWalletAdjustmentHandler --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using Happy.Weddings.Wallet.Core.Entity;
using Happy.Weddings.Wallet.Core.Repository;
using Happy.Weddings.Wallet.Service.Commands.v1.WalletAdjustment;
using MediatR;
using Serilog;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Wallet.Service.Handlers.v1.WalletAdjustment
{
    /// <summary>
    /// Handler for creating a Wallet Adjustment
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Wallet.Service.Commands.v1.WalletAdjustment.CreateWalletAdjustmentCommand, Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class CreateWalletAdjustmentHandler : IRequestHandler<CreateWalletAdjustmentCommand, APIResponse>
    {
        /// <summary>
        /// The repository
        /// </summary>
        private IRepositoryWrapper repository;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateWalletAdjustmentHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public CreateWalletAdjustmentHandler(
            IRepositoryWrapper repository,
            IMapper mapper,
            ILogger logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<APIResponse> Handle(CreateWalletAdjustmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var walletAdjustmentRequest = mapper.Map<Walletadjustment>(request.Request);

                Core.DTO.Requests.Wallet.WalletsParameter WP = new Core.DTO.Requests.Wallet.WalletsParameter();
                WP.VendorId = walletAdjustmentRequest.VendorId;
                var walletResponse = await repository.Wallets.GetAllWallets(WP);

                if (walletResponse != null && walletResponse.Count > 0)
                {
                    decimal Balance = 0;

                    var AdjustmentType = await repository.MultiDetails.GetMultiDetailByMultiDetailId(walletAdjustmentRequest.AdjustmentType);

                    Core.Entity.Transactions transaction = new Core.Entity.Transactions();
                    transaction.WalletId = walletResponse[0].Id;
                    transaction.TransactionDate = DateTime.UtcNow;
                    transaction.Amount = walletAdjustmentRequest.AdjustmentAmount;

                    var StatusData = await repository.MultiDetails.GetMultiDetailsByCode("PAYMENT TYPE");

                    if (AdjustmentType.Value.Trim().ToUpper() == "ADD WALLET")
                    {
                        Balance = walletResponse[0].Balance + walletAdjustmentRequest.AdjustmentAmount;
                        transaction.Particulars = "Wallet credited by adjustment";

                        if (StatusData != null && StatusData.Count > 0)
                        {
                            foreach (var item in StatusData)
                            {
                                if (item.Value.ToUpper() == "CREDIT")
                                {
                                    transaction.TransactionType = item.Id;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        Balance = walletResponse[0].Balance - walletAdjustmentRequest.AdjustmentAmount;
                        transaction.Particulars = "Wallet debited by adjustment";

                        if (StatusData != null && StatusData.Count > 0)
                        {
                            foreach (var item in StatusData)
                            {
                                if (item.Value.ToUpper() == "DEBIT")
                                {
                                    transaction.TransactionType = item.Id;
                                    break;
                                }
                            }
                        }
                    }

                    transaction.WalletBalance = Balance;
                    transaction.CreatedBy = walletAdjustmentRequest.CreatedBy;
                    transaction.CreatedAt = DateTime.UtcNow;
                    repository.Transactions.CreateTransactions(transaction);

                    walletResponse[0].Balance = Balance;
                    repository.Wallets.UpdateWallet(walletResponse[0]);

                }

                repository.WalletAdjustment.CreateWalletAdjustment(walletAdjustmentRequest);

                await repository.SaveAsync();

                return new APIResponse(walletAdjustmentRequest, HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateWalletAdjustmentHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
