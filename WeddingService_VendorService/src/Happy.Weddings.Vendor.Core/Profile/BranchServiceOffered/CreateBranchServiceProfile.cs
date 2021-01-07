using System;
using Happy.Weddings.Vendor.Core.DTO.Requests.Branch;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Profile.BranchServiceOffered
{
    public class CreateBranchServiceProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateBranchServiceProfile"/> class.
        /// </summary>
        public CreateBranchServiceProfile()
        {
            CreateMap<BranchServiceoffered, Branchserviceoffered>()
                 .ForMember(x => x.CreatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
