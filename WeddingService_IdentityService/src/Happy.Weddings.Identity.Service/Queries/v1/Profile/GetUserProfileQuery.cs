#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | GetUserProfileQuery class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using MediatR;
using Happy.Weddings.Identity.Core.DTO.Responses;

#endregion

namespace Happy.Weddings.Identity.Service.Queries.v1.Profile
{
    /// <summary>
    /// Query for getting a Profile
    /// </summary>
    public class GetUserProfileQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Profile identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserProfileQuery"/> class.
        /// </summary>
        /// <param name="profileId">The Profile identifier.</param>
        public GetUserProfileQuery(int profileId)
        {
            Id = profileId;
        }
    }
}
