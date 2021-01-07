#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | ServiceResponseProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses.Service;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Profile.ServicesProfile
{
    public class ServiceResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResponseProfile"/> class.
        /// </summary>
        public ServiceResponseProfile()
        {
            CreateMap<Services, ServiceDetailsResponse>()
                 .ForMember(x => x.CurrencyName, opt => opt.MapFrom(o => o.CurrencyNavigation != null ? o.CurrencyNavigation.Value : ""))
                 .ForMember(x => x.LocationName, opt => opt.MapFrom(o => o.Location != null ? o.Location.Value : ""));
            CreateMap<Services, ServiceResposnseList>()
                .ForMember(x => x.CurrencyName, opt => opt.MapFrom(o => o.CurrencyNavigation != null ? o.CurrencyNavigation.Value : ""))
                .ForMember(x => x.LocationName, opt => opt.MapFrom(o => o.Location != null ? o.Location.Value : ""));
        }
    }
}
