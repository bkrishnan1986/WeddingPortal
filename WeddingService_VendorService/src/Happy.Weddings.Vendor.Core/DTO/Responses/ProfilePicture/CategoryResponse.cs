using Happy.Weddings.Vendor.Core.DTO.Responses.Branch;
using Happy.Weddings.Vendor.Core.DTO.Responses.BranchServiceOffered;
using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.DTO.Responses.ProfilePicture
{
    public class CategoryResponse : CategoryDetailsResponse
    {
        public List<SubcategoryResponse> SubCategory { get; set; }
        public List<ProfilePictureResponse> ProfilePictures { get; set; }
        public List<BranchServiceResponse> Branchserviceoffered { get; set; }
        public List<BranchResponse> Branches { get; set; }
    }
}
