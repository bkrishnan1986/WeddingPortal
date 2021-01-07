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

#endregion File Header


using Happy.Weddings.Vendor.Core.DTO.Responses.Wallet;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Profile.VendorSubscriptionProfile
{
    public class WalletResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResponseProfile"/> class.
        /// </summary>
        public WalletResponseProfile()
        {
            CreateMap<Wallet, WalletResponse>();
        }
    }
}