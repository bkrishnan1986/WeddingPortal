using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Happy.Weddings.Gateway.Core.DTO.LeadManagement.Multidetail
{
    public class MultidetailResponseDetails
    {
        /// <summary>
        /// Gets or sets the Multidetail.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Domain.LeadManagement.Multidetail> Multidetail { get; set; }
    }
}
