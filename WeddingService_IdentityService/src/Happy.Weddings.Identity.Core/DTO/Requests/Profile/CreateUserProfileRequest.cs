#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | CreateProfileRequest class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using System.Collections.Generic;

#endregion

namespace Happy.Weddings.Identity.Core.DTO.Requests.Profile
{
    /// <summary>
    /// Request class/model for create user profile.
    /// </summary>
    public class CreateUserProfileRequest : ProfileAttribute
    {
        /// <summary>
        /// Gets or sets created by.
        /// </summary>
        public int CreatedBy { get; set; }
    }
}
