#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | AssetRepository class.
//----------------------------------------------------------------------------------------------

#endregion File Header

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.Asset;
using Happy.Weddings.Vendor.Core.DTO.Responses.Asset;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Helpers;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Data.Repository
{
    /// <summary>
    ///Asset Repository
    /// </summary>
    public class AssetRepository : RepositoryBase<Assets>, IAssetRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<AssetResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<AssetResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>

        public AssetRepository(VendorContext repositoryContext, IMapper mapper, ISortHelper<AssetResponse> sortHelper,
                                       IDataShaper<AssetResponse> dataShaper) : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }


        /// <summary>
        /// Creates the assets.
        /// </summary>
        /// <param name="assets">The assets.</param>
        public void CreateAssets(Assets assets)
        {
            Create(assets);
        }

        /// <summary>
        /// Update the assets.
        /// </summary>
        /// <param name="assets">The assets.</param>
        public void UpdateAssets(Assets assets)
        {

            Update(assets);
        }

        /// <summary>
        /// Deletes the assets.
        /// </summary>
        /// <param name="assets">The assets.</param>
        public void DeleteAssets(Assets assets)
        {
            Delete(assets);
        }
        /// <summary>
        /// Gets the Assets by identifier.
        /// </summary>
        /// <param name="serviceId">The services identifier.</param>
        /// <returns></returns>

        public async Task<Assets> GetAssetsById(int AssetId)
        {
            var getAssetsParams = new object[] {
                new MySqlParameter("@p_SearchKeyword", "Id"),
                new MySqlParameter("@p_Value", AssetId),
                new MySqlParameter("@p_Limit", null),
                new MySqlParameter("@p_Offset", null),
                new MySqlParameter("@p_FromDate", null),
                new MySqlParameter("@p_ToDate", null)
            };
            var asset = await FindAll("CALL SpSelectActiveAsset(@p_Limit, @p_Offset, @p_SearchKeyword,@p_Value, @p_FromDate, @p_ToDate)",
                getAssetsParams).ToListAsync();
            return asset.FirstOrDefault();
        }


        /// <summary>
        /// Gets all Assets.
        /// </summary>
        /// <param name="assetParameters">The Asset parameters.</param>
        /// <returns></returns>
        public async Task<PagedList<Entity>> GetAllAssets(AssetParameters assetParameters)
        {

            var getAssetsParams = new object[] {
                new MySqlParameter("@p_limit", assetParameters.PageSize),
                new MySqlParameter("@p_offset", (assetParameters.PageNumber - 1) * assetParameters.PageSize),
                new MySqlParameter("@p_searchKeyword", assetParameters.SearchKeyword),
                  new MySqlParameter("@p_Value", assetParameters.Value),
                new MySqlParameter("@p_fromDate", assetParameters.FromDate),
                new MySqlParameter("@p_toDate", assetParameters.ToDate)
            };
            var assets = await FindAll("CALL SpSelectActiveAsset(@p_limit, @p_offset, @p_searchKeyword,@p_Value @p_fromDate, @p_toDate)", getAssetsParams).ToListAsync();

            var mappedassets = assets.AsQueryable().ProjectTo<AssetResponse>(mapper.ConfigurationProvider);
            var sortedassets = sortHelper.ApplySort(mappedassets, assetParameters.OrderBy);
            var shapedassets = dataShaper.ShapeData(sortedassets, assetParameters.Fields);

            return await PagedList<Entity>.ToPagedList(shapedassets, assetParameters.PageNumber, assetParameters.PageSize);
        }
    }
}

