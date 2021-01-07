#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 18-SEP-2020 | NIKHIL K DAS | Created and implemented.
//                                | UpdateWalletStatusProfile - class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Requests.WalletStatus;
using Happy.Weddings.Wallet.Core.Entity;

namespace Happy.Weddings.Wallet.Core.Profile.WalletStatus
{
    /// <summary>
    /// This class is used to map UpdateWalletStatusProfile
    /// </summary>
    public class UpdateWalletStatusProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWalletStatusProfile"/> class.
        /// </summary>
        public UpdateWalletStatusProfile()
        {
            CreateMap<UpdateWalletStatusRequest, Walletstatus>()
                .ForMember(x => x.UpdatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
