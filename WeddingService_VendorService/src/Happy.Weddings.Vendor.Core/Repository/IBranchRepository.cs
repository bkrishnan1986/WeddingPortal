using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.Branches;
using Happy.Weddings.Vendor.Core.DTO.Responses.Branch;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Repository
{
    /// <summary>
    ///  This interface is used to declare CRUD for the Branch
    /// </summary>
    /// <seealso cref="Happy.Weddings.Vendor.Core.Repository.IRepositoryBase{Happy.Weddings.Vendor.Core.Entity.Events}" />
    public interface IBranchRepository : IRepositoryBase<Branches>
    {
        /// <summary>
        /// Gets all events.
        /// </summary>
        /// <param name="eventParameters">The event parameters.</param>
        /// <returns></returns>
      //  Task<PagedList<Domain.Entity>> GetAllBranches(BranchParameters branchParameterss);
        Task<List<BranchDetailsResponse>> GetAllBranches(BranchParameters branchParameterss);

        /// <summary>
        /// Gets  branch.
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        Task<Branches> GetBranchByBranchId(int branchId);
        Task<List<BranchResponse>> GetBranchesByBranchId(int branchId);

        /// <summary>
        /// Creates the branch.
        /// </summary>
        /// <param name="branches">The branch.</param>
        void CreateBranch(List<Branches> branches);

        /// <summary>
        /// Updates the branch.
        /// </summary>
        /// <param name="branches">The branch.</param>
        void UpdateBranch(Branches branches);
        void DeleteBranch(Branches branches);

    }
}
