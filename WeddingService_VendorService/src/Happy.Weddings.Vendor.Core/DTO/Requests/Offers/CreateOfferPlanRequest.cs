#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | CreateOfferRequest --class
//----------------------------------------------------------------------------------------------

#endregion File Header

namespace Happy.Weddings.Vendor.Core.DTO.Requests.Offers
{
    /// <summary>
    /// This Class is used to map Create Offer Request
    /// </summary>
    public class CreateOfferRequest
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
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public int CreatedBy { get; set; }

    }
}
