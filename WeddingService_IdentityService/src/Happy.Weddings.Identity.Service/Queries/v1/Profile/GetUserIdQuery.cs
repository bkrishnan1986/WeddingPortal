using Happy.Weddings.Identity.Core.DTO.Requests.Profile;
using Happy.Weddings.Identity.Core.DTO.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Identity.Service.Queries.v1.Profile
{
    public class GetUserIdQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        public UserIdParameters Parameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserIdQuery"/> class.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        public GetUserIdQuery(UserIdParameters parameters)
        {
            Parameters = parameters;
        }
    }
}
