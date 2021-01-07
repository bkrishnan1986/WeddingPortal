#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS   | Created and implemented. 
//              |                         | WalletRuleParameter --class
//----------------------------------------------------------------------------------------------

#endregion


namespace Happy.Weddings.Wallet.Core.DTO.Requests.WalletRule
{
    /// <summary>
    /// This Class is used to map WalletRule Parameter
    /// </summary>
    public class WalletRuleParameter 
    {
        public int Value { get; set; }
        public bool IsForServiceCategory { get; set; }
    }
}
