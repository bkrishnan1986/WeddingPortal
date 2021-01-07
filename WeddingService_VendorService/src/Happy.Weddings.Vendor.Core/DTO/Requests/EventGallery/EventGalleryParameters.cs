#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  13-Aug-2020 |    Reji Salooja B S    | Created and implemented. 
//              |                        | EventGalleryParameters
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using System;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.EventGallery
{
    public class EventGalleryParameters : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventGalleryParameters"/> class.
        /// </summary>
        public EventGalleryParameters()
        {
            OrderBy = "EventName";
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
