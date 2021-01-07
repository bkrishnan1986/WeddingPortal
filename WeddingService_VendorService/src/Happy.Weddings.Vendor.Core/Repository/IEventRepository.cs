#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  03-Aug-2020 |    REJI SALOOJA B S    | Created and implemented. 
//              |                         | IEventRepository -- interface
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.Event;
using Happy.Weddings.Vendor.Core.Entity;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Core.Repository
{
    /// <summary>
    ///  This interface is used to declare CRUD for the Event
    /// </summary>
    /// <seealso cref="Happy.Weddings.Vendor.Core.Repository.IRepositoryBase{Happy.Weddings.Vendor.Core.Entity.Events}" />
    public interface IEventRepository : IRepositoryBase<Events>          
    {                   
        /// <summary>
        /// Gets all events.
        /// </summary>
        /// <param name="eventParameters">The event parameters.</param>
        /// <returns></returns>
        Task<PagedList<Domain.Entity>> GetEventsByCondition(EventParameters eventParameters);

        /// <summary>
        /// Gets event by vendor.
        /// </summary>
        /// <param name="eventVendorParameters">The event vendor parameters.</param>
        /// <returns></returns>
        Task<PagedList<Domain.Entity>> GetEventByVendor(EventVendorParameters eventVendorParameters);

        /// <summary>
        /// Gets  event.
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        Task<Events> GetEventById(int eventId);

        /// <summary>
        /// Creates the event.
        /// </summary>
        /// <param name="event">The event.</param>
        void CreateEvent(Events events);

        /// <summary>
        /// Updates the event.
        /// </summary>
        /// <param name="event">The event.</param>
        void UpdateEvent(Events events);

        /// <summary>
        /// Deletes the event.
        /// </summary>
        /// <param name="event">The event.</param>
        void DeleteEvent(Events events);
        }
}
