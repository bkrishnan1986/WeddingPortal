using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.EventAssistant.Multidetail
{
    public class MultidetailResponseDetails
    {
        /// <summary>
        /// Gets or sets the Multidetail.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Domain.EventAssistant.Multidetail> Multidetail { get; set; }
    }
}