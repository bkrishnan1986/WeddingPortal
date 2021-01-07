using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.WalletStatus
{
    public class WalletStatusIdDetails
    {
        public int WalletStatusId { get; set; }
        public WalletStatusIdDetails(int walletStatusId)
        {
            WalletStatusId = walletStatusId;
        }
    }
}
