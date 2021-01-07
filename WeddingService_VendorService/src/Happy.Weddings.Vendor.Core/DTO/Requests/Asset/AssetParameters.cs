#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  10-Aug-2020 |    Nithin M    | Created and implemented. 
//              |                         | AssetParameters
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using System;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.Asset
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
            OrderBy = "Asset";
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
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>

        /// <summary>
        /// Gets or sets the search keyword.
        /// </summary>
        public string SearchKeyword { get; set; }
    }
}
