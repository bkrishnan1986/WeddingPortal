using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.AuditLog.MultiDetail
{
    public class CreateMultidetailAuditLogRequest
    {
        public int MultiCodeId { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
    }
}
