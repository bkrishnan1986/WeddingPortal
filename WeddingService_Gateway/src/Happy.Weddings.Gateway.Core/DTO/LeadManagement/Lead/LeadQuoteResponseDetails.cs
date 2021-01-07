using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.Domain.Wallet;
using Newtonsoft.Json;

namespace Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead
{
    public class LeadQuoteResponseDetails : LeadQuoteResponse
    {
        /// <summary>
        /// Gets or sets the LeadQuoteResponse.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Domain.LeadManagement.Leadquote> Leadquote { get; set; }
    }
}
