#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  07-Dec-2020 |    Aravind        | Created and implemented. 
//              |                   | LeadParameters class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using Happy.Weddings.LeadManagement.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead
{
    public class LeadStatusParameter : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeadParameters"/> class.
        /// </summary>
        public LeadStatusParameter()
        {
            OrderBy = "Id desc";
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
        /// Gets or sets the value for search keyword.
        /// </summary>
        public string Value { get; set; }

    }
}

