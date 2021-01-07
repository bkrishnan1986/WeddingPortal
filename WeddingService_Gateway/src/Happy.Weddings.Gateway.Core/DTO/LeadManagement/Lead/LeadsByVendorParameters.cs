using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead
{
    public class LeadsByVendorParameters
    {
        public string VendorId { get; set; }
        public bool IsForAssignedLead { get; set; }
        public bool IsForQuotedLead { get; set; }
    }
}
