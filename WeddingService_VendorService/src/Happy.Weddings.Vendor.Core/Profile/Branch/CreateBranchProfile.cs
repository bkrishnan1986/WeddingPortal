using System;
using Happy.Weddings.Vendor.Core.DTO.Requests.Branch;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Profile.Branch
{
    /// <summary>
    /// This class is used to map Create Branch Profile
    /// </summary>
    public class CreateBranchProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateBranchProfile"/> class.
        /// </summary>
        public CreateBranchProfile()
        {
            CreateMap<BranchListData, Branches>()
                 .ForMember(x => x.CreatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
