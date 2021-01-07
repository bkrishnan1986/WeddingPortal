#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS  | Created and implemented. 
//              |                      | UpdatePaymentBookHandler --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using Happy.Weddings.Wallet.Core.Entity;
using Happy.Weddings.Wallet.Core.Repository;
using Happy.Weddings.Wallet.Service.Commands.v1.PaymentBook;
using MediatR;
using Serilog;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Wallet.Service.Handlers.v1.PaymentBook
{
    /// <summary>
    /// Handler for updating a PaymentBook
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Wallet.Service.Commands.v1.PaymentBook.UpdatePaymentBookCommand, Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class UpdatePaymentBookHandler : IRequestHandler<UpdatePaymentBookCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="UpdatePaymentBookHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public UpdatePaymentBookHandler(
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
        public async Task<APIResponse> Handle(UpdatePaymentBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var paymentBook = await repository.PaymentBook.GetPaymentBookById(request.PaymentBookId);

                if (paymentBook == null) return new APIResponse(HttpStatusCode.NotFound);

                request.Request.PaymentRefNumber = paymentBook.PaymentRefNumber;

                var PaymentStatus = await repository.MultiDetails.GetMultiDetailByMultiDetailId(paymentBook.PaymentStatus);

                var PaymentBookRequest = mapper.Map(request.Request, paymentBook);

                if (PaymentStatus.Value.Trim().ToUpper() != "PAID")
                {
                    var CurrentPaymentStatus = await repository.MultiDetails.GetMultiDetailByMultiDetailId(PaymentBookRequest.PaymentStatus);
                    var PaymentType = await repository.MultiDetails.GetMultiDetailByMultiDetailId(PaymentBookRequest.PaymentType);

                    if (CurrentPaymentStatus.Value.Trim().ToUpper() == "PAID" && PaymentType.Value.Trim().ToUpper() == "CREDIT")
                    {
                        Core.DTO.Requests.Wallet.WalletsParameter WP = new Core.DTO.Requests.Wallet.WalletsParameter();
                        WP.VendorId = PaymentBookRequest.VendorId;
                        var walletResponse = await repository.Wallets.GetAllWallets(WP);

                        if (walletResponse != null && walletResponse.Count > 0)
                        {
                            walletResponse[0].Balance += PaymentBookRequest.PaymentAmount;

                            repository.Wallets.UpdateWallet(walletResponse[0]);

                            var PackageType = await repository.MultiDetails.GetMultiDetailByMultiDetailId((int)PaymentBookRequest.PackageType);

                            Core.Entity.Transactions transaction = new Core.Entity.Transactions();
                            transaction.WalletId = walletResponse[0].Id;
                            transaction.ReferenceNo = PaymentBookRequest.PaymentRefNumber;

                            if (PackageType.Value.Trim().ToUpper() == "SUBSCRIPTION") transaction.Particulars = request.Request.PackageName + "-taken (" + PackageType.Value + ")";
                            else if (PackageType.Value.Trim().ToUpper() == "TOP-UP") transaction.Particulars = request.Request.PackageName + "-done (" + PackageType.Value + ")";
                            else transaction.Particulars = PackageType.Value;

                            transaction.TransactionDate = DateTime.UtcNow;

                            var TransactionType = await repository.MultiDetails.GetMultiDetailsByCode("PAYMENT TYPE");

                            if (TransactionType != null && TransactionType.Count > 0)
                            {
                                foreach (var type in TransactionType)
                                {
                                    if (type.Value.ToUpper() == "CREDIT")
                                    {
                                        transaction.TransactionType = type.Id;
                                        break;
                                    }
                                }
                            }

                            transaction.Amount = PaymentBookRequest.PaymentAmount;
                            transaction.WalletBalance = walletResponse[0].Balance;
                            transaction.CreatedBy = PaymentBookRequest.CreatedBy;
                            transaction.CreatedAt = DateTime.UtcNow;

                            repository.Transactions.CreateTransactions(transaction);
                        }
                    }
                }

                repository.PaymentBook.UpdatePaymentBook(PaymentBookRequest);

                await repository.SaveAsync();

                return new APIResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdatePaymentBookHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
