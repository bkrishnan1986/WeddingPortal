#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | UpdatePaymentBookRequest --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Wallet.Core.DTO.Requests.PaymentBook
{
    /// <summary>
    /// This Class is used to map Update PaymentBook Request
    /// </summary>
    public class UpdatePaymentBookRequest
    {
        public DateTime EntryDate { get; set; }
        public int VendorId { get; set; }
        public int? Package { get; set; }
        public string PackageName { get; set; }
        public int? PackageType { get; set; }
        public int PaymentType { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal? ReceivedAmount { get; set; }
        public int PaymentStatus { get; set; }
        public decimal? Gst { get; set; }
        public decimal? Kfc { get; set; }
        public decimal? Tds { get; set; }
        public decimal WalletBalance { get; set; }
        public int? VendorStatus { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int PaymentMode { get; set; }
        public string PaymentRefNumber { get; set; }
        public string PayeeName { get; set; }
        public string PaymentDocs { get; set; }
        public string BankName { get; set; }
        public string BankState { get; set; }
        public string BankCity { get; set; }
        public string Branch { get; set; }
        public string BankAccountNumber { get; set; }
        public string Ifsc { get; set; }
        public DateTime? BankCreditedDate { get; set; }
        public int? FinanceApprovalStatus { get; set; }
        public DateTime? FinanceApprovalStatusDate { get; set; }
        public string FinanceComment { get; set; }
        public string TidNumber { get; set; }
        public DateTime? ChequeDate { get; set; }
        public int? Bhstatus { get; set; }
        public string BhstatusReason { get; set; }
        public DateTime? BhstatusDate { get; set; }
        public string Bhcomments { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
