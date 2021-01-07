using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.Domain.Wallet;
using Newtonsoft.Json;

namespace Happy.Weddings.Gateway.Core.DTO.Identity.Multicode
{
    public class MulticodeResponseDetails : MultiCodeResponse
    {
        /// <summary>
        /// Gets or sets the Multicode.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Domain.Wallet.Multicode> Multicode { get; set; }
    }
}
