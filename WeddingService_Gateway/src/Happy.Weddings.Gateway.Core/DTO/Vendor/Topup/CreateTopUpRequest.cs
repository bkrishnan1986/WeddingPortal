using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.Topup
{
    /// <summary>
    /// This Class is used to map CreateVendorSubscriptionRequest
    /// </summary>
    public class CreateTopUpRequest
    {

        /// <summary>
        /// Gets or sets the type of the top up.
        /// </summary>
        /// <value>
        /// The type of the top up.
        /// </value>
        public int TopUpType { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the gstpercentage.
        /// </summary>
        /// <value>
        /// The gstpercentage.
        /// </value>
        public int? Gstpercentage { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public int CreatedBy { get; set; }
    }
}
