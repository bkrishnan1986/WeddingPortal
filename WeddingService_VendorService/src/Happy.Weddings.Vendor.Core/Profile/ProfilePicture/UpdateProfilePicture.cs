using Happy.Weddings.Vendor.Core.DTO.Requests.ProfilePicture;
using Happy.Weddings.Vendor.Core.Entity;
using System;

namespace Happy.Weddings.Vendor.Core.Profile.ProfilePicture
{
    public  class UpdateProfilePicture : AutoMapper.Profile
    {
        public UpdateProfilePicture()
        {
            CreateMap<ProfilePictureS, Profilepictures>()
                 .ForMember(x => x.UpdatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
