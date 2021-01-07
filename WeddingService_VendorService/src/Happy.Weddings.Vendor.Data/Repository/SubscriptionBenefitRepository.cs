#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | SubscriptionBenefitsRepository --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using AutoMapper; 
using AutoMapper.QueryableExtensions;
using Happy.Weddings.Vendor.Core.DTO.Responses.SubscriptionBenefits;
using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionBenefits;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Helpers;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;

namespace Happy.Weddings.Vendor.Data.Repository
{
    /// <summary>
    /// This class is used to implement CRUD for the SubscriptionBenefits
    /// </summary>
    public class SubscriptionBenefitsRepository : RepositoryBase<Subscriptionbenefit>, IsubscriptionBenefitRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<SubscriptionBenefitsResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<SubscriptionBenefitsResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoriesRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public SubscriptionBenefitsRepository(
            VendorContext repositoryContext,
            IMapper mapper,
            ISortHelper<SubscriptionBenefitsResponse> sortHelper,
            IDataShaper<SubscriptionBenefitsResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Gets all subscriptionBenefit.
        /// </summary>
        /// <param name="subscriptionBenefitsParameter">The story parameters.</param>
        /// <returns></returns>
        public async Task<PagedList<Entity>> GetAllSubscriptionBenefits(SubscriptionBenefitsParameter subscriptionBenefitsParameter)
        {
            {
                var getBenefitsParams = new object[] {
                       new MySqlParameter("@p_IsForSingleData", subscriptionBenefitsParameter.IsForSingleData),
                       new MySqlParameter("@p_IsForSubscription", subscriptionBenefitsParameter.IsForSubscription),
                       new MySqlParameter("@p_IsForBenefit", subscriptionBenefitsParameter.IsForBenefit),
                       new MySqlParameter("@p_Value", subscriptionBenefitsParameter.Value),
                       new MySqlParameter("@p_ApprovalStatus", subscriptionBenefitsParameter.ApprovalStatus)
            };
                var subscriptionBenefits = await FindAll("CALL SpSelectActiveSubscriptionBenefit(@p_IsForSingleData, @p_IsForSubscription, @p_IsForBenefit, @p_Value, @p_ApprovalStatus)", getBenefitsParams).ToListAsync();
                var mappedSubscriptionBenefits = subscriptionBenefits.AsQueryable().ProjectTo<SubscriptionBenefitsResponse>(mapper.ConfigurationProvider);
                var sortedSubscriptionBenefits = sortHelper.ApplySort(mappedSubscriptionBenefits, subscriptionBenefitsParameter.OrderBy);
                var shapedSubscriptionBenefits = dataShaper.ShapeData(sortedSubscriptionBenefits, subscriptionBenefitsParameter.Fields);

                return await PagedList<Entity>.ToPagedList(shapedSubscriptionBenefits, subscriptionBenefitsParameter.PageNumber, subscriptionBenefitsParameter.PageSize);

            }
        }
        public async Task<List<SubscriptionBenefitsResponse>> GetAllSubscriptionBenefitsBySubsId(SubscriptionBenefitsParameter subscriptionBenefitsParameter)
        {
            var subsBenefit = FindByCondition(subsbenefit => subsbenefit.Active == Convert.ToInt16(true))
                               .Where(o => o.SubscriptionId == subscriptionBenefitsParameter.Value)
                               .ProjectTo<SubscriptionBenefitsResponse>(mapper.ConfigurationProvider).ToList();

            return subsBenefit;

        }
        /// <summary>
        /// Filters the by date.
        /// </summary>
        /// <param name="leadCollections">The lead datas.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        //private void FilterByDate(ref IQueryable<LeadDataCollectionResponse> leadCollections, DateTime? fromDate, DateTime? toDate)
        //{
        //    if (!leadCollections.Any())
        //        return;

        //    if (fromDate != null)
        //    {
        //        leadCollections = leadCollections.Where(s => s.CreatedAt >= fromDate);
        //    }
        //    if (toDate != null)
        //    {
        //        leadCollections = leadCollections.Where(s => s.CreatedAt <= toDate);
        //    }
        //}
        /// <summary>
        /// Gets the subscriptionBenefit by identifier.
        /// </summary>
        /// <param name="SubscriptionBenefitId">The story identifier.</param>
        /// <returns></returns>
        public async Task<Subscriptionbenefit> GetSubscriptionBenefitById(int SubscriptionBenefitId)
        {
            var getBenefitsParams = new object[] {

                       new MySqlParameter("@p_IsForSingleData", true),
                       new MySqlParameter("@p_IsForSubscription", false),
                       new MySqlParameter("@p_IsForBenefit",false),
                       new MySqlParameter("@p_Value", SubscriptionBenefitId),
                       new MySqlParameter("@p_ApprovalStatus", null)
                };

            var subscriptionBenefit = await FindAll("CALL SpSelectActiveSubscriptionBenefit(@p_IsForSingleData, @p_IsForSubscription, @p_IsForBenefit, @p_Value, @p_ApprovalStatus)", getBenefitsParams).ToListAsync();
            return subscriptionBenefit.FirstOrDefault();
        }

        public async Task<List<SubscriptionBenefitsResponse>> GetSubscriptionBenefitsById(int SubscriptionBenefitId)
        {
            var result = await FindByCondition(sb => sb.SubscriptionId.Equals(SubscriptionBenefitId))
                    .ProjectTo<SubscriptionBenefitsResponse>(mapper.ConfigurationProvider)
                    .ToListAsync();
            return result;
        }

        /// <summary>
        /// Creates the subscriptionBenefit.
        /// </summary>
        /// <param name="SubscriptionBenefit">The SubscriptionBenefit.</param>
        public void CreateSubscriptionBenefit(Subscriptionbenefit subscriptionBenefits)
        {
            Create(subscriptionBenefits);
        }

        /// <summary>
        /// Updates the subscriptionBenefit.
        /// </summary>
        /// <param name="subscriptionPlans">The SubscriptionPlan.</param>
        public void UpdateSubscriptionBenefit(Subscriptionbenefit subscriptionBenefits)
        {

            Update(subscriptionBenefits);
        }

    }
}

