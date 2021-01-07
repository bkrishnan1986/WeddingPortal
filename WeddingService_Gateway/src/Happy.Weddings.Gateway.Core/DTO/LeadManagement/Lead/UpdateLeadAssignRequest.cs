using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead
{
    public class UpdateLeadAssignRequest
    {
        public int? Category { get; set; }
        public decimal? ProposedBudget { get; set; }
        public int? Packs { get; set; }
        public string Remarks { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
