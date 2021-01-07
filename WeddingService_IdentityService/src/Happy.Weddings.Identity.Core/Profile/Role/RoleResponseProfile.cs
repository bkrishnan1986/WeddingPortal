#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | RoleResponseProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using Happy.Weddings.Identity.Core.Entity;
using Happy.Weddings.Identity.Core.DTO.Responses.Role;

#endregion

namespace Happy.Weddings.Identity.Core.Profile.Role
{
    /// <summary>
    /// Automapper profile for role response.
    /// </summary>
    public class RoleResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleResponseProfile"/> class.
        /// </summary>
        public RoleResponseProfile()
        {
            CreateMap<Rolesettings, RoleResponse>();
        }
    }
}
