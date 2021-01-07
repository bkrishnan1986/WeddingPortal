#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | UpdateUserProfileRequest class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

#endregion

using System.Collections.Generic;

namespace Happy.Weddings.Identity.Core.DTO.Requests.Profile
{
    /// <summary>
    /// Requset class/model for update user profile.
    /// </summary>
    public class UpdateUserProfileRequest : ProfileAttribute
    {
        /// <summary>
        /// Gets or sets updated by.
        /// </summary>
        public int UpdatedBy { get; set; }
    }
}