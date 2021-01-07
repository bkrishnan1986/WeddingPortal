using Happy.Weddings.Vendor.Core.DTO.Requests.ProfilePicture;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.ProfilePicture
{
    public class CreateProfielPictureCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public CreateProfilePictureRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateEventCommand"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public CreateProfielPictureCommand(CreateProfilePictureRequest request)
        {
            Request = request;
        }
    }
}
