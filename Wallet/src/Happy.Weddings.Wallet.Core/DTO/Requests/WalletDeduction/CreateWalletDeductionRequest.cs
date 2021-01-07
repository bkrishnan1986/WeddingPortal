#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | CreateWalletDeductionRequest --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Wallet.Core.DTO.Requests.WalletDeduction
{
    /// <summary>
    /// This Class is used to map Create Deduction Request
    /// </summary>
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
