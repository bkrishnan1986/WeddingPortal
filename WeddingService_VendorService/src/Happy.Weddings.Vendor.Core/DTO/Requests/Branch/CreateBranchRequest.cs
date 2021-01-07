using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.Branch
{
    public class CreateBranchRequest
    {
        /// <summary>
        /// Gets or sets the branches.
        /// </summary>
        /// <value>
        /// The branches.
        /// </value>
        public List<BranchListData> Branches { get; set; }
    }

    public class BranchListData
    { 
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
        public int CreatedBy { get; set; }
        public List<BranchServiceoffered> BranchServiceoffered { get; set; }
    }

    public class BranchServiceoffered
    {
        public int ServiceId { get; set; }
        public string ContactPerson { get; set; }
        public string PrimaryMobileNumber { get; set; }
        public string EmailId { get; set; }
    }
}
