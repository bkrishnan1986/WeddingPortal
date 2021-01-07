using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.AuditLog.AuditLog
{
    public class CreateAuditLogRequest
    {
        public string Url { get; set; }
        public string OldData { get; set; }
        public string NewData { get; set; }
        public int ApprovalStatus { get; set; }
        public int EditedBy { get; set; }
    }
}
