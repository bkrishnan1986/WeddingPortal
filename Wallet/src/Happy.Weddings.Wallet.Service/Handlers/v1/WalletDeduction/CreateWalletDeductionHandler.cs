#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | CreateWalletDeductionHandler --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using Happy.Weddings.Wallet.Core.Entity;
using Happy.Weddings.Wallet.Core.Repository;
using Happy.Weddings.Wallet.Service.Commands.v1.WalletDeduction;
using MediatR;
using Serilog;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Happy.Weddings.Wallet.Core.DTO.Requests.Wallet;
using System.Linq;

namespace Happy.Weddings.Wallet.Service.Handlers.v1.WalletDeduction
{
    /// <summary>
    /// Handler for creating a WalletDeduction
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Wallet.Service.Commands.v1.WalletDeduction.CreateWalletDeductionCommand, Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class CreateWalletDeductionHandler : IRequestHandler<CreateWalletDeductionCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="CreateWalletDeductionHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public CreateWalletDeductionHandler(
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
        public async Task<APIResponse> Handle(CreateWalletDeductionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var walletDeductionRequest = mapper.Map<Walletdeduction>(request.Request);

                var Category = await repository.MultiDetails.GetMultiDetailsByCode("CATEGORY");

                if (Category != null && Category.Count > 0)
                {
                    foreach (var item in Category)
                    {
                        if (item.Value.Trim().ToUpper() == request.Request.CategoryValue.Trim().ToUpper())
                        {
                            walletDeductionRequest.CategoryId = item.Id;
                            break;
                        }
                    }
                }

                bool IsCPL = false, IsCommission = false;

                if (walletDeductionRequest.DeductedAmount == 0 && walletDeductionRequest.CategoryId > 0)
                {
                    Core.DTO.Requests.WalletRule.WalletRuleParameter Parameter = new Core.DTO.Requests.WalletRule.WalletRuleParameter();
                    Parameter.Value = walletDeductionRequest.CategoryId;
                    Parameter.IsForServiceCategory = true;

                    var rule = await repository.WalletRule.GetAllWalletRule(Parameter);

                    if (rule != null && rule.Count > 0)
                    {
                        if (rule[0].Cplamount > 0)
                        {
                            walletDeductionRequest.DeductedAmount = (decimal)rule[0].Cplamount;
                            IsCPL = true;
                        }
                        else if (rule[0].CommissionAmount > 0)
                        {
                            walletDeductionRequest.DeductedAmount = (decimal)rule[0].CommissionAmount;
                            IsCommission = true;
                        }
                    }
                }
                else
                {
                    if (request.Request.LeadMode.Trim().ToUpper() == "CPL") IsCPL = true;
                    else if (request.Request.LeadMode.Trim().ToUpper() == "COMMISSION") IsCommission = true;
                    //else if(request.Request.LeadMode.Trim().ToUpper() == "BOTH")
                    //{

                    //}
                }

                WalletsParameter WP = new WalletsParameter();
                WP.VendorId = walletDeductionRequest.VendorId;
                var walletResponse = await repository.Wallets.GetAllWallets(WP);

                if (walletResponse != null && walletResponse.Count > 0)
                {
                    var Status = await repository.MultiDetails.GetMultiDetailByMultiDetailId(walletResponse[0].Status);

                    if (Status != null && Status.Value.Trim().ToUpper() != "DEDUCT") return new APIResponse(walletDeductionRequest, HttpStatusCode.NoContent);

                    decimal deductedBalance = ((walletResponse[0].Balance) - (walletDeductionRequest.DeductedAmount));

                    walletResponse[0].Balance = deductedBalance;
                    repository.Wallets.UpdateWallet(walletResponse[0]);

                    walletDeductionRequest.WalletBalance = deductedBalance;
                    repository.WalletDeduction.CreateWalletDeduction(walletDeductionRequest);

                    Core.Entity.Transactions transaction = new Core.Entity.Transactions();

                    transaction.WalletId = walletResponse[0].Id;

                    if (IsCPL) transaction.Particulars = request.Request.LeadIdNumber + "-CPL deducted";
                    else if (IsCommission) transaction.Particulars = request.Request.LeadIdNumber + "Commission deducted";
                    else transaction.Particulars = "Wallet deducted";

                    transaction.TransactionDate = DateTime.UtcNow;

                    var StatusData = await repository.MultiDetails.GetMultiDetailsByCode("PAYMENT TYPE");

                    if (StatusData != null && StatusData.Count > 0)
                    {
                        foreach (var item in StatusData)
                        {
                            if (item.Value.Trim().ToUpper() == "DEBIT")
                            {
                                transaction.TransactionType = item.Id;
                                break;
                            }
                        }
                    }

                    transaction.Amount = walletDeductionRequest.DeductedAmount;
                    transaction.WalletBalance = deductedBalance;
                    transaction.CreatedBy = walletDeductionRequest.CreatedBy;
                    transaction.CreatedAt = DateTime.UtcNow;

                    repository.Transactions.CreateTransactions(transaction);

                    await repository.SaveAsync();

                }

                return new APIResponse(walletDeductionRequest, HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateWalletDeductionHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
