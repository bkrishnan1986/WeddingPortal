using Happy.Weddings.Vendor.Core.DTO.Responses.BranchServiceOffered;
using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.DTO.Responses.Branch
{
    public class BranchDetailsResponse : BranchResponse
    {
        public List<BranchServiceResponse> BranchServiceOffered { get; set; }
    }
}
