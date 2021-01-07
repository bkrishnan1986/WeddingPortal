using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.AuditLog.MultiDetail
{
    public class UpdateMultidetailAuditLogRequest
    {
        public string Value { get; set; }
        public string Description { get; set; }
        public int UpdatedBy { get; set; }
    }
}
