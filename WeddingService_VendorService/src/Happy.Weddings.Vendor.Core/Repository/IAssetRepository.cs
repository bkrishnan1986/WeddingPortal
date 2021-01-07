#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | IAssetRepository interface.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.Asset;
using Happy.Weddings.Vendor.Core.Entity;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Core.Repository
{
    /// <summary>
    /// Interface For AssetRepository
    /// </summary>
   
    public interface IAssetRepository : IRepositoryBase<Assets>
    {
        void CreateAssets(Assets assets);
        void UpdateAssets(Assets assets);
        void DeleteAssets(Assets assets);
        Task<Assets> GetAssetsById(int AssetId);
        Task<PagedList<Domain.Entity>> GetAllAssets(AssetParameters assetParameters);
    }
}
