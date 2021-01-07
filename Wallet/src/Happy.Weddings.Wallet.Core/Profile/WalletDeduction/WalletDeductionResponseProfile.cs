#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date         | Author          | Description
//----------------------------------------------------------------------------------------------
// 18-SEP-2020 | NIKHIL K DAS  | Created and implemented.
//             |                    | WalletDeductionResponseProfile class.
//----------------------------------------------------------------------------------------------

#endregion

using Happy.Weddings.Wallet.Core.DTO.Responses.WalletDeduction;
using Happy.Weddings.Wallet.Core.Entity;

namespace Happy.Weddings.Wallet.Core.Profile.WalletDeduction
{
    public class WalletDeductionResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WalletDeductionResponseProfile"/> class.
        /// </summary>
        public WalletDeductionResponseProfile()
        {
            CreateMap<Walletdeduction, WalletDeductionResponse>()
                 .ForMember(x => x.CategoryName, opt => opt.MapFrom(o => o.Category != null ? o.Category.Value : ""))
                 .ForMember(x => x.WalletStatusName, opt => opt.MapFrom(o => o.WalletStatusNavigation != null ? o.WalletStatusNavigation.Value : ""));
        }
    }
}
