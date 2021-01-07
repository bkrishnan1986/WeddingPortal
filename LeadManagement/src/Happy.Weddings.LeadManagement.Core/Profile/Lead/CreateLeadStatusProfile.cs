#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | CreateLeadStatusProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead;
using Happy.Weddings.LeadManagement.Core.Entity;
using System;

#endregion

namespace Happy.Weddings.LeadManagement.Core.Profile.Lead
{
    public class CreateLeadStatusProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLeadsProfile"/> class.
        /// </summary>
        public CreateLeadStatusProfile()
        {
            CreateMap<CreateLeadStatusRequest, Leadstatus>()
               .ForMember(x => x.CreatedAt, opt => opt.MapFrom(o => DateTime.UtcNow)); //.ReverseMap();
        }
    }
}
