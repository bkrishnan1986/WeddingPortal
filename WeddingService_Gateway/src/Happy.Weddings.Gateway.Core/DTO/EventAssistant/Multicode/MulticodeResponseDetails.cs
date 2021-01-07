using Happy.Weddings.Gateway.Core.DTO.EventAssistant.MultiCode;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.EventAssistant.Multicode
{
    public class MulticodeResponseDetails : MultiCodeResponse
    {
        /// <summary>
        /// Gets or sets the Multicode.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Domain.EventAssistant.Multicode> Multicode { get; set; }
    }
}
