#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS  | Created and implemented. 
//              |                      | UpdatePaymentBookCommand --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Requests.PaymentBook;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Commands.v1.PaymentBook
{
    /// <summary>
    /// Command for updating a PaymentBook
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class UpdatePaymentBookCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the PaymentBook identifier.
        /// </summary>
        /// <value>
        /// The PaymentBook identifier.
        /// </value>
        public int PaymentBookId { get; set; }

        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public UpdatePaymentBookRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdatePaymentBookCommand" /> class.
        /// </summary>
        /// <param name="paymentBookId">The PaymentBook identifier.</param>
        /// <param name="Request">The request.</param>
        public UpdatePaymentBookCommand(int paymentBookId, UpdatePaymentBookRequest request)
        {
            PaymentBookId = paymentBookId;
            Request = request;
        }
    }
}
