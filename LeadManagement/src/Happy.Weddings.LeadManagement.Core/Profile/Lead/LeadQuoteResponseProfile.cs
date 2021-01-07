#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | LeadQuoteResponseProfile class.
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
    public class LeadQuoteResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeadQuoteResponseProfile"/> class.
        /// </summary>
        public LeadQuoteResponseProfile()
        {
            CreateMap<Leadquote, LeadQuoteResponse>()
           .ForMember(x => x.LeadTypeName, opt => opt.MapFrom(o => o.LeadTypeNavigation != null ? o.LeadTypeNavigation.Value : ""))
           .ForMember(x => x.SubLeadTypeName, opt => opt.MapFrom(o => o.SubLeadTypeNavigation != null ? o.SubLeadTypeNavigation.Value : ""));
        }
    }
}
