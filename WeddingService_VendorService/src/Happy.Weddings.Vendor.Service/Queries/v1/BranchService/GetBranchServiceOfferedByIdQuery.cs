using Happy.Weddings.Vendor.Core.DTO.Requests.BranchServiceOffered;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.BranchService
{
    public class GetBranchServiceOfferedByIdQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the branch identifier.
        /// </summary>
        /// <value>
        /// The branch type identifier.
        /// </value>
        public BranchServiceParameters branchServiceParameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetBranchServiceOfferedByIdQuery"/> class.
        /// </summary>
        public GetBranchServiceOfferedByIdQuery(BranchServiceParameters branchServiceParameters)
        {
            this.branchServiceParameters = branchServiceParameters;
        }
    }
}
