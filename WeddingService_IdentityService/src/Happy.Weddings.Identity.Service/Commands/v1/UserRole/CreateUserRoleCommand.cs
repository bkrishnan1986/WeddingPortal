#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | CreateUserRoleCommand class.
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
    /// Command class for create user role command.
    /// </summary>
    public class CreateUserRoleCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public CreateUserRoleRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserRoleCommand"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public CreateUserRoleCommand(CreateUserRoleRequest request)
        {
            Request = request;
        }
    }
}
