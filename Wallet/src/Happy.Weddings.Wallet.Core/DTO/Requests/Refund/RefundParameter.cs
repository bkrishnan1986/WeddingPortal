#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | RefundParameter --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.Domain;

namespace Happy.Weddings.Wallet.Core.DTO.Requests.Refund
{
    /// <summary>
    /// This Class is used to map Refund Parameter
    /// </summary>
    public class RefundParameter
    {
        public int Value { get; set; }
        public bool IsforSingleRefund { get; set; }
        public bool IsforRaisedBy { get; set; }
    }
}
