#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 18-SEP-2020 | NIKHIL K DAS | Created and implemented.
//                                | UpdateWalletDeductionProfile - class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Requests.WalletDeduction;
using Happy.Weddings.Wallet.Core.Entity;

namespace Happy.Weddings.Wallet.Core.Profile.WalletDeduction
{
    /// <summary>
    /// This class is used to map UpdateWalletDeductionProfile
    /// </summary>
    public class UpdateWalletDeductionProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWalletDeductionProfile"/> class.
        /// </summary>
        public UpdateWalletDeductionProfile()
        {
            CreateMap<UpdateWalletDeductionRequest, Walletdeduction>()
                .ForMember(x => x.UpdatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
