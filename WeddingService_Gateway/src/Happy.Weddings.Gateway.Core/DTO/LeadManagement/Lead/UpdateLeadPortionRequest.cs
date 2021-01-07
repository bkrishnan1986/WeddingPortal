using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead
{
    public class UpdateLeadPortionRequest
    {
        public int LeadQuality { get; set; }
        public int LeadStatus { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime Date { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
