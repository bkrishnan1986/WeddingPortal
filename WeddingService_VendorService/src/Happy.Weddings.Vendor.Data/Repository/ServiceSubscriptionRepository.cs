#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  23-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | ServiceSubscriptionsRepository --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Helpers;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Happy.Weddings.Vendor.Core.DTO.Responses.ServiceSubscriptions;
using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceSubscription;
using System.Collections.Generic;
using System;

namespace Happy.Weddings.Vendor.Data.Repository
{
    /// <summary>
    /// VendorSubscriptionsRepository
    /// </summary>
    /// <seealso cref="Happy.Weddings.Vendor.Data.Repository.RepositoryBase{Happy.Weddings.Vendor.Core.Entity.Vendorsubscription}" />
    /// <seealso cref="Happy.Weddings.Vendor.Core.Repository.ITopUpRepository" />
    public class ServiceSubscriptionsRepository : RepositoryBase<Servicesubscription>, IServiceSubscriptionRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<ServiceSubscriptionsResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<ServiceSubscriptionsResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoriesRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public ServiceSubscriptionsRepository(
            VendorContext repositoryContext,
            IMapper mapper,
            ISortHelper<ServiceSubscriptionsResponse> sortHelper,
            IDataShaper<ServiceSubscriptionsResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Gets all ServiceSubscriptions
        /// </summary>
        /// <param name="serviceSubscriptionsParameter">The ServiceSubscriptions parameters.</param>
        /// <returns></returns>
        //public async Task<PagedList<Entity>> GetAllServiceSubscriptions(ServiceSubscriptionsParameter serviceSubscriptionsParameter)
        //{
        //    {
        //        var getvendorSubscriptionsParams = new object[] {
        //        new MySqlParameter("@p_Limit", serviceSubscriptionsParameter.PageSize),
        //        new MySqlParameter("@p_Offset", (serviceSubscriptionsParameter.PageNumber - 1) * serviceSubscriptionsParameter.PageSize),
        //        new MySqlParameter("@p_IsForSingleServiceSubscription", serviceSubscriptionsParameter.IsForSingleServiceSubscription),
        //        new MySqlParameter("@p_IsForService", serviceSubscriptionsParameter.IsForService),
        //        new MySqlParameter("@p_IsForSubscription", serviceSubscriptionsParameter.IsForSubscription),
        //        new MySqlParameter("@p_ApprovalStatus", serviceSubscriptionsParameter.ApprovalStatus),
        //        new MySqlParameter("@p_PaymentStatus", serviceSubscriptionsParameter.PaymentStatus),
        //        new MySqlParameter("@p_Value", serviceSubscriptionsParameter.Value),
        //        new MySqlParameter("@p_FromDate", serviceSubscriptionsParameter.FromDate),
        //        new MySqlParameter("@p_ToDate", serviceSubscriptionsParameter.ToDate)
        //    }; 
        //        var servicesubscriptions = await FindAll("CALL SpSelectActiveServiceSubscription(@p_Limit, @p_Offset, @p_IsForSingleServiceSubscription,@p_IsForService,@p_IsForSubscription,@p_Value,@p_ApprovalStatus,@p_PaymentStatus, @p_FromDate, @p_ToDate)", getvendorSubscriptionsParams).ToListAsync();
        //        var mappedVendorSubscriptions = servicesubscriptions.AsQueryable().ProjectTo<ServiceSubscriptionsResponse>(mapper.ConfigurationProvider);
        //        var sortedVendorSubscriptions = sortHelper.ApplySort(mappedVendorSubscriptions, serviceSubscriptionsParameter.OrderBy);
        //        var shapedVendorSubscriptions = dataShaper.ShapeData(sortedVendorSubscriptions, serviceSubscriptionsParameter.Fields);

        //        return await PagedList<Entity>.ToPagedList(shapedVendorSubscriptions, serviceSubscriptionsParameter.PageNumber, serviceSubscriptionsParameter.PageSize);

        //    }
        //}

        public async Task<PagedList<Entity>> GetAllServiceSubscriptions(ServiceSubscriptionsParameter serviceSubscriptionsParameter)
        {
            var serviceSubscriptions = FindByCondition(x => x.Active == Convert.ToInt16(true)).ProjectTo<ServiceSubscriptionsResponse>(mapper.ConfigurationProvider);
            SearchByServiceSuubscriptions(ref serviceSubscriptions, serviceSubscriptionsParameter);
            var sortedServiceSubscriptions = sortHelper.ApplySort(serviceSubscriptions, serviceSubscriptionsParameter.OrderBy);
            FilterByDate(ref serviceSubscriptions, serviceSubscriptionsParameter.FromDate, serviceSubscriptionsParameter.ToDate);            
            var shapedServiceSubscriptions = dataShaper.ShapeData(sortedServiceSubscriptions, serviceSubscriptionsParameter.Fields);
            return await PagedList<Entity>.ToPagedList(shapedServiceSubscriptions, serviceSubscriptionsParameter.PageNumber, serviceSubscriptionsParameter.PageSize);
        }    

        private void SearchByServiceSuubscriptions(ref IQueryable<ServiceSubscriptionsResponse> serviceSubscriptions, ServiceSubscriptionsParameter serviceSubscriptionsParameter)
        {
            if (serviceSubscriptionsParameter.IsForSingleServiceSubscription == true)
            {
                serviceSubscriptions = serviceSubscriptions.Where(x => x.Id.Equals(serviceSubscriptionsParameter.Value));
            }
            else if (serviceSubscriptionsParameter.IsForService == true)
            {
                serviceSubscriptions = serviceSubscriptions.Where(x => x.ServiceId.Equals(serviceSubscriptionsParameter.Value));
            }
            else if (serviceSubscriptionsParameter.IsForSubscription == true)
            {
                serviceSubscriptions = serviceSubscriptions.Where(x => x.Subscription < serviceSubscriptionsParameter.Value);
            }
            if (serviceSubscriptionsParameter.ApprovalStatus > 0)
            {
                serviceSubscriptions = serviceSubscriptions.Where(x => x.ApprovalStatus == serviceSubscriptionsParameter.ApprovalStatus);
            }
            if (serviceSubscriptionsParameter.PaymentStatus > 0)
            {
                serviceSubscriptions = serviceSubscriptions.Where(x => x.PaymentStatus == serviceSubscriptionsParameter.PaymentStatus);
            }
        }

        private void FilterByDate(ref IQueryable<ServiceSubscriptionsResponse> serviceSubscriptions, DateTime? fromDate, DateTime? toDate)
        {
            if (!serviceSubscriptions.Any())
                return;

            if (fromDate != null && toDate == null)
            {
                serviceSubscriptions = serviceSubscriptions.Where(s => s.CreatedAt >= fromDate);
            }
            else if (toDate != null && fromDate == null)
            {

                serviceSubscriptions = serviceSubscriptions.Where(s => s.CreatedAt <= toDate);
            }
            else if (fromDate != null && toDate != null)
            {
                serviceSubscriptions = serviceSubscriptions.Where(s => s.CreatedAt >= fromDate && s.CreatedAt <= toDate);
            }
        }

        /// <summary>
        /// Gets the Servicesubscription by identifier.
        /// </summary>
        /// <param name="ServiceSubscriptionId">The Servicesubscription identifier.</param>
        /// <returns></returns>
        public async Task<Servicesubscription> GetServiceSubscriptionById(int ServiceSubscriptionId)
        {
            var getserviceSubscriptionsParams = new object[] {
                 new MySqlParameter("@p_Limit", null),
                new MySqlParameter("@p_Offset", null),
                new MySqlParameter("@p_IsForSingleServiceSubscription",true ),
                new MySqlParameter("@p_IsForService", null),
                new MySqlParameter("@p_IsForSubscription", null),
                new MySqlParameter("@p_ApprovalStatus", null),
                new MySqlParameter("@p_PaymentStatus", null),
                new MySqlParameter("@p_Value", ServiceSubscriptionId),
                new MySqlParameter("@p_FromDate", null),
                new MySqlParameter("@p_ToDate", null)
            };
            var servicesubscriptions = await FindAll("CALL SpSelectActiveServiceSubscription(@p_Limit, @p_Offset, @p_IsForSingleServiceSubscription,@p_IsForService,@p_IsForSubscription,@p_Value,@p_ApprovalStatus,@p_PaymentStatus, @p_FromDate, @p_ToDate)", getserviceSubscriptionsParams).ToListAsync();
            return servicesubscriptions.FirstOrDefault();
        }
        /// <summary>
        /// Creates the servicesubscription.
        /// </summary>
        /// <param name="servicesubscription">The vendorsubscriptions.</param>
        public void CreateServicesubscription(List<Servicesubscription> servicesubscription)
        {
            CreateRange(servicesubscription);
        }
        /// <summary>
        /// Updates the servicesubscription.
        /// </summary>
        /// <param name="servicesubscription">The SubscriptionPlan.</param>
        public void UpdateServiceSubscription(Servicesubscription servicesubscription)
        {

            Update(servicesubscription);
        }

    }
}

