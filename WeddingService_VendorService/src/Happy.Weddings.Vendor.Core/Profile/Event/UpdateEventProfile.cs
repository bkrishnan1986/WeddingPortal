#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 05-Aug-2020 | REJI SALOOJA B S | Created and implemented.
//                                | UpdateEventProfile   - class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.Event;
using Happy.Weddings.Vendor.Core.Entity;
using System;

namespace Happy.Weddings.Vendor.Core.Profile.Event
{
    /// <summary>
    ///  This class is used to map UpdateEventProfile
    /// </summary>
    public class UpdateEventProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateEventProfile"/> class.
        /// </summary>
        public UpdateEventProfile()
        {
            CreateMap<UpdateEventRequest, Events>()
                 .ForMember(x => x.UpdatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
