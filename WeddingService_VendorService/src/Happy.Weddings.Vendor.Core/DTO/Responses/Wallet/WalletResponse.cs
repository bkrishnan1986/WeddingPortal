#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | SubscriptionPlansResponse --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Happy.Weddings.Vendor.Core.DTO.Responses.Wallet
{
    /// <summary>
    /// This Class is used to map SubscriptionPlans Response
    /// </summary>

    public class WalletResponse
    {
        public int Id { get; set; }
        public string Activity { get; set; }
        public int TransactionType { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public DateTime TransactionDate { get; set; }
        public int VendorId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
