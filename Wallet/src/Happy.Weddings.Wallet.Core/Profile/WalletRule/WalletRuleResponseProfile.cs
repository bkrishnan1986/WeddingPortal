#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date         | Author          | Description
//----------------------------------------------------------------------------------------------
// 18-SEP-2020 | NIKHIL K DAS  | Created and implemented.
//             |                    | WalletRuleResponseProfile class.
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Responses.WalletRule;
using Happy.Weddings.Wallet.Core.Entity;

namespace Happy.Weddings.Wallet.Core.Profile.WalletRule
{
    public class WalletRuleResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WalletRuleResponseProfile"/> class.
        /// </summary>
        public WalletRuleResponseProfile()
        {
            CreateMap<Walletrule, WalletRuleResponse>()
                .ForMember(x => x.ModeValue, opt => opt.MapFrom(o => o.ModeNavigation != null ? o.ModeNavigation.Value : string.Empty));
        }
    }
}
