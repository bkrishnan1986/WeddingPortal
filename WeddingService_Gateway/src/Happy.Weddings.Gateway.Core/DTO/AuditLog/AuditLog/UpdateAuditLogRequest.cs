using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.AuditLog.AuditLog
{
    public class UpdateAuditLogRequest
    {
        public int ApprovalStatus { get; set; }
        public int UpdatedBy { get; set; }
    }
}
