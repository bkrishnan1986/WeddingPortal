using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.AuditLog.AuditLog
{
    public class AuditLogParameters : QueryStringParameters
    {
        public int ApprovalStatusId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
