#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | PaymentBookSearchParameter --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.Domain;

namespace Happy.Weddings.Wallet.Core.DTO.Requests.PaymentBook
{
    /// <summary>
    /// This Class is used to map PaymentBook Search Parameter
    /// </summary>
    public class PaymentBookSearchParameter : QueryStringParameters
    {
        public int VendorId { get; set; }
        public int PackageType { get; set; }
        public int PaymentType { get; set; }
        public int PaymentStatus { get; set; }
        public int PaymentMode { get; set; }
        public int VendorStatus { get; set; }
        public int FinanceApprovalStatus { get; set; }
        public int BHStatus { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

    }
}
