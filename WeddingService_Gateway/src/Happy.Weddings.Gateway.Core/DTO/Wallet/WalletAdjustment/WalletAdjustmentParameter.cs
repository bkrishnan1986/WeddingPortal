using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.WalletAdjustment
{
    public class WalletAdjustmentParameter
    {
        public int Value { get; set; }
        public int AdjustmentType { get; set; }
        public bool IsForVendor { get; set; }
    }
}
