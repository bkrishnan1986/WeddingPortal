#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  02-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | UserProfilePermissionResponse class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using Happy.Weddings.Identity.Core.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;

#endregion

namespace Happy.Weddings.Identity.Core.DTO.Responses.Profile
{
    public class ProfileResponse : UserProfileResponse
    {
        /// <summary>
        /// Gets or sets the profilepermission.
        /// </summary>
        /// <value>
        /// The profilepermission.
        /// </value>
        public List<ProfilePermissionDTO> Profilepermission { get; set; }

        /// <summary>
        /// Gets or sets the company districts.
        /// </summary>
        /// <value>
        /// The company districts.
        /// </value>
        public List<CompanyDistrictsDTO> CompanyDistricts { get; set; }
    }
}
