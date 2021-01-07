using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.Offers
{
    /// <summary>
    /// This Class is used to map Offers Parameter
    /// </summary>
    public class OffersParameter : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OffersParameter"/> class.
        /// </summary>
        public OffersParameter()
        {
            //OrderBy = "OfferName";
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public decimal Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is for single offer.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for single offer; otherwise, <c>false</c>.
        /// </value>
        public bool IsForSingleOffer { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is for vendor.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for vendor; otherwise, <c>false</c>.
        /// </value>
        public bool IsForVendor { get; set; }
    }
}
