#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  05-Aug-2020 |    Reji Salooja B S    | Created and implemented. 
//              |                        | EventParameters
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using System;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.Event
{
    /// <summary>
    ///  This class is used to map Event Parameters
    /// </summary>
    /// <seealso cref="Happy.Weddings.Vendor.Core.Domain.QueryStringParameters" />
    public class EventParameters : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventParameters"/> class.
        /// </summary>
        public EventParameters()
        {
            OrderBy = "EventName";
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
        /// Gets or sets Event Name
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
       public string Location { get; set; }      
        /// <summary>
        /// Gets or sets the approval status.
        /// </summary>
        /// <value>
        /// The approval status.
        /// </value>
        public int ApprovalStatus { get; set; }
        /// <summary>
        /// Gets or sets the type of the review.
        /// </summary>
        /// <value>
        /// The type of the review.
        /// </value>
        public int ReviewType { get; set; }               

    }
}
