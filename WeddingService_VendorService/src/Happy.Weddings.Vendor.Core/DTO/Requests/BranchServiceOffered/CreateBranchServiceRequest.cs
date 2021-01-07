namespace Happy.Weddings.Vendor.Core.DTO.Requests.BranchServiceOffered
{
    public class CreateBranchServiceRequest
    {
        public int ServiceId { get; set; }
        public int BranchId { get; set; }
        public string ContactPerson { get; set; }
        public string PrimaryMobileNumber { get; set; }
        public string EmailId { get; set; }
        public int CreatedBy { get; set; }
    }
}
