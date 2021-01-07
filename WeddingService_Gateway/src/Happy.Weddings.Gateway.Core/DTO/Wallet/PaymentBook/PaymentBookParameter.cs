using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.PaymentBook
{
    public class PaymentBookParameter : QueryStringParameters
    {
        public int VendorId { get; set; }
        public int PackageType { get; set; }
        public int PaymentType { get; set; }
        public int PaymentStatus { get; set; }
        public int PaymentMode { get; set; }
        public int VendorStatus { get; set; }
        public int FinanceApprovalStatus { get; set; }
        public int BHStatus { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
