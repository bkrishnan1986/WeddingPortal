using Happy.Weddings.Gateway.Core.DTO.Vendor.Branch;
using Happy.Weddings.Gateway.Core.DTO.Vendor.BranchServiceOffered;
using Happy.Weddings.Vendor.Core.DTO.Responses.ProfilePicture;
using System.Collections.Generic;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.ProfilePicture
{
    public class CategoryResponse : CategoryDetailsResponse
    {
        public List<SubcategoryResponse> SubCategory { get; set; }
        public List<ProfilePictureResponse> ProfilePictures { get; set; }
        public List<BranchServiceResponse> Branchserviceoffered { get; set; }
        public List<BranchResponse> Branches { get; set; }
    }
}
