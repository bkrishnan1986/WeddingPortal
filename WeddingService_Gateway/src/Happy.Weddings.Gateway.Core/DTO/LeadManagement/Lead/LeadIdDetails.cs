using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead
{
    public class LeadIdDetails
    {
        public int LeadId { get; set; }
        public LeadIdDetails(int leadId)
        {
            LeadId = leadId;
        }
    }
}
