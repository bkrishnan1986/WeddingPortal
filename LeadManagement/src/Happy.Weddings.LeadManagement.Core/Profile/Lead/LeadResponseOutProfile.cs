#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Oct-2020 |    Sumith C       | Created and implemented. 
//              |                   | CreateUserProfileResponseProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using Happy.Weddings.LeadManagement.Core.Entity;

#endregion

namespace Happy.Weddings.Identity.Core.Profile.Profile
{
    /// <summary>
    /// Automapper profile for create user profile out response.
    /// </summary>
    public class LeadResponseOutProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserProfileResponseProfile"/> class.
        /// </summary>
        public LeadResponseOutProfile()
        {
            CreateMap<Leadquote, LeadQuoteResponse>();
        }
    }
}