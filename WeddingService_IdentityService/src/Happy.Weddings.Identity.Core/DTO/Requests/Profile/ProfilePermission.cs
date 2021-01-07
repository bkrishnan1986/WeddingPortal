#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  01-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | ProfilePermission class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;

#endregion

namespace Happy.Weddings.Identity.Core.DTO.Requests.Profile
{
    public class ProfilePermission
    {
        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the profile permissions.
        /// </summary>
        /// <value>
        /// The profile permissions.
        /// </value>
        public string ProfilePermissions { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
    }
}
