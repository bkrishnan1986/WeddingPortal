#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | GetAllWalletRuleQuery --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Requests.WalletRule;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Queries.v1.WalletRule
{
    /// <summary>
    /// Query for getting WalletRules
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}}" />
    public class GetAllWalletRuleQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the WalletRule parameters.
        /// </summary>
        public WalletRuleParameter WalletRuleParameter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllWalletRuleQuery"/> class.
        /// </summary>
        /// <param name="walletRuleParameter">The WalletRule parameters.</param>
        public GetAllWalletRuleQuery(WalletRuleParameter walletRuleParameter)
        {
            WalletRuleParameter = walletRuleParameter;
        }
    }
}
