#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | BaseAssetRequest class.
//----------------------------------------------------------------------------------------------

#endregion File Header

namespace Happy.Weddings.Vendor.Core.DTO.Requests.Asset
{
    public class BaseAssetRequest
    {
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
    }
}
