#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | CreateWalletRuleRequest-- Controller.
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Wallet.Core.DTO.Requests.WalletRule
{
    /// <summary>
    /// This Class is used to map Create WalletRule Request
    /// </summary>
    public class CreateWalletRuleRequest
    {      
        public string ServiceCode { get; set; }
        public int ServiceCategoryId { get; set; }
        public string ServiceCategory { get; set; }
        public int Mode { get; set; }
        public decimal? Cplamount { get; set; }
        public decimal? CommissionAmount { get; set; }
        public int CreatedBy { get; set; }
    }
}
