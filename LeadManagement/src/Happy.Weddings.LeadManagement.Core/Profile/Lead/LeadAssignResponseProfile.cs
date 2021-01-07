#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | LeadAssignResponseProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using Happy.Weddings.LeadManagement.Core.Entity;

#endregion

namespace Happy.Weddings.LeadManagement.Core.Profile.Lead
{
    public class LeadAssignResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeadAssignResponseProfile"/> class.
        /// </summary>
        public LeadAssignResponseProfile()
        {
            CreateMap<Leadassign, LeadAssignResponse>()
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(x => x.CategoryNavigation != null ? x.CategoryNavigation.Value : ""));

            CreateMap<Leadassign, LeadAssignDetailResponse>()
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(x => x.CategoryNavigation != null ? x.CategoryNavigation.Value : ""));
        }
    }
}
