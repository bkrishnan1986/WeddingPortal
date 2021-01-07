using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.Domain.Wallet;
using Newtonsoft.Json;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.Refund
{
    public class RefundResponseDetails : RefundResponse
    {
        /// <summary>
        /// Gets or sets the Refund.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Domain.Wallet.Refund> Refund { get; set; }
    }
}
