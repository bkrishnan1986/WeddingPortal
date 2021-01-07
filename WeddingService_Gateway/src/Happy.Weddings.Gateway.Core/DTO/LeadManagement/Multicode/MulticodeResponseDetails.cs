using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Happy.Weddings.Gateway.Core.DTO.LeadManagement.Multicode
{
    public class MulticodeResponseDetails : MultiCodeResponse
    {
        /// <summary>
        /// Gets or sets the Multicode.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Domain.LeadManagement.Multicode> Multicode { get; set; }
    }
}
