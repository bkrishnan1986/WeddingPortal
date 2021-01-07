#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | UpdateSubscriptionPlanRequest --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using System;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.Wallet
{
    /// <summary>
    /// This Class is used to map Update SubscriptionPlan Request
    /// </summary>
    public class UpdateWalletRequest
    {
        public string Activity { get; set; }
        public int TransactionType { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public DateTime TransactionDate { get; set; }
        public int VendorId { get; set; }
        public int UpdatedBy { get; set; }
    }
}
