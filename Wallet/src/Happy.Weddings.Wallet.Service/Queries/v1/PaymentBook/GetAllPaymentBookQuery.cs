#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | GetAllPaymentBookQuery --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Requests.PaymentBook;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Queries.v1.PaymentBook
{
    /// <summary>
    /// Query for getting PaymentBook
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}}" />
    public class GetAllPaymentBookQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the PaymentBook Search parameters.
        /// </summary>
        public PaymentBookSearchParameter PaymentBookSearchParameter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllPaymentBookQuery"/> class.
        /// </summary>
        /// <param name="paymentBookSearchParameter">The PaymentBook Search parameters.</param>
        public GetAllPaymentBookQuery(PaymentBookSearchParameter paymentBookSearchParameter)
        {
            PaymentBookSearchParameter = paymentBookSearchParameter;
        }
    }
}
