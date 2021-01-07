#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | GetAllRefundQuery --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Requests.Refund;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Queries.v1.Refund
{
    /// <summary>
    /// Query for getting Refund
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}}" />
    public class GetAllRefundQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Refund parameters.
        /// </summary>
        public RefundParameter RefundParameter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllRefundQuery"/> class.
        /// </summary>
        /// <param name="refundParameter">The Refund parameters.</param>
        public GetAllRefundQuery(RefundParameter refundParameter)
        {
            RefundParameter = refundParameter;
        }
    }
}
