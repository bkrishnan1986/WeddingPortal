﻿#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  21-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | CreateServiceSubscriptionRequest --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using System;
using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.ServiceSubscription
{
    /// <summary>
    /// This Class is used to map CreateVendorSubscriptionRequest
    /// </summary>
    public class CreateServiceSubscriptionRequest
    {
        public List<ServiceSubscription> ServiceSubscription { get; set; }
    }

    public class ServiceSubscription
    {
        /// <summary>
        /// Gets or sets the service identifier.
        /// </summary>
        /// <value>
        /// The service identifier.
        /// </value>
        public int ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the subscription.
        /// </summary>
        /// <value>
        /// The subscription.
        /// </value>
        public int Subscription { get; set; }

        /// <summary>
        /// Gets or sets the subscribed on.
        /// </summary>
        /// <value>
        /// The subscribed on.
        /// </value>
        public DateTime SubscribedOn { get; set; }

        /// <summary>
        /// Gets or sets the expiry.
        /// </summary>
        /// <value>
        /// The expiry.
        /// </value>
        public DateTime Expiry { get; set; }

        /// <summary>
        /// Gets or sets the paid amount.
        /// </summary>
        /// <value>
        /// The paid amount.
        /// </value>
        public decimal PaidAmount { get; set; }

        /// <summary>
        /// Gets or sets the payment status.
        /// </summary>
        /// <value>
        /// The payment status.
        /// </value>
        public int PaymentStatus { get; set; }

        /// <summary>
        /// Gets or sets the vallet balance.
        /// </summary>
        /// <value>
        /// The vallet balance.
        /// </value>
        public decimal? WalletBalance { get; set; }
        /// <summary>
        /// Gets or sets the wallet status.
        /// </summary>
        /// <value>
        /// The wallet status.
        /// </value>
        public int WalletStatus { get; set; }
        public string WalletStatusName { get; set; }

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