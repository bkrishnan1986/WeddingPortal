using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Happy.Weddings.Gateway.Core.DTO.Blog.Multicode
{
    public class MulticodeResponseDetails
    {
        /// <summary>
        /// Gets or sets the Multicode.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Domain.LeadManagement.Multicode> Multicode { get; set; }
    }
}
