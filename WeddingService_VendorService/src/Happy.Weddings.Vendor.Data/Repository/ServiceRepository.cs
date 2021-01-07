#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | ServiceRepository class.
//----------------------------------------------------------------------------------------------

#endregion File Header

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.Service;
using Happy.Weddings.Vendor.Core.DTO.Responses.Service;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Helpers;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Data.Repository
{
    /// <summary>
    /// ServiceRepository
    /// </summary>
    /// <seealso cref="Happy.Weddings.Vendor.Data.Repository.RepositoryBase{Happy.Weddings.Vendor.Core.Entity.Services}" />
    /// <seealso cref="Happy.Weddings.Vendor.Core.Repository.IServiceRepository" />
    public class ServiceRepository : RepositoryBase<Services>, IServiceRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<ServiceResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<ServiceResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoriesRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>

        public ServiceRepository(VendorContext repositoryContext,IMapper mapper,ISortHelper<ServiceResponse> sortHelper,
                                       IDataShaper<ServiceResponse> dataShaper) : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }


        /// <summary>
        /// Creates the services.
        /// </summary>
        /// <param name="services">The Service.</param>
        public void CreateServices(List<Services> services)
        {
            CreateRange(services);
        }

        /// <summary>
        /// Update the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void UpdateServices(Services services)
        {
           
            Update(services);
        }

        /// <summary>
        /// Deletes the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void DeleteServices(Services services)
        {
            Delete(services);
        }

        /// <summary>
        /// Gets the services by identifier.
        /// </summary>
        /// <param name="serviceId">The services identifier.</param>
        /// <returns></returns>
        
        public async Task<Services> GetServiceById(int serviceId)
        {
            var getServicesParams = new object[] {
                new MySqlParameter("@p_SearchKeyword", "Id"),
                new MySqlParameter("@p_Value", serviceId),
                new MySqlParameter("@p_Limit", null),
                new MySqlParameter("@p_Offset", null),
                new MySqlParameter("@p_FromDate", null),
                new MySqlParameter("@p_ToDate", null)
            };
            var services = await FindAll("CALL SpSelectActiveService(@p_Limit, @p_Offset, @p_SearchKeyword,@p_Value, @p_FromDate, @p_ToDate)",
                getServicesParams).ToListAsync();
            return services.FirstOrDefault();

        }

        /// <summary>
        /// Gets the services by vendor.
        /// </summary>
        /// <param name="vendorId">The services identifier.</param>
        /// <returns></returns>

      /*  public async Task<List<Services>> GetServicesofVendor(int vendorId)
        {
            var getServicesParams = new object[] {
                new MySqlParameter("@p_SearchKeyword", "VendorId"),
                new MySqlParameter("@p_Value", vendorId),
                new MySqlParameter("@p_Limit", null),
                new MySqlParameter("@p_Offset", null),
                new MySqlParameter("@p_FromDate", null),
                new MySqlParameter("@p_ToDate", null)
            };
            var services = await FindAll("CALL SpSelectActiveService(@p_Limit, @p_Offset, @p_SearchKeyword,@p_Value, @p_FromDate, @p_ToDate)",
                getServicesParams).ToListAsync();
            return services;
        }   */

        public async Task<List<ServiceDetailsResponse>> GetServicesofVendor(string vendorId)
        {
            return await FindByCondition(sc => sc.VendorId.Equals(vendorId) || sc.VendorName.Equals(vendorId))
                    .ProjectTo<ServiceDetailsResponse>(mapper.ConfigurationProvider)
                    .ToListAsync();
        }

        /// <summary>
        /// Gets all services.
        /// </summary>
        /// <param name="serviceParameters">The service parameters.</param>
        /// <returns></returns>
        //public async Task<PagedList<Entity>> GetAllServices(ServicesParameters serviceParameters)
        //{
        //    var getStoriesParams = new object[] {
        //        new MySqlParameter("@p_limit", serviceParameters.PageSize),
        //        new MySqlParameter("@p_offset", (serviceParameters.PageNumber - 1) * serviceParameters.PageSize),
        //        new MySqlParameter("@p_searchKeyword", serviceParameters.SearchKeyword),
        //          new MySqlParameter("@p_Value", serviceParameters.Value),
        //        new MySqlParameter("@p_fromDate", serviceParameters.FromDate),
        //        new MySqlParameter("@p_toDate", serviceParameters.ToDate)
        //    };
        //    var services = await FindAll("CALL SpSelectActiveService(@p_limit, @p_offset, @p_searchKeyword,@p_Value @p_fromDate, @p_toDate)", getStoriesParams).ToListAsync();
           
       
        //    var mappedServices = services.AsQueryable().ProjectTo<ServiceResponse>(mapper.ConfigurationProvider);
        //    var sortedServices = sortHelper.ApplySort(mappedServices, serviceParameters.OrderBy);
        //    var shapedServices = dataShaper.ShapeData(sortedServices, serviceParameters.Fields);

        //    return await PagedList<Entity>.ToPagedList(shapedServices, serviceParameters.PageNumber, serviceParameters.PageSize);
        //}

        public async Task<List<ServiceResposnseList>> GetAllServices(ServicesParameters serviceParameters)
        {
            var services = FindByCondition(ss => ss.Active == Convert.ToInt16(true)).ProjectTo<ServiceResposnseList>(mapper.ConfigurationProvider);
            SearchServicesByVendorId(ref services, serviceParameters);

            // FilterByDate(ref wallets, walletsParameter.FromDate, walletsParameter.ToDate);
            //var sortedWallets = sortHelper.ApplySort(services, serviceParameters.OrderBy);
            //var pagedWallets = sortedWallets
            //                   .Skip((serviceParameters.PageNumber - 1) * serviceParameters.PageSize)
            //                   .Take(serviceParameters.PageSize);

            var result = await services.ToListAsync();
            return result;
        }
        private void SearchServicesByVendorId(ref IQueryable<ServiceResposnseList> services, ServicesParameters serviceParameters)
        {
            if (serviceParameters.Value != null)
            {
                services = services.Where(ss => ss.VendorId.Equals(serviceParameters.Value) || ss.VendorName.Equals(serviceParameters.Value));                                    
            }
        }


        /// <summary>
        /// Search From all services.
        /// </summary>
        /// <param name="searchParameters">The search parameters.</param>
        /// <returns></returns>
        public async Task<PagedList<Entity>> SearchFromAllServices(SearchParameters searchParameters)
        {
            var getserviceParams = new object[] {
                new MySqlParameter("@p_limit", searchParameters.PageSize),
                new MySqlParameter("@p_offset", (searchParameters.PageNumber - 1) * searchParameters.PageSize),
                new MySqlParameter("@p_searchKeyword", searchParameters.SearchKeyword),
                new MySqlParameter("@p_serviceName", searchParameters.ServiceName),
                new MySqlParameter("@p_Budget", searchParameters.Budget),
                new MySqlParameter("@p_Location", searchParameters.Location),
                new MySqlParameter("@p_AvailabilityDate", searchParameters.AvailabilityDate)
            };
            var services = await FindAll("CALL SearchFromAllServices(@p_limit, @p_offset, @p_searchKeyword, @p_serviceName, @p_Budget,@p_Location,p_AvailabilityDate)", getserviceParams).ToListAsync();


            var mappedServices = services.AsQueryable().ProjectTo<ServiceResponse>(mapper.ConfigurationProvider);
            var sortedServices = sortHelper.ApplySort(mappedServices, searchParameters.OrderBy);
            var shapedServices = dataShaper.ShapeData(sortedServices, searchParameters.Fields);

            return await PagedList<Entity>.ToPagedList(shapedServices, searchParameters.PageNumber, searchParameters.PageSize);
        }
    }
}
