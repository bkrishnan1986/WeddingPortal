#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | GetUserRoleQuery class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using MediatR;
using Happy.Weddings.Identity.Core.DTO.Responses;

#endregion

namespace Happy.Weddings.Identity.Service.Queries.v1.UserRole
{
    /// <summary>
    /// Query for getting a role
    /// </summary>
    public class GetUserRoleQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserRoleQuery"/> class.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        public GetUserRoleQuery(int roleId)
        {
            Id = roleId;
        }
    }
}
