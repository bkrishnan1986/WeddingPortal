#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | GetWalletRuleQuery --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Queries.v1.WalletRule
{
    /// <summary>
    /// Query for getting a WalletRule
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}}" />
    public class GetWalletRuleQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the WalletRule identifier.
        /// </summary>
        public int WalletRuleId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWalletRuleQuery"/> class.
        /// </summary>
        /// <param name="walletRuleId">The WalletRule identifier.</param>
        public GetWalletRuleQuery(int walletRuleId)
        {
            WalletRuleId = walletRuleId;
        }
    }
}
