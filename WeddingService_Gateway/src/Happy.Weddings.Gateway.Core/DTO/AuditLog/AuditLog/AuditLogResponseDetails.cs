using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.Domain.AuditLog;
using Newtonsoft.Json;

namespace Happy.Weddings.Gateway.Core.DTO.AuditLog.AuditLog
{
    public class AuditLogResponseDetails : AuditLogResponse
    {
        /// <summary>
        /// Gets or sets the AuditLog.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Domain.AuditLog.Auditlog> Auditlog { get; set; }
    }
}
