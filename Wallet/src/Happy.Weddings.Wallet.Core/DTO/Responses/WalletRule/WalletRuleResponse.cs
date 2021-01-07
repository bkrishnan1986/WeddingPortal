#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | WalletRuleResponse --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Wallet.Core.DTO.Responses.WalletRule
{
    /// <summary>
    /// This Class is used to map WalletRule Response
    /// </summary>
    public class WalletRuleResponse
    {
        public int Id { get; set; }
        public string ServiceCode { get; set; }
        public int ServiceCategoryId { get; set; }
        public string ServiceCategory { get; set; }
        public int Mode { get; set; }
        public string ModeValue { get; set; }
        public decimal? Cplamount { get; set; }
        public decimal? CommissionAmount { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
