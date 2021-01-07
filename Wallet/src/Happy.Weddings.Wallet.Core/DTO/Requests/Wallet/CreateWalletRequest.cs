#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | CreateWalletRequest --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;

namespace Happy.Weddings.Wallet.Core.DTO.Requests.Wallet
{
    /// <summary>
    /// This Class is used to map Create Wallet Request
    /// </summary>
    public class CreateWalletRequest
    {
        public int VendorId { get; set; }
        public int Status { get; set; }
        public decimal Balance { get; set; }
        public int CreatedBy { get; set; }
    }

}
