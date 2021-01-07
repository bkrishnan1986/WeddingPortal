using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead
{
    public class CreateLeadRequest
    {
        public DateTime? EventDate { get; set; }
        public int? EventLocation { get; set; }
        public string LeadId { get; set; }
        public int Owner { get; set; }
        public string Description { get; set; }
        public int LeadType { get; set; }
        public int EventType { get; set; }
        public int Category { get; set; }
        public int? LeadStatusId { get; set; }
        public int LeadMode { get; set; }
        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }
        public decimal? Cplvalue { get; set; }
        public decimal? CommisionValue { get; set; }
        public int? WalletStatus { get; set; }
        public int LeadQuality { get; set; }
        public int CreatedBy { get; set; }

        public List<CreateLeadStatusRequest> LeadStatus { get; set; }
    }
}
