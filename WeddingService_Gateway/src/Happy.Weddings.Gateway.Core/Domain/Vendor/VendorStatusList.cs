namespace Happy.Weddings.Gateway.Core.Domain.Vendor
{
    public class VendorStatusList
    {
        /// <summary>
        /// Gets or sets the vendor identifier.
        /// </summary>
        /// <value>
        /// The vendor identifier.
        /// </value>
        public string VendorId { get; set; }
        /// <summary>
        /// Gets or sets the name of the vendor.
        /// </summary>
        /// <value>
        /// The name of the vendor.
        /// </value>
        public string VendorName { get; set; }
        /// <summary>
        /// Gets or sets the vendor status.
        /// </summary>
        /// <value>
        /// The vendor status.
        /// </value>
        public int VendorStatus { get; set; }
        /// <summary>
        /// Gets or sets the name of the vendor status.
        /// </summary>
        /// <value>
        /// The name of the vendor status.
        /// </value>
        public string VendorStatusName { get; set; }
    }
}
