#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS   | Created and implemented. 
//              |                         | CreateRefundRequest --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Wallet.Core.DTO.Requests.Refund
{
    /// <summary>
    /// This Class is used to map Create Refund Request
    /// </summary>
    public class CreateRefundRequest
    {
        public string Activity { get; set; }
        public DateTime RaisedDate { get; set; }
        public int RaisedBy { get; set; }
        public string RefundType { get; set; }
        public decimal RefundAmount { get; set; }
        public string RefundReason { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
    }
}
