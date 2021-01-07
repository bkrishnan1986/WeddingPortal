using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.Wallet
{
    public class WalletIdDetails
    {
        public int WalletId { get; set; }
        public bool IsPaused { get; set; }
        public bool IsReleased { get; set; }
        public bool IsChurned { get; set; }
        public WalletIdDetails(int walletId, bool isPaused = false, bool isReleased = false, bool isChurned = false)
        {
            WalletId = walletId;
            IsPaused = isPaused;
            IsReleased = isReleased;
            IsChurned = isChurned;
        }
    }
}
