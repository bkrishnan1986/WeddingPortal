#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | GetAllUserProfilesQuery class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using MediatR;
using Happy.Weddings.Identity.Core.DTO.Responses;
using Happy.Weddings.Identity.Core.DTO.Requests.Profile;

#endregion

namespace Happy.Weddings.Identity.Service.Queries.v1.Profile
{
    /// <summary>
    /// Query for getting Profiles
    /// </summary>
    public class GetAllUserProfilesQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Profile parameters.
        /// </summary>
        public UserProfileParameters ProfileParameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllUserProfilesQuery"/> class.
        /// </summary>
        /// <param name="profileParameters">The Profile parameters.</param>
        public GetAllUserProfilesQuery(UserProfileParameters profileParameters)
        {
            ProfileParameters = profileParameters;
        }
    }
}
