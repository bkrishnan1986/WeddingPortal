using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.WalletDeduction
{
    public class CreateWalletDeductionRequest
    {
        public int LeadId { get; set; }
        public string LeadIdNumber { get; set; }
        public string LeadMode { get; set; }
        public int VendorId { get; set; }
        public int? CustomerId { get; set; }
        public string CategoryValue { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public decimal WalletBalance { get; set; }
        public int WalletStatus { get; set; }
        public decimal DeductedAmount { get; set; }
        public DateTime DeductedDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
