using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.SubscriptionLocation
{
    public class UpdateSubscriptionLocationRequest
    {
        /// <summary>
        /// Gets or sets the subscription identifier.
        /// </summary>
        /// <value>
        /// The subscription identifier.
        /// </value>
        public int SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the location identifier.
        /// </summary>
        /// <value>
        /// The location identifier.
        /// </value>
        public int LocationId { get; set; }

        /// <summary>
        /// Gets or sets the registration fee.
        /// </summary>
        /// <value>
        /// The registration fee.
        /// </value>
        public decimal? RegistrationFee { get; set; }

        /// <summary>
        /// Gets or sets the service fee.
        /// </summary>
        /// <value>
        /// The service fee.
        /// </value>
        public decimal? ServiceFee { get; set; }

        /// <summary>
        /// Gets or sets the gstpercentage.
        /// </summary>
        /// <value>
        /// The gstpercentage.
        /// </value>
        public int? Gstpercentage { get; set; }
        // public decimal TotalPrice { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        public int UpdatedBy { get; set; }
    }
}
