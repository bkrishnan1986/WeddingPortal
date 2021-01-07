#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | WalletsStatusParameter --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Wallet.Core.DTO.Requests.WalletStatus
{
    /// <summary>
    /// This Class is used to map Wallets Status Parameter
    /// </summary>
    public class WalletStatusParameter
    {
        /// <summary>
        /// Gets or sets to Value.
        /// </summary>

        public int Value { get; set; }
        public bool IsForWallet { get; set; }

    }
}
