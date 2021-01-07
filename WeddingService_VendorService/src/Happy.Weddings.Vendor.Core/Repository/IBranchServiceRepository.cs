using System.Collections.Generic;
using System.Threading.Tasks;
using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.BranchServiceOffered;
using Happy.Weddings.Vendor.Core.DTO.Responses.BranchServiceOffered;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Repository
{
    public interface IBranchServiceRepository : IRepositoryBase<Branchserviceoffered>
    {
        /// <summary>
        /// Gets  branchservice.
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        Task<PagedList<Domain.Entity>> GetBranchServiceOfferedById(BranchServiceParameters branchServiceParameters);
        Task<List<BranchServiceResponse>> GetBranchServiceOfferedByServiceId(int serviceId);

        /// <summary>
        /// Creates the branchservice.
        /// </summary>
        /// <param name="branchserviceoffered">The branchservice.</param>
        void CreateBranchServices(Branchserviceoffered branchserviceoffered);

        /// <summary>
        /// Updates the branchservice.
        /// </summary>
        /// <param name="branchserviceoffered">The branchservice.</param>
        void UpdateBranchServices(Branchserviceoffered branchserviceoffered);
    }
}
