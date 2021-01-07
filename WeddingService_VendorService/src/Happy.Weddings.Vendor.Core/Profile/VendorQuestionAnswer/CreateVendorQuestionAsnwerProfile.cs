using System;
using Happy.Weddings.Vendor.Core.DTO.Requests.Vendorquestionanswer;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Profile.VendorQuestionAnswer
{
    public class CreateVendorQuestionAsnwerProfile : AutoMapper.Profile
    {
        public CreateVendorQuestionAsnwerProfile()
        {
            CreateMap<CreateVendorQuestionAnswerRequest, Vendorquestionanswers>()
                 .ForMember(x => x.CreatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
