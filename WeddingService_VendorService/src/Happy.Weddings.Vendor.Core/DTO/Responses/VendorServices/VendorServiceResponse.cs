using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Vendor.Core.DTO.Responses.VendorServices
{
    public class VendorServiceResponse
    {/// <summary>
     /// Gets or sets the service identifier.
     /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the ServiceType.
        /// </summary>

        public int ServiceType { get; set; }
        /// <summary>
        /// Gets or sets the ServiceName.
        /// </summary>

        public string ServiceName { get; set; }
        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the Experience.
        /// </summary>
        public float Experience { get; set; }
        /// <summary>
        /// Gets or sets the ExperienceUnit.
        /// </summary>
        public int ExperienceUnit { get; set; }
        /// <summary>
        /// Gets or sets the Award.
        /// </summary>
        public string Award { get; set; }
        /// <summary>
        /// Gets or sets the RateType.
        /// </summary>
        public int RateType { get; set; }
        /// <summary>
        /// Gets or sets the PriceRangeStart.
        /// </summary>
        public float PriceRangeStart { get; set; }
        /// <summary>
        /// Gets or sets the PriceRangeEnd.
        /// </summary>
        public float PriceRangeEnd { get; set; }
        /// <summary>
        /// Gets or sets the Currency.
        /// </summary>
        public int Currency { get; set; }
        /// <summary>
        /// Gets or sets the VendorId.
        /// </summary>
        public int VendorId { get; set; }
        /// <summary>
        /// Gets or sets the Active.
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated on.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime UpdatedDate { get; set; }
    }
}
