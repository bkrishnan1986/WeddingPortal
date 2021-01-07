#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | CreateAssignLeadProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead;
using Happy.Weddings.LeadManagement.Core.Entity;
using System;

#endregion

namespace Happy.Weddings.LeadManagement.Core.Profile.Lead
{
    public class CreateLeadAssignProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLeadAssignProfile"/> class.
        /// </summary>
        public CreateLeadAssignProfile()
        {
            CreateMap<CreateLeadAssignRequest, Leadassign>()
               .ForMember(x => x.CreatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}