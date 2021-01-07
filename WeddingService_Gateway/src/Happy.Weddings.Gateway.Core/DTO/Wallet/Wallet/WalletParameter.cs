using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.Wallet
{
    public class WalletParameter : QueryStringParameters
    {
        public int VendorId { get; set; }
        public int StatusId { get; set; }
        public decimal Balance { get; set; }
        public bool IsForCutoff { get; set; }
        public bool IsForBalance { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
