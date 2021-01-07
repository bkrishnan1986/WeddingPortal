using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.ServiceTopup
{
    /// <summary>
    /// This Class is used to map SubscriptionPlans Parameter
    /// </summary>
    public class ServiceTopupParameter : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubcriptionPlansParameter"/> class.
        /// </summary>
        public ServiceTopupParameter()
        {
            //OrderBy = "Name";
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public decimal Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is for single service top up.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for single service top up; otherwise, <c>false</c>.
        /// </value>
        public bool IsForSingleServiceTopUp { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is for service.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for service; otherwise, <c>false</c>.
        /// </value>
        public bool IsForService { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is for top up.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for top up; otherwise, <c>false</c>.
        /// </value>
        public bool IsForTopUp { get; set; }

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
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// Converts to date.
        /// </summary>
        /// <value>
        /// To date.
        /// </value>
        public DateTime? ToDate { get; set; }
    }
}
