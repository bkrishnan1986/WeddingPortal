using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceQuestion;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.ServiceQuestion
{
    public class CreateServiceQuestionCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the service question request.
        /// </summary>
        /// <value>
        /// The service question request.
        /// </value>
        public CreateServiceQuestionRequest ServiceQuestionRequest { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateServiceQuestionCommand"/> class.
        /// </summary>
        /// <param name="servicequestionrequest">The servicequestionrequest.</param>
        public CreateServiceQuestionCommand(CreateServiceQuestionRequest servicequestionrequest)
        {
            ServiceQuestionRequest = servicequestionrequest;
        }
    }
}
