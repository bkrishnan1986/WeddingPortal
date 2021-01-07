using Newtonsoft.Json;
using System;

namespace Happy.Weddings.Vendor.Core.DTO.Responses.Branch
{
    public class BranchResponse
    {
        public int Id { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string ListingAddress { get; set; }
        public string BuildingName { get; set; }
        public string FlatPlotDoorNo { get; set; }
        public string Floor { get; set; }
        public string StreetName { get; set; }
        public string LocalityName { get; set; }
        public string Pincode { get; set; }
        public string Landmark { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public short? EstablishedYear { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? UpdatedBy { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? UpdatedAt { get; set; }  
    }
}
