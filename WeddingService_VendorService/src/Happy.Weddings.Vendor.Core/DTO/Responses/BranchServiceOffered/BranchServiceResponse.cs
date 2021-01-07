using Newtonsoft.Json;
using System;

namespace Happy.Weddings.Vendor.Core.DTO.Responses.BranchServiceOffered
{
    public class BranchServiceResponse
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string ContactPerson { get; set; }
        public string PrimaryMobileNumber { get; set; }
        public string EmailId { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? UpdatedBy { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? UpdatedAt { get; set; }
    }
}
