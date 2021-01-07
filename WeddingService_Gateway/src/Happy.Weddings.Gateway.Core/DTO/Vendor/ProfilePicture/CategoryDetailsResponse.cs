using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.ProfilePicture
{
    public class CategoryDetailsResponse
    {
        public int CategoryId { get; set; }
        public int ServiceType { get; set; }
        public string ServiceName { get; set; }
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public int VendorStatus { get; set; }
        public string VendorStatusName { get; set; }
        public string WebsiteLink { get; set; }
        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public string PinterestLink { get; set; }
        public string TwitterHandle { get; set; }
        public string ProfilePicture { get; set; }
        public string VideoLink { get; set; }
        public int CategoryMode { get; set; }
        public string CategoryModeName { get; set; }
        public short? Active { get; set; }
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
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated on.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? UpdatedAt { get; set; }
        public IFormFileCollection UploadProfilePicture { get; set; }
        public IFormFile ProfileImage { get; set; }
        public List<SubCategories> SubCategory { get; set; }
    }
    public class SubCategories
    {
        public int? SubCategoryType { get; set; }
        public string SubCategoryValue { get; set; }
    }
}
