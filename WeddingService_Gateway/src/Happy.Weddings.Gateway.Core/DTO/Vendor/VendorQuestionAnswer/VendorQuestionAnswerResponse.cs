using System;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.VendorQusetionAnswer
{
    public class VendorQuestionAnswerResponse
    {
        public int Id { get; set; }
        public string VendorLeadId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public string Vendoranswervalue { get; set; }
        public short? IsForVendor { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
         
    }
}
