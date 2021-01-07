#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  21-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | TopUpBenefitRepository --class
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
using Happy.Weddings.Vendor.Core.DTO.Responses.TopUps;
using Happy.Weddings.Vendor.Core.DTO.Requests.TopUpBenefit;
using System.Collections.Generic;
using System;

namespace Happy.Weddings.Vendor.Data.Repository
{
    /// <summary>
    /// TopUpBenefitRepository
    /// </summary>
    /// <seealso cref="Happy.Weddings.Vendor.Data.Repository.RepositoryBase{Happy.Weddings.Vendor.Core.Entity.Vendorsubscription}" />
    /// <seealso cref="Happy.Weddings.Vendor.Core.Repository.ITopUpRepository" />
    public class TopUpBenefitRepository : RepositoryBase<Topupbenefit>, ITopUpBenefitRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<TopUpBenefitResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<TopUpBenefitResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoriesRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public TopUpBenefitRepository(
            VendorContext repositoryContext,
            IMapper mapper,
            ISortHelper<TopUpBenefitResponse> sortHelper,
            IDataShaper<TopUpBenefitResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Gets all TopUpBenefits.
        /// </summary>
        /// <param name="topUpBenefitParameter">The TopUpBenefits parameters.</param>
        /// <returns></returns>
        public async Task<PagedList<Entity>> GetAllTopUpBenefits(TopUpBenefitParameter topUpBenefitParameter)
        {
            {
                var getvendorSubscriptionsParams = new object[] {
                new MySqlParameter("@p_IsForSingleData", topUpBenefitParameter.IsForSingleData),
                new MySqlParameter("@p_IsForTopUp", topUpBenefitParameter.IsForTopUp),
                new MySqlParameter("@p_IsForBenefit", topUpBenefitParameter.IsForBenefit),
                new MySqlParameter("@p_Value", topUpBenefitParameter.Value),
                new MySqlParameter("@p_ApprovalStatus", topUpBenefitParameter.ApprovalStatus)
            };
                var vendorsubscriptions = await FindAll("CALL SpSelectActiveTopUpBenefit(@p_IsForSingleData, @p_IsForTopUp, @p_IsForBenefit,@p_Value, @p_ApprovalStatus)", getvendorSubscriptionsParams).ToListAsync();
                var mappedVendorSubscriptions = vendorsubscriptions.AsQueryable().ProjectTo<TopUpBenefitResponse>(mapper.ConfigurationProvider);
                var sortedVendorSubscriptions = sortHelper.ApplySort(mappedVendorSubscriptions, topUpBenefitParameter.OrderBy);
                var shapedVendorSubscriptions = dataShaper.ShapeData(sortedVendorSubscriptions, topUpBenefitParameter.Fields);

                return await PagedList<Entity>.ToPagedList(shapedVendorSubscriptions, topUpBenefitParameter.PageNumber, topUpBenefitParameter.PageSize);

            }
        }

        public async Task<List<TopUpBenefitResponse>> GetAllTopUpBenefitsByTopupId(TopUpBenefitParameter topUpBenefitParameter)
        {
            var topBenefit = FindByCondition(topBenefit => topBenefit.Active == Convert.ToInt16(true))
                               .Where(o => o.TopUpId == topUpBenefitParameter.Value)
                               .ProjectTo<TopUpBenefitResponse>(mapper.ConfigurationProvider).ToList();

            return topBenefit;

        }
        /// <summary>
        /// Gets the TopUpBenefits by identifier.
        /// </summary>
        /// <param name="topupId">The TopUpBenefits identifier.</param>
        /// <returns></returns>
        public async Task<Topupbenefit> GetTopUpBenefitById(int topupBenefitId)

        {
            var getvendorSubscriptionsParams = new object[] {
                new MySqlParameter("@p_IsForSingleData", true),
                new MySqlParameter("@p_IsForTopUp", false),
                new MySqlParameter("@p_IsForBenefit", false),
                new MySqlParameter("@p_Value",topupBenefitId),
                new MySqlParameter("@p_ApprovalStatus", null)
            };
            var vendorsubscriptions = await FindAll("CALL SpSelectActiveTopUpBenefit(@p_IsForSingleData, @p_IsForTopUp, @p_IsForBenefit,@p_Value, @p_ApprovalStatus)", getvendorSubscriptionsParams).ToListAsync();
            return vendorsubscriptions.FirstOrDefault();
        }

        public async Task<List<TopUpBenefitResponse>> GetTopUpBenefitsById(int topupBenefitId)

        {
            var result = await FindByCondition(tb => tb.TopUpId.Equals(topupBenefitId))
                   .ProjectTo<TopUpBenefitResponse>(mapper.ConfigurationProvider)
                   .ToListAsync();
            return result;
        }

        /// <summary>
        /// Creates the TopUpBenefits.
        /// </summary>
        /// <param name="Vendorsubscription">The TopUpBenefits.</param>
        public void CreateTopUpBenefit(Topupbenefit topUpBenefit)
        {
            Create(topUpBenefit);
        }

        /// <summary>
        /// Updates the TopUpBenefits.
        /// </summary>
        /// <param name="subscriptionPlans">The TopUpBenefits.</param>
        public void UpdateTopUpBenefit(Topupbenefit topUpBenefit)
        {

            Update(topUpBenefit);
        }

    }
}

