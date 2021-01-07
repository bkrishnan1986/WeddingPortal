using Happy.Weddings.Vendor.Core.DTO.Responses.ProfilePicture;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Profile.ProfilePicture
{
    public  class ProfilePictureResponseProfile : AutoMapper.Profile
    {
        public ProfilePictureResponseProfile()
        {
            CreateMap<Profilepictures, ProfilePictureResponse>()
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(o => o.Category != null ? o.Category.ServiceTypeNavigation.Service.Value : ""));
        }
    }
}
