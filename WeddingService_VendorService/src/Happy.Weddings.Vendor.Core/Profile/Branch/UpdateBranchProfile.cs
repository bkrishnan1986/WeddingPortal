using System;
using Happy.Weddings.Vendor.Core.DTO.Requests.Branch;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Profile.Branch
{
    /// <summary>
    ///  This class is used to map Update Branch Profile
    /// </summary>
    /// 
    public class UpdateBranchProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateBranchProfile"/> class.
        /// </summary>
        public UpdateBranchProfile()
        {
            CreateMap<UpdateBranchRequest, Branches>()
                 .ForMember(x => x.UpdatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
