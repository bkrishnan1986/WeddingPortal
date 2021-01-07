#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | RoleParameters class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using Happy.Weddings.Identity.Core.Domain;

#endregion

namespace Happy.Weddings.Identity.Core.DTO.Requests.Role
{
    /// <summary>
    /// Filters for getting roles.
    /// </summary>
    public class RoleParameters : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleParameters"/> class.
        /// </summary>
        public RoleParameters()
        {
            OrderBy = "Title";
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
        /// Gets or sets the value keyword.
        /// </summary>
        public string Value { get; set; }
    }
}
