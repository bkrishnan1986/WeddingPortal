#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | CreateRoleResponseProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using Happy.Weddings.Identity.Core.DTO.Responses.Role;
using Happy.Weddings.Identity.Core.Entity;

#endregion

namespace Happy.Weddings.Identity.Core.Profile.Profile
{
    /// <summary>
    /// Automapper profile for create role out response.
    /// </summary>
    public class CreateRoleResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRoleResponseProfile"/> class.
        /// </summary>
        public CreateRoleResponseProfile()
        {
            CreateMap<Rolesettings, RoleOutResponse>();
        }
    }
}
