#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | UserProfileResponseProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using Happy.Weddings.Identity.Core.DTO.Responses.Profile;

#endregion

namespace Happy.Weddings.Identity.Core.Profile.Profile
{
    /// <summary>
    /// Automapper profile for create profile response.
    /// </summary>
    public class UserProfileResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfileResponseProfile"/> class.
        /// </summary>
        public UserProfileResponseProfile()
        {
            CreateMap<Entity.Profile, UserProfileResponse>();
        }
    }
}
