namespace Happy.Weddings.Gateway.Core.DTO.Vendor.BranchServiceOffered
{
    public class BranchServiceParameters : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BranchParameters"/> class.
        /// </summary>
        public BranchServiceParameters()
        {
            //OrderBy = "Service";
        }
        public int ServiceId { get; set; }
        public int BranchId { get; set; }
        public bool IsForService { get; set; }
        public bool IsForBranch { get; set; }
        public bool IsForDistrict { get; set; }
    }
}
