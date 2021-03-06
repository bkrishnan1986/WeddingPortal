﻿#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | Subscription --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using System;

namespace Happy.Weddings.Vendor.Core.Entity
{
    /// <summary>
    /// Subscription  
    /// </summary>
    public partial class Wallet
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

        public virtual Multidetail TransactionTypeNavigation { get; set; }


    }

}
