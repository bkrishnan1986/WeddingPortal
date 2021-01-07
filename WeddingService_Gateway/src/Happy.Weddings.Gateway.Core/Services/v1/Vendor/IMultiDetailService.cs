using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Vendor.MultiDetail;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Vendor
{
    public interface IMultiDetailService
    {
        Task<APIResponse> DeleteMultiDetails(int multidetailId);
        Task<APIResponse> UpdateMultiDetails(int multidetailId, UpdateMultiDetailsRequest request);
        Task<APIResponse> CreateMultiDetails(CreateMultiDetailsRequest request);
        Task<APIResponse> GetMultiDetailsById(string code);
        Task<APIResponse> GetMultiDetails(MultiDetailParameters multiDetailParameters);
    }
}
