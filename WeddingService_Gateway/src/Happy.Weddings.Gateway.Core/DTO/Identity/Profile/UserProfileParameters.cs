#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | UserProfileParameters class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;

#endregion

namespace Happy.Weddings.Gateway.Core.DTO.Identity.Profile
{
    public class UserProfileParameters : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfileParameters"/> class.
        /// </summary>
        public UserProfileParameters()
        {
            //OrderBy = "FirstName";
        }

        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// Gets or sets to date.
        /// </summary>
        public DateTime? ToDate { get; set; }

        /// <summary>
        /// Gets or sets the search keyword.
        /// </summary>
        public string SearchKeyword { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public string UserId { get; set; }

    }
}
