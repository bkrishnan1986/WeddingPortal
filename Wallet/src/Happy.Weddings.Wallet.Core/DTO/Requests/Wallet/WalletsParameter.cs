#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | WalletsParameter --class
//----------------------------------------------------------------------------------------------

#endregion

using Happy.Weddings.Wallet.Core.Domain;
using System;

namespace Happy.Weddings.Wallet.Core.DTO.Requests.Wallet
{
    /// <summary>
    /// This Class is used to map Wallets Parameter
    /// </summary>
    public class WalletsParameter : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WalletsParameter"/> class.
        /// </summary>
        public WalletsParameter()
        {

        }

        /// <summary>
        /// Gets or sets to Value.
        /// </summary> 
        public int VendorId { get; set; }
        public int StatusId { get; set; }
        public decimal Balance { get; set; }
        public bool IsForCutoff { get; set; }
        public bool IsForBalance { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}


