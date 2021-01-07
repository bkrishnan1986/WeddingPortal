#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | GetPaymentBookQuery --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Queries.v1.PaymentBook
{
    /// <summary>
    /// Query for getting a PaymentBook
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}}" />
    public class GetPaymentBookQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the PaymentBook identifier.
        /// </summary>
        public int PaymentBookId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPaymentBookQuery"/> class.
        /// </summary>
        /// <param name="paymentBookId">The PaymentBook identifier.</param>
        public GetPaymentBookQuery(int paymentBookId)
        {
            PaymentBookId = paymentBookId;
        }

    }
}
