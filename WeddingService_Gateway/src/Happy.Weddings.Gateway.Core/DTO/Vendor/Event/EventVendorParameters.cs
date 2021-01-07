using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.Event
{
    /// <summary>
    /// This class is used to map Event Parameters by Vendor
    /// </summary>
    /// <seealso cref="Happy.Weddings.Vendor.Core.Domain.QueryStringParameters" />
    public class EventVendorParameters : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventVendorParameters"/> class.
        /// </summary>
        public EventVendorParameters()
        {
            //OrderBy = "EventName";
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
        /// <value>
        /// The search keyword.
        /// </value>
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is for vendor.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for vendor; otherwise, <c>false</c>.
        /// </value>
        public bool IsForVendor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is for event.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for event; otherwise, <c>false</c>.
        /// </value>
        public bool IsForEvent { get; set; }

        /// <summary>
        /// Gets or sets the approval status.
        /// </summary>
        /// <value>
        /// The approval status.
        /// </value>
        public int ApprovalStatus { get; set; }

    }
}
