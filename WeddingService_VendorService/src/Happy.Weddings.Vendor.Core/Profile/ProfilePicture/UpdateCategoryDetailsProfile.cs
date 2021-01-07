using Happy.Weddings.Vendor.Core.DTO.Requests.ProfilePicture;
using Happy.Weddings.Vendor.Core.Entity;
using System;

namespace Happy.Weddings.Vendor.Core.Profile.ProfilePicture
{
    public class UpdateCategoryDetailsProfile : AutoMapper.Profile
    {
        public UpdateCategoryDetailsProfile()
        {
            CreateMap<UpdateCategoryDetailsRequest, Categorydetails>()
                 .ForMember(x => x.CreatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
