using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.Domain.Wallet;
using Newtonsoft.Json;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.Wallet
{
    public class WalletResponseDetails : WalletResponse
    {
        /// <summary>
        /// Gets or sets the Wallet.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Domain.Wallet.Wallet> Wallet { get; set; }
    }
}
