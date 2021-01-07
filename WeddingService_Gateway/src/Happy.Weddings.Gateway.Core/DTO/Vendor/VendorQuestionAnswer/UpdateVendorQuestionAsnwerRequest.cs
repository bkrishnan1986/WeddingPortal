using System.Collections.Generic;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.Vendorquestionanswer
{
    public class UpdateVendorQuestionAsnwerRequest
    {
        public string VendorLeadId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public string Vendoranswervalue { get; set; }
        public short? IsForVendor { get; set; }
        public short Active { get; set; }
        public int? UpdatedBy { get; set; }
    }
    public class UpdateVendorQusetionAnswerDetailsRequest
    {
        public IEnumerable<UpdateVendorQuestionAsnwerRequest> UpdateVendorQuestionAnswers { get; set; }
    }
}
