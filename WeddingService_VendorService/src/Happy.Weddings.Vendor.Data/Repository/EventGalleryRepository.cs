#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  12-Aug-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | EventGalleryRepository --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.EventGallery;
using Happy.Weddings.Vendor.Core.DTO.Responses.EventGallery;
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
    public class EventGalleryRepository : RepositoryBase<Gallery>, IEventGalleryRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The eventgallery sort helper
        /// </summary>
        private ISortHelper<EventGalleryResponse> sortHelper;

        /// <summary>
        /// The eventgallery data shaper
        /// </summary>
        private IDataShaper<EventGalleryResponse> dataShaper;

        public EventGalleryRepository(
                VendorContext repositoryContext,
                IMapper mapper,
                ISortHelper<EventGalleryResponse> sortHelper,
                IDataShaper<EventGalleryResponse> dataShaper)
                : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Gets event gallery by vendor
        /// </summary>
        /// <param name="eventGalleryParameters"></param>
        /// <returns></returns>
        public async Task<PagedList<Entity>> GetEventGalleryByVendorId(EventGalleryParameters eventGalleryParameters)
        {
            var getEventsParams = new object[] {
                new MySqlParameter("@limit", eventGalleryParameters.PageSize),
                new MySqlParameter("@offset", (eventGalleryParameters.PageNumber - 1) * eventGalleryParameters.PageSize),
                new MySqlParameter("@fromDate", eventGalleryParameters.FromDate),
                new MySqlParameter("@toDate", eventGalleryParameters.ToDate),
                new MySqlParameter("@isForVendor", eventGalleryParameters.IsForVendor),
                new MySqlParameter("@isForEvent", eventGalleryParameters.IsForEvent),
                new MySqlParameter("@value", eventGalleryParameters.Value)
            };

            var eventgallery = await FindAll("CALL SpSelectActiveGallery(@limit, @offset, @value, @isForVendor, @isForEvent, @fromDate, @toDate)", getEventsParams).ToListAsync();
            var mappedeventgallery = eventgallery.AsQueryable().ProjectTo<EventGalleryResponse>(mapper.ConfigurationProvider);
            var sortedeventgallery = sortHelper.ApplySort(mappedeventgallery, eventGalleryParameters.OrderBy);
            var shapedeventgallery = dataShaper.ShapeData(sortedeventgallery, eventGalleryParameters.Fields);

            return await PagedList<Entity>.ToPagedList(shapedeventgallery, eventGalleryParameters.PageNumber, eventGalleryParameters.PageSize);
        }
    }
}
