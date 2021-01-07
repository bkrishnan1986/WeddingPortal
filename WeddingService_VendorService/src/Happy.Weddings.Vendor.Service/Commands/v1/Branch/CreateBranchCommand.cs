using Happy.Weddings.Vendor.Core.DTO.Requests.Branch;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.Branch
{
    public class CreateBranchCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the service question request.
        /// </summary>
        /// <value>
        /// The service question request.
        /// </value>
        public CreateBranchRequest BranchRequest { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateServiceQuestionCommand"/> class.
        /// </summary>
        /// <param name="servicequestionrequest">The servicequestionrequest.</param>
        public CreateBranchCommand(CreateBranchRequest branchRequest)
        {
            BranchRequest = branchRequest;
        }
    }
}
