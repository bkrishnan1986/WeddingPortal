#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | UpdateServiceTopupRequest --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using System;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.ServiceTopup
{
    /// <summary>
    /// This Class is used to map Update SubscriptionPlan Request
    /// </summary>
    public class UpdateServiceTopupRequest
    {
        /// <summary>
        /// Gets or sets the service identifier.
        /// </summary>
        /// <value>
        /// The service identifier.
        /// </value>
        public int ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the top up identifier.
        /// </summary>
        /// <value>
        /// The top up identifier.
        /// </value>
        public int TopUpId { get; set; }

        /// <summary>
        /// Gets or sets the top up on.
        /// </summary>
        /// <value>
        /// The top up on.
        /// </value>
        public DateTime TopUpOn { get; set; }

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
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        public int? UpdatedBy { get; set; }
    }
}
