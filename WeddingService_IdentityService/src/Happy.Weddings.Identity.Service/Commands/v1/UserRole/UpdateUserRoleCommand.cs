#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | UpdateUserRoleCommand class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using MediatR;
using Happy.Weddings.Identity.Core.DTO.Responses;
using Happy.Weddings.Identity.Core.DTO.Requests.Profile;
using Happy.Weddings.Identity.Core.DTO.Requests.UserRole;

#endregion

namespace Happy.Weddings.Identity.Service.Commands.v1.UserRole
{
    /// <summary>
    /// Command class for update user role.
    /// </summary>
    public class UpdateUserRoleCommand: IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the user role identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public UpdateUserRoleRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserRoleCommand"/> class.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <param name="request">The request.</param>
        public UpdateUserRoleCommand(int roleId,UpdateUserRoleRequest request)
        {
            Request = request;
            Id = roleId;
        }
    }
}
