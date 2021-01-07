#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Oct-2020 |    Sumith C       | Created and implemented. 
//              |                   | CreateLeadQuoteProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead;
using Happy.Weddings.LeadManagement.Core.Entity;
using System;

#endregion

namespace Happy.Weddings.LeadManagement.Core.Profile.Lead
{
    /// <summary>
    /// Profiler for lead quote.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class CreateLeadQuoteProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLeadQuoteProfile"/> class.
        /// </summary>
        public CreateLeadQuoteProfile()
        {
            CreateMap<LeadQuote, Leadquote>()
               .ForMember(x => x.CreatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}