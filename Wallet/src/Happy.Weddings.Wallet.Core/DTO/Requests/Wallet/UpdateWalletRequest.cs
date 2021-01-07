#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | UpdateWalletRequest --class
//----------------------------------------------------------------------------------------------

#endregion

using System;

namespace Happy.Weddings.Wallet.Core.DTO.Requests.Wallet
{
    /// <summary>
    /// This Class is used to map Update Wallet Request
    /// </summary>
    public class UpdateWalletRequest
    {
        public int Status { get; set; }
        public decimal Balance { get; set; }
        public int UpdatedBy { get; set; }
    }
}
