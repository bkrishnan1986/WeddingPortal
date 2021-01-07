using Happy.Weddings.Vendor.Core.DTO.Requests.Branch;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.Branch
{
    public class UpdateBranchCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the service question request.
        /// </summary>
        /// <value>
        /// The service question request.
        /// </value>
        public UpdateBranchRequest BranchRequest { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateBranchCommand"/> class.
        /// </summary>
        /// <param name="branchRequest">The servicequestionrequest.</param>
        public UpdateBranchCommand(int branchId, UpdateBranchRequest branchRequest)
        {
            Id = branchId;
            BranchRequest = branchRequest;
        }
    }
}
