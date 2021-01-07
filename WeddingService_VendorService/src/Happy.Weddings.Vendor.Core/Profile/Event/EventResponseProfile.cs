#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 10-Aug-2020 | REJI SALOOJA B S | Created and implemented.
//                                | EventResponseProfile  - class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses.Event;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Profile.Event
{
    public class EventResponseProfile : AutoMapper.Profile
    {
        public EventResponseProfile()
        {
            CreateMap<Events, EventResponse>();
        }
    }
}
