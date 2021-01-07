#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | OffersParameter --class
//----------------------------------------------------------------------------------------------

#endregion File Header
using Happy.Weddings.Vendor.Core.Domain;
using System;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.Offers
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
            OrderBy = "OfferName";
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


