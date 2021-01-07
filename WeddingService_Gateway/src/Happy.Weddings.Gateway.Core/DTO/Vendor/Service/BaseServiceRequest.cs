using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.Service
{
    /// <summary>
    /// BaseServiceRequest
    /// </summary>
    public class BaseServiceRequest
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

        public string PhotoPath { get; set; }
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
        /// <summary>
        /// Gets or sets the vendor identifier.
        /// </summary>
        /// <value>
        /// The vendor identifier.
        /// </value>
        public int VendorId { get; set; }
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

        public IFormFile Photo { get; set; }
    }
}
