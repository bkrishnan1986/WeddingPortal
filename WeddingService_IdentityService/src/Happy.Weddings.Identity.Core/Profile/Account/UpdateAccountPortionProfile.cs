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
using Happy.Weddings.Identity.Core.DTO.Requests.Account;

#endregion

namespace Happy.Weddings.Identity.Core.Profile.Account
{
    /// <summary>
    /// Automapper profile for update account.
    /// </summary>
    public class UpdateAccountPortionProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateAccountPortionProfile"/> class.
        /// </summary>
        public UpdateAccountPortionProfile()
        {
            CreateMap<UpdateAccountsPortionRequest, Entity.Profile>()
                .ForMember(x => x.UpdatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
