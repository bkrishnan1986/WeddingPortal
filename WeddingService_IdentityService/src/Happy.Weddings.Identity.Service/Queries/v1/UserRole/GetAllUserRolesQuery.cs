#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | GetAllUserRolesQuery class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using MediatR;
using Happy.Weddings.Identity.Core.DTO.Responses;
using Happy.Weddings.Identity.Core.DTO.Requests.Profile;
using Happy.Weddings.Identity.Core.DTO.Requests.UserRole;

#endregion

namespace Happy.Weddings.Identity.Service.Queries.v1.UserRole
{
    /// <summary>
    /// Query for getting roles
    /// </summary>
    public class GetAllUserRolesQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the role parameters.
        /// </summary>
        /// <value>
        /// The role parameters.
        /// </value>
        public UserRoleParameters RoleParameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllUserRolesQuery"/> class.
        /// </summary>
        /// <param name="roleParameters">The role parameters.</param>
        public GetAllUserRolesQuery(UserRoleParameters roleParameters)
        {
            RoleParameters = roleParameters;
        }
    }
}
