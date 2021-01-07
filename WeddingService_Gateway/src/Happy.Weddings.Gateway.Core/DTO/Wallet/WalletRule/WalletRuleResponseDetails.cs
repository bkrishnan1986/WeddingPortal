using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.Domain.Wallet;
using Newtonsoft.Json;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.WalletRule
{
    public class WalletRuleResponseDetails : WalletRuleResponse
    {
        /// <summary>
        /// Gets or sets the WalletRule.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Domain.Wallet.WalletRule> WalletRule { get; set; }
    }
}
