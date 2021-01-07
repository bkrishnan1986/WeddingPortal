#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | UpdateUserProfilePortionProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using Happy.Weddings.Identity.Core.DTO.Requests.Profile;

#endregion

namespace Happy.Weddings.Identity.Core.Profile.Profile
{
    /// <summary>
    /// Automapper profile for update user profile portion.
    /// </summary>
    public class UpdateUserProfilePortionProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserProfilePortionProfile"/> class.
        /// </summary>
        public UpdateUserProfilePortionProfile()
        {
            CreateMap<UpdateUserProfilePortionRequest, Entity.Profile>()
                .ForMember(x => x.UpdatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}