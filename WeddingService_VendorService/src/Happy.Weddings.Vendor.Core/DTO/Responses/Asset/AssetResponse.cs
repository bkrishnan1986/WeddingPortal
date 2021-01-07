#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | AssetResponse class.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Entity;
using System;

namespace Happy.Weddings.Vendor.Core.DTO.Responses.Asset
{
    /// <summary>
    /// AssetResponse
    /// </summary>
    public class AssetResponse
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the type of the asset.
        /// </summary>
        /// <value>
        /// The type of the asset.
        /// </value>
        public int AssetType { get; set; }
        /// <summary>
        /// Gets or sets the name of the asset.
        /// </summary>
        /// <value>
        /// The name of the asset.
        /// </value>
        public string AssetName { get; set; }
        /// <summary>
        /// Gets or sets the asset condition.
        /// </summary>
        /// <value>
        /// The asset condition.
        /// </value>
        public int AssetCondition { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public int Status { get; set; }
        /// <summary>
        /// Gets or sets the associated vendor service.
        /// </summary>
        /// <value>
        /// The associated vendor service.
        /// </value>
        public int? AssociatedVendorService { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>
        /// The unit.
        /// </value>
        public int Unit { get; set; }
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public decimal Quantity { get; set; }
        /// <summary>
        /// Gets or sets the vendor identifier.
        /// </summary>
        /// <value>
        /// The vendor identifier.
        /// </value>
        public int VendorId { get; set; }
        /// <summary>
        /// Gets or sets the active.
        /// </summary>
        /// <value>
        /// The active.
        /// </value>
        public byte Active { get; set; }
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
        /// Gets or sets the asset condition navigation.
        /// </summary>
        /// <value>
        /// The asset condition navigation.
        /// </value>
        public virtual Multidetail AssetConditionNavigation { get; set; }
        /// <summary>
        /// Gets or sets the asset type navigation.
        /// </summary>
        /// <value>
        /// The asset type navigation.
        /// </value>
        public virtual Multidetail AssetTypeNavigation { get; set; }
        /// <summary>
        /// Gets or sets the associated vendor service navigation.
        /// </summary>
        /// <value>
        /// The associated vendor service navigation.
        /// </value>
        public virtual Entity.Services AssociatedVendorServiceNavigation { get; set; }
        /// <summary>
        /// Gets or sets the status navigation.
        /// </summary>
        /// <value>
        /// The status navigation.
        /// </value>
        public virtual Multidetail StatusNavigation { get; set; }
        /// <summary>
        /// Gets or sets the unit navigation.
        /// </summary>
        /// <value>
        /// The unit navigation.
        /// </value>
        public virtual Multidetail UnitNavigation { get; set; }
    }
}
