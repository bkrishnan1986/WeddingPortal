using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Vendor.Branch;
using Happy.Weddings.Gateway.Core.DTO.Vendor.Branches;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Vendor
{
    public interface IBranchService
    {
        Task<APIResponse> GetAllBranches(BranchParameters branchParameters);
        Task<APIResponse> DeleteBranch(int branchId);
        Task<APIResponse> UpdateBranch(int branchId, UpdateBranchRequest request);
        Task<APIResponse> CreateBranch(CreateBranchRequest request);
    }
}
