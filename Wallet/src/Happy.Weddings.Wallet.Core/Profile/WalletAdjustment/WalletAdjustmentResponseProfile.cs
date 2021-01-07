#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date         | Author          | Description
//----------------------------------------------------------------------------------------------
// 18-SEP-2020 | NIKHIL K DAS  | Created and implemented.
//             |                    | WalletAdjustmentResponseProfile class.
//----------------------------------------------------------------------------------------------

#endregion

using Happy.Weddings.Wallet.Core.DTO.Responses.WalletAdjustment;
using Happy.Weddings.Wallet.Core.Entity;

namespace Happy.Weddings.Wallet.Core.Profile.WalletAdjustment
{
    public class WalletAdjustmentResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WalletAdjustmentResponseProfile"/> class.
        /// </summary>
        public WalletAdjustmentResponseProfile()
        {
            CreateMap<Walletadjustment, WalletAdjustmentResponse>()
                .ForMember(x => x.AdjustmentTypeName, opt => opt.MapFrom(o => o.AdjustmentTypeNavigation != null ? o.AdjustmentTypeNavigation.Value : ""));
        }
    }
}
