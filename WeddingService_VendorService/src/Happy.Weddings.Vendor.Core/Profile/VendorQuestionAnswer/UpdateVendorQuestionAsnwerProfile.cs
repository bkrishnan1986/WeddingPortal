using System;
using Happy.Weddings.Vendor.Core.DTO.Requests.Vendorquestionanswer;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Profile.VendorQuestionAnswer
{
    public class UpdateVendorQuestionAsnwerProfile : AutoMapper.Profile
    {
        public UpdateVendorQuestionAsnwerProfile()
        {
            CreateMap<UpdateVendorQuestionAsnwerRequest, Vendorquestionanswers>()
                 .ForMember(x => x.UpdatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
