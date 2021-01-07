#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | ServiceSubscriptionsParameter --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using System;
using Happy.Weddings.Vendor.Core.Domain;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.ServiceSubscription
{
    /// <summary>
    /// This Class is used to map Benefits Response
    /// </summary>
    public class ServiceSubscriptionsParameter : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BenefitsParameter"/> class.
        /// </summary>
        public ServiceSubscriptionsParameter()
        {
            OrderBy = "Subscription";
        }



        /// <summary>
        /// Gets or sets a value indicating whether this instance is for single service subscription.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for single service subscription; otherwise, <c>false</c>.
        /// </value>
        public bool IsForSingleServiceSubscription { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is for service.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for service; otherwise, <c>false</c>.
        /// </value>
        public bool IsForService { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether this instance is for subscription.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for subscription; otherwise, <c>false</c>.
        /// </value>
        public bool IsForSubscription { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public decimal Value { get; set; }


        /// <summary>
        /// Gets or sets the approval status.
        /// </summary>
        /// <value>
        /// The approval status.
        /// </value>
        public int ApprovalStatus { get; set; }

        /// <summary>
        /// Gets or sets the payment status.
        /// </summary>
        /// <value>
        /// The payment status.
        /// </value>
        public int PaymentStatus { get; set; }

        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        public DateTime FromDate { get; set; }

        /// <summary>
        /// Converts to date.
        /// </summary>
        /// <value>
        /// To date.
        /// </value>
        public DateTime ToDate { get; set; }

    }
}


