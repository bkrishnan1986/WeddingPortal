#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS  | Created and implemented. 
//              |                      | UpdateRefundHandler --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using Happy.Weddings.Wallet.Core.Entity;
using Happy.Weddings.Wallet.Core.Repository;
using Happy.Weddings.Wallet.Service.Commands.v1.Refund;
using MediatR;
using Serilog;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Wallet.Service.Handlers.v1.Refund
{
    /// <summary>
    /// Handler for updating a Refund
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Wallet.Service.Commands.v1.Refund.UpdateRefundCommand, Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class UpdateRefundHandler : IRequestHandler<UpdateRefundCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="UpdateRefundHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public UpdateRefundHandler(
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
        public async Task<APIResponse> Handle(UpdateRefundCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var refund = await repository.Refund.GetRefundById(request.RefundId);

                if (refund == null) return new APIResponse(HttpStatusCode.NotFound);

                if (request.IsApproved == true || request.IsRejected == true)
                {
                    string status = string.Empty;

                    if (request.IsApproved) status = "APPROVE";
                    else if (request.IsRejected) status = "REJECT";

                    var BHstatus = await repository.MultiDetails.GetMultiDetailsByCode("BH STATUS");

                    if (BHstatus != null && BHstatus.Count > 0)
                    {
                        foreach (var type in BHstatus)
                        {
                            if (type.Value.Trim().ToUpper() == status)
                            {
                                request.Request.Bhstatus = type.Id;
                                break;
                            }
                        }
                    }
                }

                var refundRequest = mapper.Map(request.Request, refund);

                decimal Balance = 0;

                Core.DTO.Requests.Wallet.WalletsParameter WP = new Core.DTO.Requests.Wallet.WalletsParameter();
                WP.VendorId = refund.RaisedBy;
                var walletResponse = await repository.Wallets.GetAllWallets(WP);

                if (walletResponse != null && walletResponse.Count > 0) Balance = walletResponse[0].Balance;

                if (request.IsApproved)
                {
                    Paymentbook paymentbook = new Paymentbook();
                    paymentbook.EntryDate = DateTime.UtcNow;
                    paymentbook.VendorId = refund.RaisedBy;

                    var PaymentType = await repository.MultiDetails.GetMultiDetailsByCode("PAYMENT TYPE");

                    if (PaymentType != null && PaymentType.Count > 0)
                    {
                        foreach (var item in PaymentType)
                        {
                            if (item.Value.Trim().ToUpper() == "DEBIT")
                            {
                                paymentbook.PaymentType = item.Id;
                                break;
                            }
                        }
                    }

                    var PaymentStatus = await repository.MultiDetails.GetMultiDetailsByCode("PAYMENT STATUS");

                    if (PaymentStatus != null && PaymentStatus.Count > 0)
                    {
                        foreach (var item in PaymentStatus)
                        {
                            if (item.Value.Trim().ToUpper() == "PAID")
                            {
                                paymentbook.PaymentStatus = item.Id;
                                break;
                            }
                        }
                    }

                    var PaymentMode = await repository.MultiDetails.GetMultiDetailsByCode("PAYMENT MODE");

                    if (PaymentMode != null && PaymentMode.Count > 0)
                    {
                        foreach (var item in PaymentMode)
                        {
                            if (item.Value.Trim().ToUpper() == "CASH")
                            {
                                paymentbook.PaymentMode = item.Id;
                                break;
                            }
                        }
                    }

                    paymentbook.PaymentAmount = (decimal)refund.ApprovedAmount;
                    paymentbook.PaymentDate = DateTime.UtcNow;
                    paymentbook.WalletBalance = Balance;
                    paymentbook.CreatedBy = (int)refundRequest.UpdatedBy;
                    paymentbook.CreatedAt = DateTime.UtcNow;

                    repository.PaymentBook.CreatePaymentBook(paymentbook);

                }

                refundRequest.WalletBalance = Balance;

                repository.Refund.UpdateRefund(refundRequest);

                await repository.SaveAsync();

                return new APIResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateRefundHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
