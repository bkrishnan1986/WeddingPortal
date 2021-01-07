using Happy.Weddings.Vendor.Core.DTO.Responses.ProfilePicture;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Profile.ProfilePicture
{
    public class SubcategoryResponseProfile : AutoMapper.Profile
    {
        public SubcategoryResponseProfile()
        {
            CreateMap<Subcategory, SubcategoryResponse>()
                .ForMember(x => x.CategoryValue, opt => opt.MapFrom(o => o.CategoryTypeNavigation != null ? o.CategoryTypeNavigation.ServiceTypeNavigation.Service.Value : ""));
        }
    }
}
