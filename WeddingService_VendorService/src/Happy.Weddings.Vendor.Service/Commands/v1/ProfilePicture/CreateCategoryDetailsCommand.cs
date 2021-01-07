using Happy.Weddings.Vendor.Core.DTO.Requests.ProfilePicture;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.ProfilePicture
{
    public class CreateCategoryDetailsCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public CreateCategoryDetailsRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCategoryDetailsCommand"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public CreateCategoryDetailsCommand(CreateCategoryDetailsRequest request)
        {
            Request = request;
        }
    }
}
