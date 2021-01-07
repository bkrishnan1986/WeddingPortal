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
using Happy.Weddings.Vendor.Core.DTO.Responses.SuggestionList;
using Happy.Weddings.Vendor.Core.DTO.Requests.SuggesstionList;
using Happy.Weddings.Vendor.Core.DTO.Requests.SuggestionList;

namespace Happy.Weddings.Vendor.Data.Repository
{
    /// <summary>
    /// SubscriptionPlansRepository
    /// </summary>
    /// <seealso cref="Happy.Weddings.Vendor.Data.Repository.RepositoryBase{Happy.Weddings.Vendor.Core.Entity.Subscription}" />
    /// <seealso cref="Happy.Weddings.Vendor.Core.Repository.ISubscriptionPlansRepository" />
    public class SuggestionListRepository : RepositoryBase<Suggestionlist>, ISuggestionListRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<SuggestionListResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<SuggestionListResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoriesRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public SuggestionListRepository(
            VendorContext repositoryContext,
            IMapper mapper,
            ISortHelper<SuggestionListResponse> sortHelper,
            IDataShaper<SuggestionListResponse> dataShaper)
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
        public async Task<PagedList<Entity>> GetAllSuggestionLists(SuggestionListParameter suggestionListParameter)
        {
            {
                var getSubscriptionsParams = new object[] {
                new MySqlParameter("@p_IsForVendor", suggestionListParameter.IsForVendor),
                new MySqlParameter("@p_IsForSubscription", suggestionListParameter.IsForSubscription),
                new MySqlParameter("@p_IsForSingleSuggestion", suggestionListParameter.IsForSingleSuggestion),
                  new MySqlParameter("@p_Value", suggestionListParameter.Value),
                new MySqlParameter("@p_ApprovalStatus", suggestionListParameter.ApprovalStatus)
              
            };
                var subscriptions = await FindAll("CALL SpSelectActiveSuggestionlist(@p_IsForVendor, @p_IsForSubscription,@p_IsForSingleSuggestion, @p_Value, @p_ApprovalStatus)", getSubscriptionsParams).ToListAsync();
                var mappedSubscriptions = subscriptions.AsQueryable().ProjectTo<SuggestionListResponse>(mapper.ConfigurationProvider);
                var sortedSubscriptions = sortHelper.ApplySort(mappedSubscriptions, suggestionListParameter.OrderBy);
                var shapedSubscriptions = dataShaper.ShapeData(sortedSubscriptions, suggestionListParameter.Fields);

                return await PagedList<Entity>.ToPagedList(shapedSubscriptions, suggestionListParameter.PageNumber, suggestionListParameter.PageSize);

            }

        }
        /// <summary>
        /// Gets the subscriptionPlan by identifier.
        /// </summary>
        /// <param name="SuggestionListId">The story identifier.</param>
        /// <returns></returns>
        public async Task<Suggestionlist> GetSuggestionListById(int SuggestionListId)
        {
            {
                var getSubscriptionsParams = new object[] {
                new MySqlParameter("@p_IsForVendor", false),
                new MySqlParameter("@p_IsForSubscription", false),
                new MySqlParameter("@p_IsForSingleSuggestion", true),
                  new MySqlParameter("@p_Value", SuggestionListId),
                new MySqlParameter("@p_ApprovalStatus", null)

            };
                var subscriptions = await FindAll("CALL SpSelectActiveSuggestionlist(@p_IsForVendor, @p_IsForSubscription,@p_IsForSingleSuggestion, @p_Value, @p_ApprovalStatus)", getSubscriptionsParams).ToListAsync();
                return subscriptions.FirstOrDefault();
            }
        }

        /// <summary>
        /// Creates the SubscriptionPlan.
        /// </summary>
        /// <param name="story">The story.</param>
        public void CreateSuggestionList(Suggestionlist suggestionList)
        {

            Create(suggestionList);
        }

        /// <summary>
        /// Updates the SubscriptionPlan.
        /// </summary>
        /// <param name="suggestionList">The SubscriptionPlan.</param>
        public void UpdateSuggestionList(Suggestionlist suggestionList)
        {

            Update(suggestionList);
        }
    }
}

