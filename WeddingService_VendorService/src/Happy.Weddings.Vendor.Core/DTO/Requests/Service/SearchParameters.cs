#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | SearchParameters class.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using System;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.Service
{

    public class SearchParameters : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchParameters"/> class.
        /// </summary>
        public SearchParameters()
        {
            OrderBy = "Title";
        }

        /// <summary>
        /// Gets or sets from ServiceName.
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Gets or sets from Budget.
        /// </summary>
        public decimal? Budget { get; set; }
        /// <summary>
        /// Gets or sets from Location.
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Gets or sets to AvailabilityDate.
        /// </summary>
        public DateTime? AvailabilityDate { get; set; }
        /// <summary>
        /// Gets or sets the search keyword.
        /// </summary>
        public string SearchKeyword { get; set; }
    }
}
