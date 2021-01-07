using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.Domain.Wallet;
using Newtonsoft.Json;

namespace Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead
{
    public class LeadsResponseDetails : LeadsResponse
    {
        /// <summary>
        /// Gets or sets the LeadResponse.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Domain.LeadManagement.Leads> Leads { get; set; }
    }
}
