#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | PaymentBookParameter --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.Domain;

namespace Happy.Weddings.Wallet.Core.DTO.Requests.PaymentBook
{
    /// <summary>
    /// This Class is used to map PaymentBook Parameter
    /// </summary>
    public class PaymentBookParameter
    {
        public int Value { get; set; }
        public bool IsForVendorId { get; set; }

    }
}
