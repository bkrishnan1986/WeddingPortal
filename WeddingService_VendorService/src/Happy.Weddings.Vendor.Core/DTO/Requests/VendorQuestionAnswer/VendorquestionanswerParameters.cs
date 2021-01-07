namespace Happy.Weddings.Vendor.Core.DTO.Requests.Vendorquestionanswer
{
    public class VendorquestionanswerParameters 
    {
        public bool IsForVendor { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
    }
}
