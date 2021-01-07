using Happy.Weddings.Vendor.Core.DTO.Responses.VendorQuestionAnswer;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Profile.VendorQuestionAnswer
{
    public class VendorQuestionAnswerResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VendorQuestionAnswerResponseProfile"/> class.
        /// </summary>
        public VendorQuestionAnswerResponseProfile()
        {
            CreateMap<Vendorquestionanswers, VendorQuestionAnswerResponseDetails>();
        }
    }
}
