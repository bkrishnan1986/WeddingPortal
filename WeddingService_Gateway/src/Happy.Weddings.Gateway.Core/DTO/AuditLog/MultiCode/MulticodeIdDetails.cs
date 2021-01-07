using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.AuditLog.MultiCode
{
    public class MulticodeIdDetails
    {
        public string Code { get; set; }
        public MulticodeIdDetails(string code)
        {
            Code = code;
        }
    }
}
