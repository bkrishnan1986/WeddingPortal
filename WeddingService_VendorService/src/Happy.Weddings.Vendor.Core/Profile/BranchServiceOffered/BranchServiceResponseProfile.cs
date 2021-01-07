using Happy.Weddings.Vendor.Core.DTO.Responses.BranchServiceOffered;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Profile.BranchServiceOffered
{
    public class BranchServiceResponseProfile : AutoMapper.Profile
    {
        public BranchServiceResponseProfile()
        {
            CreateMap<Branchserviceoffered, BranchServiceResponse>()
                  .ForMember(x => x.ServiceName, opt => opt.MapFrom(o => o.Service != null ? o.Service.Value : "")) 
                  .ForMember(x => x.BranchName, opt => opt.MapFrom(o => o.Branch != null ? o.Branch.District.Value : "")); 
        }
    }
}
