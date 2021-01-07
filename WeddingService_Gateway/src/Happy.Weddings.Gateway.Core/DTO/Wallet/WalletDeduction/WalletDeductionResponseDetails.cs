using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.Domain.Wallet;
using Newtonsoft.Json;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.WalletDeduction
{
    public class WalletDeductionResponseDetails : WalletDeductionResponse
    {
        /// <summary>
        /// Gets or sets the WalletDeduction.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Domain.Wallet.WalletDeduction> WalletDeduction { get; set; }
    }
}
