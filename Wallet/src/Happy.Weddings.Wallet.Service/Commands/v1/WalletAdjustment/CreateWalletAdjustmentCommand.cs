#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | CreateWalletAdjustmentCommand --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Requests.WalletAdjustment;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Commands.v1.WalletAdjustment
{
    /// <summary>
    /// Command for creating a Wallet Adjustment
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />

    public class CreateWalletAdjustmentCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public CreateWalletAdjustmentRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateWalletAdjustmentCommand"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public CreateWalletAdjustmentCommand(CreateWalletAdjustmentRequest request)
        {
            Request = request;
        }
    }
}
