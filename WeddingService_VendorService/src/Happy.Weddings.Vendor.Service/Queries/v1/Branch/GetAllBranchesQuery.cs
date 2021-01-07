using Happy.Weddings.Vendor.Core.DTO.Requests.Branches;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.Branch
{
    public class GetAllBranchesQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the branch identifier.
        /// </summary>
        /// <value>
        /// The branch type identifier.
        /// </value>
        public BranchParameters branchParameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllBranchesQuery"/> class.
        /// </summary>
        public GetAllBranchesQuery(BranchParameters branchParameters)
        {
            this.branchParameters = branchParameters;
        }
    }
}
