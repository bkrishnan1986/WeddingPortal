#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  13-Aug-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | EventRepository --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.EventGallery;
using Happy.Weddings.Vendor.Core.Entity;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Core.Repository
{
    public interface IEventGalleryRepository : IRepositoryBase<Gallery>
    {
        /// <summary>
        /// Gets the event gallery by vendor identifier.
        /// </summary>
        /// <param name="eventGalleryParameters">The event gallery parameters.</param>
        /// <returns></returns>
        Task<PagedList<Domain.Entity>> GetEventGalleryByVendorId(EventGalleryParameters eventGalleryParameters);
    }
}
