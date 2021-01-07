#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | RefundResponse --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Happy.Weddings.Wallet.Core.DTO.Responses.Refund
{
    /// <summary>
    /// This Class is used to map Refund Response
    /// </summary>
    public class RefundResponse
    {
        public int Id { get; set; }
        public string Activity { get; set; }
        public DateTime RaisedDate { get; set; }
        public int RaisedBy { get; set; }
        public string RefundType { get; set; }
        public decimal RefundAmount { get; set; }
        public string RefundReason { get; set; }
        public string Remarks { get; set; }
        public int? Bhstatus { get; set; }
        public string BhstatusName { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? ApprovedBy { get; set; }
        public decimal? ApprovedAmount { get; set; }
        public string ApprovalRemarks { get; set; }
        public string Reference { get; set; }
        public decimal? WalletBalance { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
