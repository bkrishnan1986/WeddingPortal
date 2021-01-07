#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | CreatePaymentBookHandler --class
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
using System.Collections;

namespace Happy.Weddings.Wallet.Service.Handlers.v1.PaymentBook
{
    /// <summary>
    /// Handler for creating a PaymentBook
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Wallet.Service.Commands.v1.PaymentBook.CreatePaymentBookCommand, Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class CreatePaymentBookHandler : IRequestHandler<CreatePaymentBookCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="CreatePaymentBookHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public CreatePaymentBookHandler(
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
        public async Task<APIResponse> Handle(CreatePaymentBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //Random string generator
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var stringChars = new char[8];
                var random = new Random();
                for (int i = 0; i < stringChars.Length; i++) { stringChars[i] = chars[random.Next(chars.Length)]; }
                var finalString = new String(stringChars);
                //Random string generator

                decimal Balance = 0;
                ArrayList WalletData = new ArrayList();

                foreach (var item in request.Request.Payment_Book)
                {
                    var paymentBookRequest = mapper.Map<Paymentbook>(item);

                    var PaymentStatus = await repository.MultiDetails.GetMultiDetailByMultiDetailId(paymentBookRequest.PaymentStatus);
                    var PaymentType = await repository.MultiDetails.GetMultiDetailByMultiDetailId(paymentBookRequest.PaymentType);

                    Core.DTO.Requests.Wallet.WalletsParameter WP = new Core.DTO.Requests.Wallet.WalletsParameter();
                    WP.VendorId = paymentBookRequest.VendorId;
                    var walletResponse = await repository.Wallets.GetAllWallets(WP);

                    if (PaymentStatus.Value.Trim().ToUpper() == "PAID" && PaymentType.Value.Trim().ToUpper() == "CREDIT")
                    {
                        if (walletResponse != null && walletResponse.Count > 0)
                        {
                            if (paymentBookRequest.PaymentRefNumber.Trim() == string.Empty) paymentBookRequest.PaymentRefNumber = "REF-" + finalString;

                            if (!WalletData.Contains(walletResponse[0].Id))
                            {
                                WalletData.Add(walletResponse[0].Id);
                                Balance = walletResponse[0].Balance + paymentBookRequest.PaymentAmount;
                            }
                            else
                            {
                                Balance += paymentBookRequest.PaymentAmount;
                            }

                            paymentBookRequest.WalletBalance = Balance;

                            //repository.Wallets.UpdateWallet(walletResponse[0]);

                            var PackageType = await repository.MultiDetails.GetMultiDetailByMultiDetailId((int)paymentBookRequest.PackageType);

                            Core.Entity.Transactions transaction = new Core.Entity.Transactions();
                            transaction.WalletId = walletResponse[0].Id;
                            transaction.ReferenceNo = paymentBookRequest.PaymentRefNumber;

                            if (PackageType.Value.Trim().ToUpper() == "SUBSCRIPTION") transaction.Particulars = item.PackageName + "-taken (" + PackageType.Value + ")";
                            else if (PackageType.Value.Trim().ToUpper() == "TOP-UP") transaction.Particulars = item.PackageName + "-done (" + PackageType.Value + ")";
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

                            transaction.Amount = paymentBookRequest.PaymentAmount;
                            transaction.WalletBalance = Balance;
                            transaction.CreatedBy = paymentBookRequest.CreatedBy;
                            transaction.CreatedAt = DateTime.UtcNow;

                            repository.Transactions.CreateTransactions(transaction);
                        }
                    }
                    else
                    {
                        if (walletResponse != null && walletResponse.Count > 0) paymentBookRequest.WalletBalance = walletResponse[0].Balance;
                        if (paymentBookRequest.PaymentRefNumber.Trim() == string.Empty) paymentBookRequest.PaymentRefNumber = "REF-" + finalString;
                    }

                    repository.PaymentBook.CreatePaymentBook(paymentBookRequest);
                }

                if (WalletData.Count > 0 && Balance > 0)
                {
                    var Wallet = await repository.Wallets.GetWalletById((int)WalletData[0]);
                    Wallet.Balance = Balance;
                    repository.Wallets.UpdateWallet(Wallet);
                }

                await repository.SaveAsync();

                return new APIResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreatePaymentBookHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
