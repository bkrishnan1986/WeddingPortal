using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Vendor.Asset;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Vendor
{
    public interface IAssetService
    {
        Task<APIResponse> GetAllAssets(AssetParameters assetParameters);
        Task<APIResponse> GetAssetById(int assetId);
        Task<APIResponse> DeleteAsset(int assetId);
        Task<APIResponse> UpdateAsset(int assetId, UpdateAssetRequest request);
        Task<APIResponse> AddAssets(AddAssetRequest request);
    }
}
