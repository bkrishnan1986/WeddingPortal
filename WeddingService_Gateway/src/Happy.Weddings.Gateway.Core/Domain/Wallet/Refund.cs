using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.Domain.Wallet
{
    public class Refund
    {
        public int Id { get; set; }
        public string Activity { get; set; }
        public DateTime RaisedDate { get; set; }
        public int RaisedBy { get; set; }
        public int RefundType { get; set; }
        public decimal RefundAmount { get; set; }
        public int RefundReason { get; set; }
        public string Remarks { get; set; }
        public int? Bhstatus { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? ApprovedBy { get; set; }
        public decimal? ApprovedAmount { get; set; }
        public string ApprovalRemarks { get; set; }
        public string Reference { get; set; }
        public decimal? WalletBalance { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
