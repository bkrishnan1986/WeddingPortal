using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.AuditLog.AuditLog
{
    public class AuditLogIdDetails
    {
        public int Id { get; set; }
        public AuditLogIdDetails(int auditLogId)
        {
            Id = auditLogId;
        }
    }
}
