using Happy.Weddings.Vendor.Core.DTO.Requests.ProfilePicture;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.ProfilePicture
{
    public class UpdateProfilePictureCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the event identifier.
        /// </summary>
        /// <value>
        /// The event identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public UpdateProfilePictureRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateProfilePictureCommand" /> class.
        /// </summary>
        /// <param name="eventId">The multicode identifier.</param>
        /// <param name="Request">The request.</param>
        public UpdateProfilePictureCommand(int profilePictureId, UpdateProfilePictureRequest request)
        {
            Id = profilePictureId;
            Request = request;
        }
    }
}
