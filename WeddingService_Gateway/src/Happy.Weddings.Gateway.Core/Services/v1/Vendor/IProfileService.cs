using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Vendor.ProfilePicture;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Vendor
{
    public interface IProfileService
    {
        Task<APIResponse> GetCategoryDetailsByVendorId(string vendorId);
        Task<APIResponse> UpdateCategoryDetails(int branchId, UpdateCategoryDetailsRequest request);
        Task<APIResponse> CreateCategoryDetails(CreateCategoryDetailsRequest request);
    }
}
