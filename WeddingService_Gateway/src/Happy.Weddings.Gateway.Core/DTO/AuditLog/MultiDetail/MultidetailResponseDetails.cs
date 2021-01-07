using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.Domain.AuditLog;
using Newtonsoft.Json;

namespace Happy.Weddings.Gateway.Core.DTO.AuditLog.MultiDetail
{
    public class MultidetailResponseDetails : MultidetailResponse
    {
        /// <summary>
        /// Gets or sets the Multidetail.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Domain.LeadManagement.Multidetail> Multidetail { get; set; }
    }
}
