using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.WalletAdjustment
{
    public class WalletAdjustmentIdDetails
    {
        public int WalletAdjustmentId { get; set; }
        public WalletAdjustmentIdDetails(int walletAdjustmentId)
        {
            WalletAdjustmentId = walletAdjustmentId;
        }
    }
}
