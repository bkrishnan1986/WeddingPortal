#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | CreateRefundCommand --class
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
    /// Command for creating a Refund
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class CreateRefundCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public CreateRefundRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRefundCommand"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public CreateRefundCommand(CreateRefundRequest request)
        {
            Request = request;
        }
    }
}
