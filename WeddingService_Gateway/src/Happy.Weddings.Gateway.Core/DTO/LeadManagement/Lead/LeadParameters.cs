using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead
{
    public class LeadParameters : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeadParameters"/> class.
        /// </summary>
        public LeadParameters()
        {
            //OrderBy = "LeadId";
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
