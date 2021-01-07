#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS   | Created and implemented. 
//              |                         | CreateWalletAdjustmentRequest --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Wallet.Core.DTO.Requests.WalletAdjustment
{
    /// <summary>
    /// This Class is used to map Create Wallet Adjustment Request
    /// </summary>
    public class CreateWalletAdjustmentRequest
    {
        public int VendorId { get; set; }
        public int AdjustmentType { get; set; }
        public decimal AdjustmentAmount { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
    }
}
