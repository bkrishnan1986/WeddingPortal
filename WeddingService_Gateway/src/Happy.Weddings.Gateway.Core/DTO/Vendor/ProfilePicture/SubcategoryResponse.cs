using Newtonsoft.Json;
using System;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.ProfilePicture
{
    public class SubcategoryResponse
    {
        public int? CategoryId { get; set; }
        public string CategoryValue { get; set; }
        public int? SubCategoryType { get; set; }
        public string SubCategoryValue { get; set; }
        public short? Active { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? UpdatedBy { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? UpdatedAt { get; set; }
    }
}