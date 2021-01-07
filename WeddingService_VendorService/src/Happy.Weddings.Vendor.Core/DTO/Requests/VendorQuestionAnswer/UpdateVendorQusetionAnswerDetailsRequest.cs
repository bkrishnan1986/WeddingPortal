using Happy.Weddings.Vendor.Core.DTO.Requests.Vendorquestionanswer;
using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.VendorQuestionAnswer
{
    public class UpdateVendorQusetionAnswerDetailsRequest
    {
        public IEnumerable<UpdateVendorQuestionAsnwerRequest> UpdateVendorQuestionAnswers { get; set; }
    }
}
