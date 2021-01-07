#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 11-Aug-2020 | REJI SALOOJA B S | Created and implemented.
//                                | EventGalleryResponseProfile  - class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses.EventGallery;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Profile.EventGallery
{
    public class EventGalleryResponseProfile : AutoMapper.Profile
    {
        public EventGalleryResponseProfile()
        {
            CreateMap<Gallery, EventGalleryResponse>();
        }
    }
}
