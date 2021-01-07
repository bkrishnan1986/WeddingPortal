#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  10-Aug-2020 |   REJI SALOOJA B S     | Created and implemented. 
//              |                        | EventGalleryResponse    - class
//----------------------------------------------------------------------------------------------

#endregion File Header

using System;

namespace Happy.Weddings.Gateway.Core.DTO.Responses.EventGallery
{
    /// <summary>
    /// This class is used to map EventGalleryResponse
    /// </summary>
    public class EventGalleryResponse
    {
        /// <summary>
        /// Gets or sets the event identifier.
        /// </summary>
        /// <value>
        /// The event identifier.
        /// </value>
        public int EventId { get; set; }
        /// <summary>
        /// Gets or sets the cover photo.
        /// </summary>
        /// <value>
        /// The cover photo.
        /// </value>
        public string CoverPhoto { get; set; }        
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public string Location { get; set; }
        /// <summary>
        /// Gets or sets the event date.
        /// </summary>
        /// <value>
        /// The event date.
        /// </value>
        public DateTime EventDate { get; set; }
        /// <summary>
        /// Gets or sets the photo path.
        /// </summary>
        /// <value>
        /// The photo path.
        /// </value>
        public string PhotoPath { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>
        /// The tags.
        /// </value>        
        public string Tags { get; set; }
        /// <summary>
        /// Gets or sets the estimated price.
        /// </summary>
        /// <value>
        /// The estimated price.
        /// </value>
        public decimal? EstimatedPrice { get; set; }

    }
}
