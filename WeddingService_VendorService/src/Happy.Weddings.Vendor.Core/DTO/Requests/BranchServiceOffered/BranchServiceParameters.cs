using Happy.Weddings.Vendor.Core.Domain;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.BranchServiceOffered
{
    public class BranchServiceParameters : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BranchParameters"/> class.
        /// </summary>
        public BranchServiceParameters()
        {
            OrderBy = "Service";
        }
        public int ServiceId { get; set; }
        public int BranchId { get; set; }
        public bool IsForService { get; set; }
        public bool IsForBranch { get; set; }
        public bool IsForDistrict { get; set; }
    }
}
