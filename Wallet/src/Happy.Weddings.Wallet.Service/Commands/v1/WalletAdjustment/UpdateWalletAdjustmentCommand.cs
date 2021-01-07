#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS  | Created and implemented. 
//              |                      | UpdateWalletAdjustmentCommand --class
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
    /// Command for updating a Wallet Adjustment
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class UpdateWalletAdjustmentCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Wallet Adjustment identifier.
        /// </summary>
        /// <value>
        /// The Wallet Adjustment identifier.
        /// </value>
        public int WalletAdjustmentId { get; set; }

        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public UpdateWalletAdjustmentRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWalletAdjustmentCommand" /> class.
        /// </summary>
        /// <param name="walletAdjustmentId">The Wallet Adjustment identifier.</param>
        /// <param name="Request">The request.</param>
        public UpdateWalletAdjustmentCommand(int walletAdjustmentId, UpdateWalletAdjustmentRequest request)
        {
            WalletAdjustmentId = walletAdjustmentId;
            Request = request;
        }
    }
}
