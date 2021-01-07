#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  05-Aug-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | EventRepository --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.Event;
using Happy.Weddings.Vendor.Core.DTO.Responses.Event;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Helpers;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Data.Repository
{
    /// <summary>
    /// This class is used to implement CRUD for the Event
    /// </summary>
    /// <seealso cref="Happy.Weddings.Vendor.Data.Repository.RepositoryBase{Happy.Weddings.Vendor.Core.Entity.Events}" />
    /// <seealso cref="Happy.Weddings.Vendor.Core.Repository.IEventRepository" />
    public class EventRepository : RepositoryBase<Events>, IEventRepository
    {

        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<EventResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<EventResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public EventRepository(
            VendorContext repositoryContext,
            IMapper mapper,
            ISortHelper<EventResponse> sortHelper,
            IDataShaper<EventResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Gets events by filter by name, lovation and date.
        /// </summary>
        /// <param name="eventParameters">The event parameters.</param>
        /// <returns></returns>
        public async Task<PagedList<Entity>> GetEventsByCondition(EventParameters eventParameters)
        {
            var getEventsParams = new object[] {
                new MySqlParameter("@limit", eventParameters.PageSize),
                new MySqlParameter("@offset", (eventParameters.PageNumber - 1) * eventParameters.PageSize),
                new MySqlParameter("@fromDate", eventParameters.FromDate),
                new MySqlParameter("@toDate", eventParameters.ToDate),
                new MySqlParameter("@eventName", eventParameters.EventName),
                new MySqlParameter("@eventLocation", eventParameters.Location),
                new MySqlParameter("@ReviewType", eventParameters.ReviewType),
                new MySqlParameter("@ApprovalStatusId", eventParameters.ApprovalStatus)
            };

            var events = await FindAll("CALL SpSearchActiveEvents(@limit, @offset, @ReviewType, @ApprovalStatusId, @eventName, @eventLocation, @fromDate, @toDate)", getEventsParams).ToListAsync();
            var mappedevents = events.AsQueryable().ProjectTo<EventResponse>(mapper.ConfigurationProvider);
            var sortedevents = sortHelper.ApplySort(mappedevents, eventParameters.OrderBy);
            var shapedevents = dataShaper.ShapeData(sortedevents, eventParameters.Fields);

            return await PagedList<Entity>.ToPagedList(shapedevents, eventParameters.PageNumber, eventParameters.PageSize);
        }

        /// <summary>
        /// Gets  event by vendor.
        /// </summary>
        /// <param name="eventParameters">The event parameters.</param>
        /// <returns></returns>
        public async Task<PagedList<Entity>> GetEventByVendor(EventVendorParameters eventVendorParameters)
        {
            var getEventParams = new object[] {
                new MySqlParameter("@limit", null),
                new MySqlParameter("@offset", null),
                new MySqlParameter("@value", eventVendorParameters.Value),
                new MySqlParameter("@IsForVendor", eventVendorParameters.IsForVendor),
                new MySqlParameter("@IsForEvent", eventVendorParameters.IsForEvent),
                new MySqlParameter("@fromDate", null),
                new MySqlParameter("@toDate", null),
                new MySqlParameter("@ApprovalStatusId", eventVendorParameters.ApprovalStatus)
            };

            var events = await FindAll("CALL SpSelectActiveEvent(@limit, @offset, @value, @ApprovalStatusId, @IsForVendor, @IsForEvent,@fromDate,@toDate)", getEventParams).ToListAsync();
            var mappedevents = events.AsQueryable().ProjectTo<EventResponse>(mapper.ConfigurationProvider);
            var sortedevents = sortHelper.ApplySort(mappedevents, eventVendorParameters.OrderBy);
            var shapedevents = dataShaper.ShapeData(sortedevents, eventVendorParameters.Fields);

            return await PagedList<Entity>.ToPagedList(shapedevents, eventVendorParameters.PageNumber, eventVendorParameters.PageSize);
        }

        /// <summary>
        /// Gets the event by identifier.
        /// </summary>
        /// <param name="eventId">The event identifier.</param>
        /// <returns></returns>
        public async Task<Events> GetEventById(int eventId)
        {
            var getEventParams = new object[] {
                new MySqlParameter("@limit", null),
                new MySqlParameter("@offset", null),
                new MySqlParameter("@value", eventId),
                new MySqlParameter("@fromDate", null),
                new MySqlParameter("@toDate", null),
                new MySqlParameter("@ApprovalStatusId",null),
                 new MySqlParameter("@IsForVendor", false),
                new MySqlParameter("@IsForEvent", true)
            };

            var events = await FindAll("CALL SpSelectActiveEvent(@limit, @offset, @value, @ApprovalStatusId, @IsForVendor, @IsForEvent, @fromDate, @toDate)", getEventParams).ToListAsync();
            return events.FirstOrDefault();
        }

        /// <summary>
        /// Creates the event.
        /// </summary>
        /// <param name="event">The event.</param>
        public void CreateEvent(Events events)
        {
            Create(events);
        }

        /// <summary>
        /// Updates the event.
        /// </summary>
        /// <param name="event">The event.</param>
        public void UpdateEvent(Events events)
        {
            Update(events);
        }

        /// <summary>
        /// Deletes the event.
        /// </summary>
        /// <param name="event">The event.</param>
        public void DeleteEvent(Events events)
        {
            Delete(events);
        }
    }
}
