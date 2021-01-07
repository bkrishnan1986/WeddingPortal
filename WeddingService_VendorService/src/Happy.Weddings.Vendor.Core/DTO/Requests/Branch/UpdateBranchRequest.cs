using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.Branch
{
    public class UpdateBranchRequest
    {
        public int Id { get; set; }
        public int DistrictId { get; set; }
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
        public int? UpdatedBy { get; set; }
        public List<BranchServiceOFFered> BranchServiceOFFered { get; set; }
    }

    public class BranchServiceOFFered
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int BranchId { get; set; }
        public string ContactPerson { get; set; }
        public string PrimaryMobileNumber { get; set; }
        public string EmailId { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
