#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  24-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | GSTDetailsProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using System.Collections.Generic;
using Happy.Weddings.Identity.Core.DTO.Requests.KYCDetail;
using Happy.Weddings.Identity.Core.Entity;

#endregion

namespace Happy.Weddings.Identity.Core.Profile.KYCDetail
{
    /// <summary>
    /// Automapper profile for create GST Details.
    /// </summary>
    public class GSTDetailsProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GSTDetailsProfile"/> class.
        /// </summary>
        public GSTDetailsProfile()
        {
            CreateMap<GSTDetails, Gstdetails>()
               .ForMember(x => x.CreatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
