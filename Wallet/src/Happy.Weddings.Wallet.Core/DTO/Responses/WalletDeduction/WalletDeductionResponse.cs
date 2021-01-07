#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | WalletDeductionResponse --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Happy.Weddings.Wallet.Core.DTO.Responses.WalletDeduction
{
    /// <summary>
    /// This Class is used to map Wallet Deduction Response
    /// </summary>
    public class WalletDeductionResponse
    {
        public int Id { get; set; }
        public int LeadId { get; set; }
        public int VendorId { get; set; }
        public int? CustomerId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public decimal WalletBalance { get; set; }
        public int WalletStatus { get; set; }
        public string WalletStatusName { get; set; }
        public decimal DeductedAmount { get; set; }
        public DateTime DeductedDate { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
