#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | CreateUserProfileCommand class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using MediatR;
using Happy.Weddings.Identity.Core.DTO.Responses;
using Happy.Weddings.Identity.Core.DTO.Requests.Profile;

#endregion

namespace Happy.Weddings.Identity.Service.Commands.v1.Profile
{
    /// <summary>
    /// Command class for create user class.
    /// </summary>
    public class CreateUserProfileCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public CreateUserProfileRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserProfileCommand"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public CreateUserProfileCommand(CreateUserProfileRequest request)
        {
            Request = request;
        }
    }
}
