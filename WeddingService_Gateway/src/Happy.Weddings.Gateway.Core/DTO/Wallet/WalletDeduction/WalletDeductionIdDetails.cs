using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.WalletDeduction
{
    public class WalletDeductionIdDetails
    {
        public int WalletDeductionId { get; set; }
        public WalletDeductionIdDetails(int walletDeductionId)
        {
            WalletDeductionId = walletDeductionId;
        }
    }
}
