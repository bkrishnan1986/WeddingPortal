#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | AddServicesProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.Service;
using Happy.Weddings.Vendor.Core.Entity;
using System;

namespace Happy.Weddings.Vendor.Core.Profile.ServicesProfile
{
    public class AddServicesProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateServiceProfile"/> class.
        /// </summary>
        public AddServicesProfile()
        {
            CreateMap<AddServicesRequest, Services>()
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
    
}
