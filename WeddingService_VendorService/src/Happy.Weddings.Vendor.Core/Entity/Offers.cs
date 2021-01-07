#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | Offers --class
//----------------------------------------------------------------------------------------------

#endregion File Header
using System;
using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.Entity
{
    /// <summary>
    /// Offers
    /// </summary>
    public partial class Offers
    {
        public Offers()
        {
            Subscriptionoffer = new HashSet<Subscriptionoffer>();
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

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
        public int Conditions { get; set; }

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


        /// <summary>
        /// Gets or sets the type navigation.
        /// </summary>
        /// <value>
        /// The type navigation.
        /// </value>
        public virtual Multidetail TypeNavigation { get; set; }

        /// <summary>
        /// Gets or sets the validity unit navigation.
        /// </summary>
        /// <value>
        /// The validity unit navigation.
        /// </value>
        public virtual Multidetail ValidityUnitNavigation { get; set; }

        /// <summary>
        /// Gets or sets the subscriptionoffer.
        /// </summary>
        /// <value>
        /// The subscriptionoffer.
        /// </value>
        public virtual ICollection<Subscriptionoffer> Subscriptionoffer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Multidetail ConditionsNavigation { get; set; }
    }
}

