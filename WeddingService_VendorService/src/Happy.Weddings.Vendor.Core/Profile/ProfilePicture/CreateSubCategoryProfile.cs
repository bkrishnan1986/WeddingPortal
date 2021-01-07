using Happy.Weddings.Vendor.Core.DTO.Requests.ProfilePicture;
using Happy.Weddings.Vendor.Core.Entity;
using System;

namespace Happy.Weddings.Vendor.Core.Profile.ProfilePicture
{
    public class CreateSubCategoryProfile : AutoMapper.Profile
    {
        public CreateSubCategoryProfile()
        {
            CreateMap<SubCategory, Subcategory>()
                 .ForMember(x => x.CreatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
