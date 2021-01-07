using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.Service
{
    public class SearchParameters : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchParameters"/> class.
        /// </summary>
        public SearchParameters()
        {
            //OrderBy = "Title";
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
