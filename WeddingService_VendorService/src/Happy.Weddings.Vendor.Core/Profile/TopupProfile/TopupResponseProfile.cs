#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date         | Author          | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | ARAVIND PERUMAL S  | Created and implemented.
//             |                    | VendorSubscriptionResponseProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header


using Happy.Weddings.Vendor.Core.DTO.Responses.TopUps;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Profile.VendorSubscriptionProfile
{
    public class TopupResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResponseProfile"/> class.
        /// </summary>
        public TopupResponseProfile()
        {
            CreateMap<Topup, TopUpsResponse>()
                .ForMember(x => x.TopUpTypeName, opt => opt.MapFrom(o => o.TopUpTypeNavigation != null ? o.TopUpTypeNavigation.Value : ""))
                .ForMember(x => x.ModeName, opt => opt.MapFrom(o => o.ModeNavigation != null ? o.ModeNavigation.Value : ""));
        }
    }
}