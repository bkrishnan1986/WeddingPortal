using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.Domain.Identity;
using Newtonsoft.Json;

namespace Happy.Weddings.Gateway.Core.DTO.Identity.Multidetail
{
    public class MultidetailResponseDetails : MultidetailResponse
    {
        /// <summary>
        /// Gets or sets the Multidetail.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Domain.Wallet.Multidetail> Multidetail { get; set; }
    }
}
