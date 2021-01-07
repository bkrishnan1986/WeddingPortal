using Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.LeadManagement
{
    public class CreateLeadAssignRequest
    {
        public DateTime? LeadSentDate { get; set; }
        public int VendorId { get; set; }
        public int? Category { get; set; }
        public decimal? ProposedBudget { get; set; }
        public int? Packs { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<CreateLeadStatusRequest> LeadStatusRequest { get; set; }
    }
}
