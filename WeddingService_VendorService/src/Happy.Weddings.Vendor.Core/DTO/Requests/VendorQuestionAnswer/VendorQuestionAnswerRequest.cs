using Happy.Weddings.Vendor.Core.DTO.Requests.Vendorquestionanswer;
using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.VendorQuestionAnswer
{
    public class VendorQuestionAnswerRequest
    {
        public IEnumerable<CreateVendorQuestionAnswerRequest> VendorQuestionAnswers { get; set; }
    }
}
