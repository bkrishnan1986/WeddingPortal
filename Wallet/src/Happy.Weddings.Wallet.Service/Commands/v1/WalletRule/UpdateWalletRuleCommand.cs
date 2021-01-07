#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS  | Created and implemented. 
//              |                      | UpdateWalletRuleCommand --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Requests.WalletRule;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Commands.v1.WalletRule
{
    /// <summary>
    /// Command for updating a Wallet Rule
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class UpdateWalletRuleCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Wallet identifier.
        /// </summary>
        /// <value>
        /// The Wallet identifier.
        /// </value>
        public int WalletRuleId { get; set; }

        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public UpdateWalletRuleRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWalletRuleCommand" /> class.
        /// </summary>
        /// <param name="walletRuleId">The Wallet Rule identifier.</param>
        /// <param name="Request">The request.</param>
        public UpdateWalletRuleCommand(int walletRuleId, UpdateWalletRuleRequest request)
        {
            WalletRuleId = walletRuleId;
            Request = request;
        }
    }
}
