#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | CreateWalletDeductionProfile --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Requests.WalletDeduction;
using Happy.Weddings.Wallet.Core.Entity;

namespace Happy.Weddings.Wallet.Core.Profile.WalletDeduction
{
    public class CreateWalletDeductionProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateWalletDeductionProfile"/> class.
        /// </summary>
        public CreateWalletDeductionProfile()
        {
            CreateMap<CreateWalletDeductionRequest, Walletdeduction>()
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
