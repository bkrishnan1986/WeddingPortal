#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  14-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | UserProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Happy.Weddings.Identity.Core.DTO.Responses.Profile
{
    public class UserProfile : UserProfileResponse
    {
        /// <summary>
        /// Gets or sets rolename.
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// Gets or sets permission.
        /// </summary>
        public string Permission { get; set; }
    }
}
