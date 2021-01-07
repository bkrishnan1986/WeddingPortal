using System;
using Happy.Weddings.Vendor.Core.DTO.Requests.ProfilePicture;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Profile.ProfilePicture
{
    public class CreateProfilePicture : AutoMapper.Profile
    {
        public CreateProfilePicture()
        {
            CreateMap<ProfilePictures, Profilepictures>()
                 .ForMember(x => x.CreatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
