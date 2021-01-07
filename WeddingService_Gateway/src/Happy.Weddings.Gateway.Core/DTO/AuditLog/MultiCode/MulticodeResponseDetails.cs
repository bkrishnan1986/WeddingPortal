using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.Domain.AuditLog;
using Newtonsoft.Json;

namespace Happy.Weddings.Gateway.Core.DTO.AuditLog.MultiCode
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
