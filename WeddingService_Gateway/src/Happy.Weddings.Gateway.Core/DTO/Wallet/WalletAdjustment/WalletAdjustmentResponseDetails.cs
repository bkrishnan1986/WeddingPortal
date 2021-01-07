using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.Domain.Wallet;
using Newtonsoft.Json;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.WalletAdjustment
{
    public class WalletAdjustmentResponseDetails : WalletAdjustmentResponse
    {
        /// <summary>
        /// Gets or sets the WalletAdjustment.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Domain.Wallet.WalletAdjustment> WalletAdjustment { get; set; }
    }
}
