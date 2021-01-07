
#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS  | Created and implemented. 
//              |                      | DeleteWalletCommand --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Commands.v1.Wallet
{
    /// <summary>
    /// Command for deleting a Wallet
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class DeleteWalletCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Wallet identifier.
        /// </summary>
        /// <value>
        /// The Wallet identifier.
        /// </value>
        public int WalletId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWalletCommand"/> class.
        /// </summary>
        /// <param name="walletId">The wWllet identifier.</param>
        public DeleteWalletCommand(int walletId)
        {
            WalletId = walletId;
        }
    }
}
