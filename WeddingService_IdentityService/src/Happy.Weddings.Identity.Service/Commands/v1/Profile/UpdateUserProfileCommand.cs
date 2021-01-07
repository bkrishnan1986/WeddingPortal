#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | UpdateUserProfileCommand class.
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
    /// Command class for update user profile.
    /// </summary>
    public class UpdateUserProfileCommand: IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the user profile identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public UpdateUserProfileRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserProfileCommand"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="profileId">Profile Id</param>
        public UpdateUserProfileCommand(int profileId,UpdateUserProfileRequest request)
        {
            Request = request;
            Id = profileId;
        }
    }
}
