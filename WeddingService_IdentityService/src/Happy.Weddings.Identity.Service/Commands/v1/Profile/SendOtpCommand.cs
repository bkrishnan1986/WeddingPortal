using Happy.Weddings.Identity.Core.DTO.Requests.Profile;
using Happy.Weddings.Identity.Core.DTO.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Identity.Service.Commands.v1.Profile
{
    public class SendOtpCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the profile identifier.
        /// </summary>
        /// <value>
        /// The profile identifier.
        /// </value>
        public int ProfileId { get; set; }

        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public SendOtpRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendOtpCommand"/> class.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <param name="request">The request.</param>
        public SendOtpCommand(int profileId,SendOtpRequest request)
        {
            Request = request;
            ProfileId = profileId;
        }
    }
}
