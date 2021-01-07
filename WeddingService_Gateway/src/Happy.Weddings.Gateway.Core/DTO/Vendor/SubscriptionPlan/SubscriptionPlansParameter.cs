using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.SubscriptionPlan
{
    /// <summary>
    /// This Class is used to map SubscriptionPlans Parameter
    /// </summary>
    public class SubscriptionPlansParameter : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubcriptionPlansParameter"/> class.
        /// </summary>
        public SubscriptionPlansParameter()
        {
            //OrderBy = "Name";
        }

        /// <summary>
        /// Gets or sets to Value.
        /// </summary>
        public decimal Value { get; set; }

        public bool IsForSubscription { get; set; }

        public bool IsForParentSubscription { get; set; }

        public int ApprovalStatus { get; set; }
    }
}
