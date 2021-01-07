using Happy.Weddings.Vendor.Core.DTO.Responses.ProfilePicture;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Profile.ProfilePicture
{
    public class CategoryDetailsResponseProfile : AutoMapper.Profile
    {
        public CategoryDetailsResponseProfile()
        {
            CreateMap<Categorydetails, CategoryResponse>()
                 .ForMember(x => x.ServiceName, opt => opt.MapFrom(o => o.ServiceTypeNavigation != null ? o.ServiceTypeNavigation.Service.Value : ""));
        }
    }
}
