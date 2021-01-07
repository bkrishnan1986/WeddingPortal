using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.WalletRule
{
    public class WalletRuleIdDetails
    {
        public int WalletRuleId { get; set; }
        public WalletRuleIdDetails(int walletRuleId)
        {
            WalletRuleId = walletRuleId;
        }
    }
}
