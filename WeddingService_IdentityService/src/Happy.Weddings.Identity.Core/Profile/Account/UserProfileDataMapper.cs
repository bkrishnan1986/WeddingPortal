#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | UpdateAccountPortionProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using Happy.Weddings.Identity.Core.DTO.Responses.Profile;

#endregion

namespace Happy.Weddings.Identity.Core.Profile.Account
{
    /// <summary>
    /// Automapper profile for create new profile response.
    /// </summary>
    public class UserProfileDataMapper : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfileDataMapper"/> class.
        /// </summary>
        public UserProfileDataMapper()
        {
            CreateMap<Entity.Profile,UserProfile>();
        }
    }
}
