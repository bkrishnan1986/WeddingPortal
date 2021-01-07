using Happy.Weddings.Vendor.Core.DTO.Requests.ProfilePicture;
using Happy.Weddings.Vendor.Core.Entity;
using System;

namespace Happy.Weddings.Vendor.Core.Profile.ProfilePicture
{
    public class UpdateSubCategoryProfile : AutoMapper.Profile
    {
        public UpdateSubCategoryProfile()
        {
            CreateMap<SuBCategory, Subcategory>()
                 .ForMember(x => x.UpdatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
