#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS  | Created and implemented. 
//              |                      | DeleteWalletAdjustmentCommand --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Commands.v1.WalletAdjustment
{
    /// <summary>
    /// Command for deleting a Wallet Adjustment
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />

    public class DeleteWalletAdjustmentCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Wallet Adjustment identifier.
        /// </summary>
        /// <value>
        /// The Wallet Adjustment identifier.
        /// </value>
        public int WalletAdjustmentId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWalletAdjustmentCommand"/> class.
        /// </summary>
        /// <param name="walletAdjustmentId">The wWllet identifier.</param>
        public DeleteWalletAdjustmentCommand(int walletAdjustmentId)
        {
            WalletAdjustmentId = walletAdjustmentId;
        }
    }
}
