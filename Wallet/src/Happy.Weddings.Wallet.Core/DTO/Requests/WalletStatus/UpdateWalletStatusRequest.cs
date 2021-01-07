#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | UpdateWalletStatusRequest --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Wallet.Core.DTO.Requests.WalletStatus
{
    /// <summary>
    /// This Class is used to map Update Wallet Status Request
    /// </summary>
    public class UpdateWalletStatusRequest
    {
        public string Action { get; set; }
        public int Status { get; set; }
        public string Reason { get; set; }
        public DateTime StatusDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}
