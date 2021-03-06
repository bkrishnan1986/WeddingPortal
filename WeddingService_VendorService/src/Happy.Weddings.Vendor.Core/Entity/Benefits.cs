﻿#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | Benefits --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using System;
using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.Entity
{
    /// <summary>
    /// Benefits
    /// </summary>
    public partial class Benefits
    {
        public Benefits()
        {
            Subscriptionbenefit = new HashSet<Subscriptionbenefit>();
        }
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the benefit.
        /// </summary>
        /// <value>
        /// The benefit.
        /// </value>
        public string Benefit { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public decimal Value { get; set; }

        /// <summary>
        /// Gets or sets the benefit unit.
        /// </summary>
        /// <value>
        /// The benefit unit.
        /// </value>
        public int BenefitUnit { get; set; }

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
        public int UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>
        /// The updated at.
        /// </value>
        public DateTime UpdatedAt { get; set; }

        public virtual Multidetail BenefitUnitNavigation { get; set; }
        public virtual ICollection<Subscriptionbenefit> Subscriptionbenefit { get; set; }
    }
}
