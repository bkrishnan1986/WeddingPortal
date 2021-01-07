using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Vendor.MultiCode;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Vendor
{
    public interface IMultiCodeService
    {
        Task<APIResponse> DeleteMultiCode(string code);
        Task<APIResponse> UpdateMultiCode(string code, UpdateMultiCodeVendorRequest request);
        Task<APIResponse> CreateMultiCode(CreateMultiCodeVendorRequest request);
        Task<APIResponse> GetMultiCodeById(string code);
        Task<APIResponse> GetMultiCodes(MultiCodeParameters multiCodeParameters);
    }
}
