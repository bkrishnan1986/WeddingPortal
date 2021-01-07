#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | WalletDeductionParameter --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.Domain;

namespace Happy.Weddings.Wallet.Core.DTO.Requests.WalletDeduction
{
    /// <summary>
    /// This Class is used to map Wallets Deduction Parameter
    /// </summary>
    public class WalletDeductionParameter
    {
        /// <summary>
        /// Gets or sets to Value.
        /// </summary> 
        public int Value { get; set; }
        public bool IsForSingleDeduction { get; set; }
        public bool IsForLeadId { get; set; }
        public bool IsForVendorId { get; set; }
    }
}
