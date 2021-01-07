using Happy.Weddings.Vendor.Core.DTO.Responses.Branch;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Profile.Branch
{
    public class BranchReposneDetailsProfile : AutoMapper.Profile
    {
        public BranchReposneDetailsProfile()
        {
            CreateMap<Branches, BranchDetailsResponse>()
                  .ForMember(x => x.DistrictName, opt => opt.MapFrom(o => o.District != null ? o.District.Value : ""));
        }
    }
}
