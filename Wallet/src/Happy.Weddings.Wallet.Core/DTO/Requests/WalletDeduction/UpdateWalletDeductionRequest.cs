#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | UpdateWalletDeductionRequest --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Wallet.Core.DTO.Requests.WalletDeduction
{
    /// <summary>
    /// This Class is used to map Update Wallet Deduction Request
    /// </summary>
    public class UpdateWalletDeductionRequest
    {
        public string InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
