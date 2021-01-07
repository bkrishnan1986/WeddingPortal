#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  01-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | CompanyDistrictsProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using Happy.Weddings.Identity.Core.DTO.Requests.Profile;
using Happy.Weddings.Identity.Core.Entity;

#endregion

namespace Happy.Weddings.Identity.Core.Profile.Profile
{
    /// <summary>
    /// Automapper profile for create company districts.
    /// </summary>
    public class CompanyDistrictsProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyDistrictsProfile"/> class.
        /// </summary>
        public CompanyDistrictsProfile()
        {
            CreateMap<CompanyDistricts, Companydistricts>()
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(o => DateTime.UtcNow)).ReverseMap();
        }
    }
}