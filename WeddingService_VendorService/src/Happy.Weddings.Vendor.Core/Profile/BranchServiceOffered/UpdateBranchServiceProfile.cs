using Happy.Weddings.Vendor.Core.DTO.Requests.Branch;
using Happy.Weddings.Vendor.Core.Entity;
using System;

namespace Happy.Weddings.Vendor.Core.Profile.BranchServiceOffered
{
    public class UpdateBranchServiceProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateBranchServiceProfile"/> class.
        /// </summary>
        public UpdateBranchServiceProfile()
        {
            CreateMap<BranchServiceOFFered, Branchserviceoffered>()
                 .ForMember(x => x.UpdatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
