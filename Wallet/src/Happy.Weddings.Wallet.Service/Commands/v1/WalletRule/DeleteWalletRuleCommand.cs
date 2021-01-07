#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS  | Created and implemented. 
//              |                      | DeleteWalletRuleCommand --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Commands.v1.WalletRule
{
    /// <summary>
    /// Command for deleting a Wallet Rule
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class DeleteWalletRuleCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the WalletRule identifier.
        /// </summary>
        /// <value>
        /// The WalletRule identifier.
        /// </value>
        public int WalletRuleId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteWalletRuleCommand"/> class.
        /// </summary>
        /// <param name="walletRuleId">The wWlletRule identifier.</param>
        public DeleteWalletRuleCommand(int walletRuleId)
        {
            WalletRuleId = walletRuleId;
        }
    }
}
