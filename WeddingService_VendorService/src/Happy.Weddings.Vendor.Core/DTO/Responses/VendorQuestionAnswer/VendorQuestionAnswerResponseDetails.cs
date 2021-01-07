using Happy.Weddings.Vendor.Core.DTO.Responses.ServiceAnswer;
using Happy.Weddings.Vendor.Core.DTO.Responses.ServiceQuestion;
using System;
using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.DTO.Responses.VendorQuestionAnswer
{
    public class VendorQuestionAnswerResponseDetails 
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
        public List<ServiceAnswerResponse> ServiceAnswer { get; set; }
        public List<ServiceQuestionDetailsResponse> ServiceQuestion { get; set; }           
    }
}
