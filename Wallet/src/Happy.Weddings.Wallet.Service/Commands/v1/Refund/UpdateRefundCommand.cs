#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS  | Created and implemented. 
//              |                      | UpdateRefundCommand --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Requests.Refund;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Commands.v1.Refund
{
    /// <summary>
    /// Command for updating a Refund
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class UpdateRefundCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Refund identifier.
        /// </summary>
        /// <value>
        /// The Refund identifier.
        /// </value>
        public int RefundId { get; set; }
        public bool IsApproved { get; set; }
        public bool IsRejected { get; set; }

        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public UpdateRefundRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateRefundCommand" /> class.
        /// </summary>
        /// <param name="refundId">The Refund identifier.</param>
        /// <param name="isApproved">IsApproved status.</param>
        /// <param name="isRejected">IsRejected status.</param>
        /// <param name="Request">The request.</param>
        public UpdateRefundCommand(int refundId, UpdateRefundRequest request, bool isApproved = false, bool isRejected = false)
        {
            RefundId = refundId;
            Request = request;
            IsApproved = isApproved;
            IsRejected = isRejected;
        }
    }
}
