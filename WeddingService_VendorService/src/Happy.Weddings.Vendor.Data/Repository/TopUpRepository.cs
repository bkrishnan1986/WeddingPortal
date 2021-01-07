#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | TopUpRepository --class
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
using Happy.Weddings.Vendor.Core.DTO.Requests.TopUp;
using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Data.Repository
{
    /// <summary>
    /// VendorSubscriptionsRepository
    /// </summary>
    /// <seealso cref="Happy.Weddings.Vendor.Data.Repository.RepositoryBase{Happy.Weddings.Vendor.Core.Entity.Vendorsubscription}" />
    /// <seealso cref="Happy.Weddings.Vendor.Core.Repository.ITopUpRepository" />
    public class TopUpRepository : RepositoryBase<Topup>, ITopUpRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<TopUpsResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<TopUpsResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoriesRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public TopUpRepository(
            VendorContext repositoryContext,
            IMapper mapper,
            ISortHelper<TopUpsResponse> sortHelper,
            IDataShaper<TopUpsResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Gets all TopUps.
        /// </summary>
        /// <param name="topUpParameter">The TopUp parameters.</param>
        /// <returns></returns>
        public async Task<PagedList<Entity>> GetAllTopUps(TopUpParameter topUpParameter)
        {
            {
                var gettopUpsParams = new object[] {
                new MySqlParameter("@p_IsForSingleTopUp", topUpParameter.IsForSingleTopUp),
                new MySqlParameter("@p_Value", topUpParameter.Value)
            };
                var vendorsubscriptions = await FindAll("CALL SpSelectActiveTopUp(@p_IsForSingleTopUp, @p_Value)", gettopUpsParams).ToListAsync();
                var mappedVendorSubscriptions = vendorsubscriptions.AsQueryable().ProjectTo<TopUpsResponse>(mapper.ConfigurationProvider);
                var sortedVendorSubscriptions = sortHelper.ApplySort(mappedVendorSubscriptions, topUpParameter.OrderBy);
                var shapedVendorSubscriptions = dataShaper.ShapeData(sortedVendorSubscriptions, topUpParameter.Fields);

                return await PagedList<Entity>.ToPagedList(shapedVendorSubscriptions, topUpParameter.PageNumber, topUpParameter.PageSize);

            }
        }

        /// <summary>
        /// Gets the TopUp by identifier.
        /// </summary>
        /// <param name="topupId">The TopUp identifier.</param>
        /// <returns></returns>
        public async Task<Topup> GetTopUpById(int topupId)

        {
            var gettopUpsParams = new object[] {
                new MySqlParameter("@p_IsForSingleTopUp", true),
                new MySqlParameter("@p_Value", topupId)
            };
            var vendorsubscriptions = await FindAll("CALL SpSelectActiveTopUp(@p_IsForSingleTopUp, @p_Value)", gettopUpsParams).ToListAsync();
            return vendorsubscriptions.FirstOrDefault();
        }

        public async Task<List<TopUpsResponse>> GetTopUpsById(int topupId)  
        {
            var result = await FindByCondition(sb => sb.Id.Equals(topupId))
                    //.Include(sl => sl.Topupbenefit)
                    .ProjectTo<TopUpsResponse>(mapper.ConfigurationProvider)
                    .ToListAsync();
            return result;
        }

        /// <summary>
        /// Creates the topup.
        /// </summary>
        /// <param name="topup">The topup.</param>
        public void CreateTopUp(Topup topup)
        {
            Create(topup);
        }

        /// <summary>
        /// Updates the topup.
        /// </summary>
        /// <param name="topup">The topup.</param>
        public void UpdateTopUp(Topup topup)
        {

            Update(topup);
        }

    }
}

