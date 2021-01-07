using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.SubscriptionLocation
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
            //OrderBy = "Name";
        }

        /// <summary>
        /// Gets or sets to Value.
        /// </summary>

        public bool IsForSubscription { get; set; }

        public bool IsForSingleSubscriptionLocation { get; set; }

        public bool IsForLocation { get; set; }

        public decimal Value { get; set; }
    }
}
