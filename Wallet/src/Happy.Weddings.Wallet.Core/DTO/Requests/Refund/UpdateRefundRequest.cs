#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | UpdateRefundRequest --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Wallet.Core.DTO.Requests.Refund
{
    /// <summary>
    /// This Class is used to map Update RefundRequest Request
    /// </summary>
    public class UpdateRefundRequest
    {
        public int? Bhstatus { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? ApprovedBy { get; set; }
        public decimal? ApprovedAmount { get; set; }
        public string ApprovalRemarks { get; set; }
        public string Reference { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
