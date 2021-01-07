#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | CreateRoleProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using Happy.Weddings.Identity.Core.Entity;
using Happy.Weddings.Identity.Core.DTO.Requests.Role;
using Happy.Weddings.Identity.Core.DTO.Requests.UserRole;

#endregion

namespace Happy.Weddings.Identity.Core.Profile.Role
{
    /// <summary>
    /// Automapper profile for create role.
    /// </summary>
    public class CreateRoleProfile:AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRoleProfile"/> class.
        /// </summary>
        public CreateRoleProfile()
        {
            CreateMap<CreateUserRoleRequest, Rolesettings>()
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
