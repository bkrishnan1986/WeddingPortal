#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  01-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | CreateUserProfilePermissionProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using Happy.Weddings.Identity.Core.DTO.Requests.Profile;

#endregion

namespace Happy.Weddings.Identity.Core.Profile.Profile
{
    /// <summary>
    /// Automapper profile for create user profile permission.
    /// </summary>
    public class CreateUserProfilePermissionProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserProfilePermissionProfile"/> class.
        /// </summary>
        public CreateUserProfilePermissionProfile()
        {
            CreateMap<ProfilePermission, Entity.Profilepermission>()
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
