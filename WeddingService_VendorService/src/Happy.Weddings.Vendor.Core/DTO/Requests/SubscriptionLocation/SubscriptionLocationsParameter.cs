#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  28-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | SubscriptionLocationsParameter --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using System;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionLocation
{
    /// <summary>
    /// This Class is used to map SubscriptionLocation Parameter
    /// </summary>
    public class SubscriptionLocationsParameter : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionLocationsParameter"/> class.
        /// </summary>
        public SubscriptionLocationsParameter()
        {
            OrderBy = "Name";
        }

        public bool IsForSubscription { get; set; }
        public bool IsForSingleSubscriptionLocation { get; set; }
        public bool IsForLocation { get; set; }
        public bool IsForCategory { get; set; }
        public bool IsForPackageType { get; set; }

        /// <summary>
        /// Gets or sets to Value.
        /// </summary>
        public decimal Value { get; set; }
        public decimal CategoryValue { get; set; }
        public decimal LocationValue { get; set; }
    }
}
