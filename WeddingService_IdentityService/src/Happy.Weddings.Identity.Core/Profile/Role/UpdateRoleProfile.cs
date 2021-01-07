#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | UpdateRoleProfile class.
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
    /// Automapper profile for update role.
    /// </summary>
    public class UpdateRoleProfile:AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateRoleProfile"/> class.
        /// </summary>
        public UpdateRoleProfile()
        {
            CreateMap<UpdateUserRoleRequest, Rolesettings>()
                .ForMember(x => x.UpdatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
