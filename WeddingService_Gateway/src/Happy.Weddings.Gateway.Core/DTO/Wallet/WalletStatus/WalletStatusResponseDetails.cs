using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.Domain.Wallet;
using Newtonsoft.Json;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.WalletStatus
{
    public class WalletStatusResponseDetails : WalletStatusResponse
    {
        /// <summary>
        /// Gets or sets the WalletStatus.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Domain.Wallet.WalletStatus> WalletStatus { get; set; }
    }
}
