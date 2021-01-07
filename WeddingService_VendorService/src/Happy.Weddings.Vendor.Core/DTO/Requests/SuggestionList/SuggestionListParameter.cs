﻿#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  21-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | SuggestionListParameter --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using System;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.SuggestionList
{
    /// <summary>
    /// This Class is used to map SubscriptionPlans Parameter
    /// </summary>
    public class SuggestionListParameter : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubcriptionPlansParameter"/> class.
        /// </summary>
        public SuggestionListParameter()
        {
            OrderBy = "Name";
        }

        /// <summary>
        /// Gets or sets to Value.
        /// </summary>
        public decimal Value { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether this instance is for vendor.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for vendor; otherwise, <c>false</c>.
        /// </value>
        public bool IsForVendor { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether this instance is for subscription.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for subscription; otherwise, <c>false</c>.
        /// </value>
        public bool IsForSubscription { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether this instance is for single suggestion.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for single suggestion; otherwise, <c>false</c>.
        /// </value>
        public bool IsForSingleSuggestion { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether [approval status].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [approval status]; otherwise, <c>false</c>.
        /// </value>
        public bool ApprovalStatus { get; set; }
    }
}


