#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date         | Author          | Description
//----------------------------------------------------------------------------------------------
// 25-Aug-2020 | ARAVIND PERUMAL S  | Created and implemented.
//             |                    | WalletResponseProfile class.
//----------------------------------------------------------------------------------------------

#endregion

using Happy.Weddings.Wallet.Core.DTO.Responses.Wallet;
using Happy.Weddings.Wallet.Core.Entity;

namespace Happy.Weddings.Wallet.Core.Profile.Wallet
{
    public class WalletResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WalletResponseProfile"/> class.
        /// </summary>
        public WalletResponseProfile()
        {
            CreateMap<Wallets, WalletResponse>()
                .ForMember(x => x.StatusValue, opt => opt.MapFrom(o => o.StatusNavigation != null ? o.StatusNavigation.Value : ""));
        }
    }
}