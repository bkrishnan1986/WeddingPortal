using Happy.Weddings.Gateway.Core.DTO.ECommerce;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.ECommerce.MultiCode
{
    /// <summary>
    ///  This class is used to map MultiCode Parameters
    /// </summary>
    /// <seealso cref="QueryStringParameters" />
    public class MultiCodeParameters : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiCodeParameters"/> class.
        /// </summary>
        public MultiCodeParameters()
        {
            //OrderBy = "Code";
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
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the search keyword.
        /// </summary>
        public string SearchKeyword { get; set; }
    }
}
