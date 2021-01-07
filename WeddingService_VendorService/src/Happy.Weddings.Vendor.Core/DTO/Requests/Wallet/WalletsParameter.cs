#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | SubscriptionPlansParameter --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using System;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.Wallet
{
    /// <summary>
    /// This Class is used to map SubscriptionPlans Parameter
    /// </summary>
    public class WalletsParameter : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubcriptionPlansParameter"/> class.
        /// </summary>
        public WalletsParameter()
        {
            OrderBy = "Name";
        }

        /// <summary>
        /// Gets or sets to Value.
        /// </summary>
   

        public bool IsForSingleTransaction { get; set; }

        public bool IsForVendor { get; set; }

        public bool IsForTransactionType { get; set; }

        public decimal Value { get; set; }

    }
}


