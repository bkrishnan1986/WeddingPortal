#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | WalletAdjustmentParameter --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.Domain;

namespace Happy.Weddings.Wallet.Core.DTO.Requests.WalletAdjustment
{
    /// <summary>
    /// This Class is used to map Wallets Adjustment Parameter
    /// </summary>
    public class WalletAdjustmentParameter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WalletAdjustmentParameter"/> class.
        /// </summary>
        public int Value { get; set; }
        public int AdjustmentType { get; set; }
        public bool IsForVendor { get; set; }
    }
}
