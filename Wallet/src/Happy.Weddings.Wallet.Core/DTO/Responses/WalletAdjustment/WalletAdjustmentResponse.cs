#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | WalletAdjustmentResponse --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Happy.Weddings.Wallet.Core.DTO.Responses.WalletAdjustment
{
    /// <summary>
    /// This Class is used to map Wallet Adjustment Response
    /// </summary>
    public class WalletAdjustmentResponse
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public int AdjustmentType { get; set; }
        public string AdjustmentTypeName { get; set; }
        public decimal AdjustmentAmount { get; set; }
        public string Remarks { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
