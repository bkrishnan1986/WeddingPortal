#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS  | Created and implemented. 
//              |                      | DeleteWalletStatusCommand --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Commands.v1.WalletStatus
{
    /// <summary>
    /// Command for deleting a Wallet Status
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class DeleteWalletStatusCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Wallet Status identifier.
        /// </summary>
        /// <value>
        /// The Wallet Status identifier.
        /// </value>
        public int WalletStatusId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWalletStatusCommand"/> class.
        /// </summary>
        /// <param name="walletStatusId">The wWllet Status identifier.</param>
        public DeleteWalletStatusCommand(int walletStatusId)
        {
            WalletStatusId = walletStatusId;
        }
    }
}
