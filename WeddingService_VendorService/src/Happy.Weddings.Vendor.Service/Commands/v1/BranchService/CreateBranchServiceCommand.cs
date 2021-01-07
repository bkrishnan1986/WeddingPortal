using Happy.Weddings.Vendor.Core.DTO.Requests.BranchServiceOffered;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.BranchService
{
    public class CreateBranchServiceCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the service question request.
        /// </summary>
        /// <value>
        /// The service question request.
        /// </value>
        public CreateBranchServiceRequest BranchServiceRequest { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateServiceQuestionCommand"/> class.
        /// </summary>
        /// <param name="servicequestionrequest">The servicequestionrequest.</param>
        public CreateBranchServiceCommand(CreateBranchServiceRequest branchServiceRequest)
        {
            BranchServiceRequest = branchServiceRequest;
        }
    }
}
