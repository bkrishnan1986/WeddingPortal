﻿#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | CreateSubscriptionBenefitRequest --class
//----------------------------------------------------------------------------------------------

#endregion File Header
using System;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionBenefits
{
    /// <summary>
    /// This Class is used to map Create Subscription Benefit Request
    /// </summary>
    public class CreateSubscriptionBenefitRequest
    {
        /// <summary>
        /// Gets or sets the subscription identifier.
        /// </summary>
        /// <value>
        /// The subscription identifier.
        /// </value>
        public int SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the benefit.
        /// </summary>
        /// <value>
        /// The benefit.
        /// </value>
        public int Benefit { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int? Count { get; set; }

        /// <summary>
        /// Gets or sets the approval status.
        /// </summary>
        /// <value>
        /// The approval status.
        /// </value>
        public int ApprovalStatus { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public int CreatedBy { get; set; }

    }
}
