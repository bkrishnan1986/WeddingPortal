using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead
{
    public class LeadStatusIdDetails
    {
        public int LeadStatusId { get; set; }
        public LeadStatusIdDetails(int leadStatusId)
        {
            LeadStatusId = leadStatusId;
        }
    }
}
