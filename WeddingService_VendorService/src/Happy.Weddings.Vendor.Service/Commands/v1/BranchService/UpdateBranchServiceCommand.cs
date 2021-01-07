using Happy.Weddings.Vendor.Core.DTO.Requests.BranchServiceOffered;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.BranchService
{
    public class UpdateBranchServiceCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int BranchId { get; set; }
        /// <summary>
        /// Gets or sets the service question request.
        /// </summary>
        /// <value>
        /// The service question request.
        /// </value>
        public UpdateBranchServiceRequest BranchServiceRequest { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateBranchServiceCommand"/> class.
        /// </summary>
        /// <param name="branchRequest">The servicequestionrequest.</param>
        public UpdateBranchServiceCommand(int branchId, UpdateBranchServiceRequest branchServiceRequest)
        {
            BranchId = branchId;
            BranchServiceRequest = branchServiceRequest;
        }
    }
}
