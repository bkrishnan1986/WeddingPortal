#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date         | Author          | Description
//----------------------------------------------------------------------------------------------
// 28-Aug-2020 | ARAVIND PERUMAL S  | Created and implemented.
//             |                    | SubscriptionLocationResponseProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses.Service;
using Happy.Weddings.Vendor.Core.DTO.Responses.SubscriptionLocation;
using Happy.Weddings.Vendor.Core.Entity;


namespace Happy.Weddings.Vendor.Core.Profile.ServicesProfile
{
    public class SubscriptionLocationResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResponseProfile"/> class.
        /// </summary>
        public SubscriptionLocationResponseProfile()
        {
            CreateMap<Subscriptionlocation, SubscriptionLocationResponse>()
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(o => o.Category != null ? o.Category.Value : "")) 
                .ForMember(x => x.LocationName, opt => opt.MapFrom(o => o.Location != null ? o.Location.Value : ""))
                .ForMember(x => x.PackageName, opt => opt.MapFrom(o => o.PackageTypeNavigation != null ? o.PackageTypeNavigation.Value : ""))
                .ForMember(x => x.ModeName, opt => opt.MapFrom(o => o.ModeNavigation != null ? o.ModeNavigation.Value : ""));         
        }
    }
}