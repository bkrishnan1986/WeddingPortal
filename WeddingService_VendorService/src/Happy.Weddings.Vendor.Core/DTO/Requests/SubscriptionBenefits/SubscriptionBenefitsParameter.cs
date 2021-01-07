#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | SubscriptionBenefitsParameter --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionBenefits
{
    /// <summary>
    /// This Class is used to map Subscription Benefits Parameter
    /// </summary>
    public class SubscriptionBenefitsParameter : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BenefitsParameter"/> class.
        /// </summary>
        public SubscriptionBenefitsParameter()
        {
            OrderBy = "Subscription";
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public decimal? Value { get; set; }

        /// <summary>
        /// Gets or sets the approval status.
        /// </summary>
        /// <value>
        /// The approval status.
        /// </value>
        public int? ApprovalStatus { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is for single data.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for single data; otherwise, <c>false</c>.
        /// </value>
        public bool? IsForSingleData { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is for subscription.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for subscription; otherwise, <c>false</c>.
        /// </value>
        public bool? IsForSubscription { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is for benefit.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for benefit; otherwise, <c>false</c>.
        /// </value>
        public bool? IsForBenefit { get; set; }

    }
}


