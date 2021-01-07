namespace Happy.Weddings.Vendor.Core.DTO.Requests.Vendorquestionanswer
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
}
