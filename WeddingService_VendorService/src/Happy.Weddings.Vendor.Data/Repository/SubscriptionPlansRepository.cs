#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | SubscriptionPlansRepository --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.Vendor.Core.DTO.Responses.SubscriptionPlans;
using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionPlans;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Helpers;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Data.Repository
{
    /// <summary>
    /// SubscriptionPlansRepository
    /// </summary>
    /// <seealso cref="Happy.Weddings.Vendor.Data.Repository.RepositoryBase{Happy.Weddings.Vendor.Core.Entity.Subscription}" />
    /// <seealso cref="Happy.Weddings.Vendor.Core.Repository.ISubscriptionPlansRepository" />
    public class SubscriptionPlansRepository : RepositoryBase<Subscription>, ISubscriptionPlansRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<SubscriptionPlansResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<SubscriptionPlansResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoriesRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public SubscriptionPlansRepository(
            VendorContext repositoryContext,
            IMapper mapper,
            ISortHelper<SubscriptionPlansResponse> sortHelper,
            IDataShaper<SubscriptionPlansResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Gets all subscriptionPlan.
        /// </summary>
        /// <param name="subscriptionPlansParameter">The story parameters.</param>
        /// <returns></returns>
        public async Task<PagedList<Entity>> GetAllSubscriptionPlans(SubscriptionPlansParameter subscriptionPlansParameter)
        {
            {
                var getSubscriptionsParams = new object[] {
                new MySqlParameter("@p_IsForSubscription", subscriptionPlansParameter.IsForSubscription),
                new MySqlParameter("@p_IsForParentSubscription", subscriptionPlansParameter.IsForParentSubscription),
                new MySqlParameter("@p_Value", subscriptionPlansParameter.Value),
                new MySqlParameter("@p_ApprovalStatus", subscriptionPlansParameter.ApprovalStatus)
            };
                var subscriptions = await FindAll("CALL SpSelectActiveSubscription(@p_IsForSubscription,@p_IsForParentSubscription, @p_Value,@p_ApprovalStatus)", getSubscriptionsParams).ToListAsync();
                var mappedSubscriptions = subscriptions.AsQueryable().ProjectTo<SubscriptionPlansResponse>(mapper.ConfigurationProvider);
                var sortedSubscriptions = sortHelper.ApplySort(mappedSubscriptions, subscriptionPlansParameter.OrderBy);
                var shapedSubscriptions = dataShaper.ShapeData(sortedSubscriptions, subscriptionPlansParameter.Fields);

                return await PagedList<Entity>.ToPagedList(shapedSubscriptions, subscriptionPlansParameter.PageNumber, subscriptionPlansParameter.PageSize);
             
        }

    }
    /// <summary>
    /// Gets the subscriptionPlan by identifier.
    /// </summary>
    /// <param name="SubscriptionPlanId">The story identifier.</param>
    /// <returns></returns>
    public async Task<Subscription> GetSubscriptionPlanById(int SubscriptionPlanId)
    {
            var getSubscriptionsParams = new object[] {
                new MySqlParameter("@p_IsForSubscription",true),
                new MySqlParameter("@p_Value", SubscriptionPlanId),
                new MySqlParameter("@p_ApprovalStatus", null)
            };
            var subscriptions = await FindAll("CALL SpSelectActiveSubscription(@p_IsForSubscription, @p_Value,@p_ApprovalStatus)", getSubscriptionsParams).ToListAsync();
            return subscriptions.FirstOrDefault();
    }   

    public async Task<List<SubscriptionPlansResponse>> GetSubscriptionPlans(int subscriptionPlanId)
    {
        var result = await FindByCondition(sb => sb.Id.Equals(subscriptionPlanId))
                //   .Include(sl => sl.Subscriptionbenefit)
                   .ProjectTo<SubscriptionPlansResponse>(mapper.ConfigurationProvider)
                   .ToListAsync();
            return result;
    }   

        /// <summary>
        /// Creates the SubscriptionPlan.
        /// </summary>
        /// <param name="story">The story.</param>
        public void CreateSubscriptionPlan(Subscription subscriptionPlans)
        {

            Create(subscriptionPlans);
        }

        /// <summary>
        /// Updates the SubscriptionPlan.
        /// </summary>
        /// <param name="subscriptionPlans">The SubscriptionPlan.</param>
        public void UpdateSubscriptionPlan(Subscription subscriptionPlans)
        {

            Update(subscriptionPlans);
        }    
    }
}

