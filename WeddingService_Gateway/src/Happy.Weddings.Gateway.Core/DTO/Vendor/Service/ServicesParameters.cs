namespace Happy.Weddings.Gateway.Core.DTO.Vendor.Service
{
    public class ServicesParameters 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServicesParameters"/> class.
        /// </summary>
        public ServicesParameters()
        {
            //OrderBy = "Title";
        }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is for single service.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for single service; otherwise, <c>false</c>.
        /// </value>
        public bool IsForSingleService { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is for vendor.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for vendor; otherwise, <c>false</c>.
        /// </value>
        public bool IsForVendor { get; set; }
    }
}
