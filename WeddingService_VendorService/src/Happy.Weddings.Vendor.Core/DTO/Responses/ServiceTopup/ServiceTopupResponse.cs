#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  22-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | ServiceTopupResponse --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using System;

namespace Happy.Weddings.Vendor.Core.DTO.Responses.ServiceTopup
{
    /// <summary>
    /// This Class is used to map Vendor Subscriptions Response
    /// </summary>
    public class ServiceTopupResponse
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the service identifier.
        /// </summary>
        /// <value>
        /// The service identifier.
        /// </value>
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }

        /// <summary>
        /// Gets or sets the top up identifier.
        /// </summary>
        /// <value>
        /// The top up identifier.
        /// </value>
        public int TopUpId { get; set; }
        public string TopUpName { get; set; }
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
        public string PaymentStatusValue { get; set; }
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
