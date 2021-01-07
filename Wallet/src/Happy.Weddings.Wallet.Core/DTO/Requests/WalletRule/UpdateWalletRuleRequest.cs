#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | UpdateWalletRuleRequest --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Wallet.Core.DTO.Requests.WalletRule
{
    /// <summary>
    /// This Class is used to map Update WalletRule Request
    /// </summary>
    public class UpdateWalletRuleRequest
    {
        public int Mode { get; set; }
        public decimal? Cplamount { get; set; }
        public decimal? CommissionAmount { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
