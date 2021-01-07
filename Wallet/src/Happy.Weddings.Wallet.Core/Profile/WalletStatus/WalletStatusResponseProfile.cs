#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date         | Author          | Description
//----------------------------------------------------------------------------------------------
// 18-SEP-2020 | NIKHIL K DAS  | Created and implemented.
//             |                    | WalletStatusResponseProfile class.
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Responses.WalletStatus;
using Happy.Weddings.Wallet.Core.Entity;

namespace Happy.Weddings.Wallet.Core.Profile.WalletStatus
{
    public class WalletStatusResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WalletStatusResponseProfile"/> class.
        /// </summary>
        public WalletStatusResponseProfile()
        {
            CreateMap<Walletstatus, WalletStatusResponse>()
                 .ForMember(x => x.StatusValue, opt => opt.MapFrom(o => o.StatusNavigation != null ? o.StatusNavigation.Value : ""));
        }
    }
}
