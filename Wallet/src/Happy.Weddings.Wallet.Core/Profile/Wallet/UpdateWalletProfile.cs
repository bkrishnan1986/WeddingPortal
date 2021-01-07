
#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 18-SEP-2020 | NIKHIL K DAS | Created and implemented.
//                                | UpdateWalletProfile - class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using Happy.Weddings.Wallet.Core.DTO.Requests.Wallet;
using Happy.Weddings.Wallet.Core.Entity;

namespace Happy.Weddings.Wallet.Core.Profile.Wallet
{
    /// <summary>
    /// This class is used to map UpdateWalletProfile
    /// </summary>
    class UpdateWalletProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWalletProfile"/> class.
        /// </summary>
        public UpdateWalletProfile()
        {
            CreateMap<UpdateWalletRequest, Wallets>()
                .ForMember(x => x.UpdatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
