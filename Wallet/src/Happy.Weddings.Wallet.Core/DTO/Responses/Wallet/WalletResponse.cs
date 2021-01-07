#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | WalletResponse --class
//----------------------------------------------------------------------------------------------

#endregion

using System;

namespace Happy.Weddings.Wallet.Core.DTO.Responses.Wallet
{
    /// <summary>
    /// This Class is used to map Wallet Response
    /// </summary>

    public class WalletResponse
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public int Status { get; set; }
        public string StatusValue { get; set; }
        public decimal Balance { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
