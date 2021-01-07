#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | VendorSubscriptionsResponse --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using System;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.ServiceSubscriptions
{
    /// <summary>
    /// This Class is used to map ServiceSubscriptionsResponse
    /// </summary>
    public class ServiceSubscriptionsResponse
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the vendor identifier.
        /// </summary>
        /// <value>
        /// The vendor identifier.
        /// </value>
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }

        /// <summary>
        /// Gets or sets the subscription.
        /// </summary>
        /// <value>
        /// The subscription.
        /// </value>
        public int Subscription { get; set; }
        public string SubscriptionName { get; set; }
        /// <summary>
        /// Gets or sets the subscribed on.
        /// </summary>
        /// <value>
        /// The subscribed on.
        /// </value>
        public DateTime? SubscribedOn { get; set; }

        /// <summary>
        /// Gets or sets the expiry.
        /// </summary>
        /// <value>
        /// The expiry.
        /// </value>
        public DateTime? Expiry { get; set; }

        /// <summary>
        /// Gets or sets the paid amount.
        /// </summary>
        /// <value>
        /// The paid amount.
        /// </value>
        public decimal? PaidAmount { get; set; }

        /// <summary>
        /// Gets or sets the payment status.
        /// </summary>
        /// <value>
        /// The payment status.
        /// </value>
        public int? PaymentStatus { get; set; }
        /// <summary>
        /// Gets or sets the payment status value.
        /// </summary>
        /// <value>
        /// The payment status value.
        /// </value>
        public string PaymentStatusValue { get; set; }

        /// <summary>
        /// Gets or sets the vallet balance.
        /// </summary>
        /// <value>
        /// The vallet balance.
        /// </value>
        public decimal? WalletBalance { get; set; }
        public int WalletStatus { get; set; }
        public string WalletStatusName { get; set; }

        /// <summary>
        /// Gets or sets the aproval status.
        /// </summary>
        /// <value>
        /// The aproval status.
        /// </value>
        public int ApprovalStatus { get; set; }
        public string ApprovalStatusValue { get; set; }

        /// <summary>
        /// Gets or sets the active.
        /// </summary>
        /// <value>
        /// The active.
        /// </value>
        public short Active { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        public int? UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>
        /// The updated at.
        /// </value>
        public DateTime? UpdatedAt { get; set; }
    }
}
