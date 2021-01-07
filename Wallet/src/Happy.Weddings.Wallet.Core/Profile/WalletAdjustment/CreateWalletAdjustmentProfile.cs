#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | CreateWalletAdjustmentProfile --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Requests.WalletAdjustment;
using Happy.Weddings.Wallet.Core.Entity;

namespace Happy.Weddings.Wallet.Core.Profile.WalletAdjustment
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateWalletAdjustmentProfile"/> class.
    /// </summary>
    public class CreateWalletAdjustmentProfile : AutoMapper.Profile
    {
        public CreateWalletAdjustmentProfile()
        {
            CreateMap<CreateWalletAdjustmentRequest, Walletadjustment>()
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
