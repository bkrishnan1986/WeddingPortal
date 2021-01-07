#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  25-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | CreateWalletProfile --class
//----------------------------------------------------------------------------------------------

#endregion

using Happy.Weddings.Wallet.Core.DTO.Requests.Wallet;
using Happy.Weddings.Wallet.Core.Entity;
using System;

namespace Happy.Weddings.Wallet.Core.Profile.Wallet
{
    public class CreateWalletProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateWalletProfile"/> class.
        /// </summary>
        public CreateWalletProfile()
        {
            CreateMap<CreateWalletRequest, Wallets>()
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }

}
