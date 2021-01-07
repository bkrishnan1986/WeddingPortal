using System;
using Happy.Weddings.Vendor.Core.DTO.Requests.ProfilePicture;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Profile.ProfilePicture
{
    public class CreateCategoryDetailsProfile : AutoMapper.Profile
    {
        public CreateCategoryDetailsProfile()
        {
            CreateMap<CreateCategoryDetailsRequest, Categorydetails>()
                 .ForMember(x => x.CreatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
