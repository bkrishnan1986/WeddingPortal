#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | CreatePaymentBookCommand --class
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
    /// Command for creating a PaymentBook
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class CreatePaymentBookCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public CreatePaymentBookRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreatePaymentBookCommand"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public CreatePaymentBookCommand(CreatePaymentBookRequest request)
        {
            Request = request;
        }
    }
}
