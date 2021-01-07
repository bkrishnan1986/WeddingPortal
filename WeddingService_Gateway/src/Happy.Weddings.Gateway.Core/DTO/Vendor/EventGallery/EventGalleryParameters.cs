using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.EventGallery
{
    public class EventGalleryParameters : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventGalleryParameters"/> class.
        /// </summary>
        public EventGalleryParameters()
        {
            //OrderBy = "EventName";
        }
        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// Converts to date.
        /// </summary>
        /// <value>
        /// To date.
        /// </value>
        public DateTime? ToDate { get; set; }
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
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int Value { get; set; }
    }
}
