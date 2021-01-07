using System;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.Asset
{
    /// <summary>
    /// This class is used to map Asset Parameter
    /// </summary>
    public class AssetParameters : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BenefitsParameter"/> class.
        /// </summary>
        public AssetParameters()
        {
            //OrderBy = "Asset";
        }

        /// <summary>
        /// Gets or sets from Asset.
        /// </summary>
        public string Asset { get; set; }

        /// <summary>
        /// Gets or sets to Value.
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// Gets or sets to date.
        /// </summary>
        public DateTime? ToDate { get; set; }

        /// <summary>
        /// Gets or sets the search keyword.
        /// </summary>
        public string SearchKeyword { get; set; }
    }
}
