#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | GetRefundQuery --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Queries.v1.Refund
{
    /// <summary>
    /// Query for getting a Refund
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}}" />
    public class GetRefundQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Refund identifier.
        /// </summary>
        public int RefundId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRefundQuery"/> class.
        /// </summary>
        /// <param name="refundId">The Refund identifier.</param>
        public GetRefundQuery(int refundId)
        {
            RefundId = refundId;
        }
    }
}
