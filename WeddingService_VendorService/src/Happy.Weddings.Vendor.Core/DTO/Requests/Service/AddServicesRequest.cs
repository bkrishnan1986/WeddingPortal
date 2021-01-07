#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | AddServicesRequest class.
//----------------------------------------------------------------------------------------------

#endregion File Header
using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.Service
{
    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="AddServicesRequest"/> is active.
    /// </summary>
    /// <summary>
    public class AddServicesRequest
    {
        public List<BaseServiceList> Services { get; set; }
    }

        public class BaseServiceList
        {
            /// <summary>
            /// Gets or sets the type of the service.
            /// </summary>
            /// <value>
            /// The type of the service.
            /// </value>
            public int ServiceType { get; set; }
            /// <summary>
            /// Gets or sets the name of the service.
            /// </summary>
            /// <value>
            /// The name of the service.
            /// </value>
            public string ServiceName { get; set; }
            /// <summary>
            /// Gets or sets the description.
            /// </summary>
            /// <value>
            /// The description.
            /// </value>
            public string Description { get; set; }
            /// <summary>
            /// Gets or sets the experience.
            /// </summary>
            /// <value>
            /// The experience.
            /// </value>
            public float Experience { get; set; }
            /// <summary>
            /// Gets or sets the experience unit.
            /// </summary>
            /// <value>
            /// The experience unit.
            /// </value>
            public int ExperienceUnit { get; set; }
            /// <summary>
            /// Gets or sets the award.
            /// </summary>
            /// <value>
            /// The award.
            /// </value>
            public string Award { get; set; }
            /// <summary>
            /// Gets or sets the type of the rate.
            /// </summary>
            /// <value>
            /// The type of the rate.
            /// </value>
            public int RateType { get; set; }
            /// <summary>
            /// Gets or sets the price range start.
            /// </summary>
            /// <value>
            /// The price range start.
            /// </value>
            public float PriceRangeStart { get; set; }
            /// <summary>
            /// Gets or sets the price range end.
            /// </summary>
            /// <value>
            /// The price range end.
            /// </value>
            public float PriceRangeEnd { get; set; }
            /// <summary>
            /// Gets or sets the currency.
            /// </summary>
            /// <value>
            /// The currency.
            /// </value>
            public int Currency { get; set; }
        public int LocationId { get; set; }
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
        public int? VendorStatus { get; set; }
        public string VendorStatusName { get; set; }

        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public int CreatedBy { get; set; }
            public List<ServiceOfferList> ServiceOfferList { get; set; }
        }
        public class ServiceOfferList
        {
            /// <summary>
            /// Gets or sets the name of the tag.
            /// </summary>
            /// <value>
            /// The name of the tag.
            /// </value>
            public int OfferedServiceId { get; set; }
        }
}
