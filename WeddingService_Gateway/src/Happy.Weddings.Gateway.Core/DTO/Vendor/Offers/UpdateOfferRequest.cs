using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.Offers
{
    /// <summary>
    /// This Class is used to map Update Offer Request
    /// </summary>
    public class UpdateOfferRequest
    {
        /// <summary>
        /// Gets or sets the name of the offer.
        /// </summary>
        /// <value>
        /// The name of the offer.
        /// </value>
        public string OfferName { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public int Type { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the validity.
        /// </summary>
        /// <value>
        /// The validity.
        /// </value>
        public int Validity { get; set; }

        /// <summary>
        /// Gets or sets the validity unit.
        /// </summary>
        /// <value>
        /// The validity unit.
        /// </value>
        public int ValidityUnit { get; set; }

        /// <summary>
        /// Gets or sets the vendor identifier.
        /// </summary>
        /// <value>
        /// The vendor identifier.
        /// </value>
        public int? VendorId { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        public int? UpdatedBy { get; set; }
    }
}
