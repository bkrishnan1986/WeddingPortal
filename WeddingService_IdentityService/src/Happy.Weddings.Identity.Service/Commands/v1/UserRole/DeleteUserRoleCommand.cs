#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | DeleteUserRoleCommand class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using MediatR;
using Happy.Weddings.Identity.Core.DTO.Responses;

#endregion

namespace Happy.Weddings.Identity.Service.Commands.v1.UserRole
{
    /// <summary>
    /// Command class for delete/deactivate user role.
    /// </summary>
    public class DeleteUserRoleCommand:IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Profile identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteUserRoleCommand"/> class.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        public DeleteUserRoleCommand(int roleId)
        {
            Id = roleId;
        }
    }
}
