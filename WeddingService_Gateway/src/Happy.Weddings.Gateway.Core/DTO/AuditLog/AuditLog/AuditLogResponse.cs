using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.AuditLog.AuditLog
{
    public class AuditLogResponse
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string OldData { get; set; }
        public string NewData { get; set; }
        public int ApprovalStatus { get; set; }
        public short Active { get; set; }
        public int EditedBy { get; set; }
        public DateTime EditedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
