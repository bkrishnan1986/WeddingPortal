#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 05-Aug-2020 | REJI SALOOJA B S | Created and implemented.
//                                | CreateEventProfile  - class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.Event;
using Happy.Weddings.Vendor.Core.Entity;
using System;

namespace Happy.Weddings.Vendor.Core.Profile.Event
{
    /// <summary>
    /// This class is used to map CreateEventProfile
    /// </summary>
    public class CreateEventProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateEventProfile"/> class.
        /// </summary>
        public CreateEventProfile()
        {
            CreateMap<CreateEventRequest, Events>()
                 .ForMember(x => x.CreatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
