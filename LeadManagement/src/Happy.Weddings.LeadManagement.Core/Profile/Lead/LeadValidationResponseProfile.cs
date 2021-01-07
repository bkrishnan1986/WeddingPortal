#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | LeadValidationResponseProfile class.
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
    public class LeadValidationResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeadValidationResponseProfile"/> class.
        /// </summary>
        public LeadValidationResponseProfile()
        {
            CreateMap<Leadvalidation, LeadValidationResponse>()
                .ForMember(x => x.StatusName, opt => opt.MapFrom(x => x.StatusNavigation != null ? x.StatusNavigation.Value : ""));
        }
    }
}
