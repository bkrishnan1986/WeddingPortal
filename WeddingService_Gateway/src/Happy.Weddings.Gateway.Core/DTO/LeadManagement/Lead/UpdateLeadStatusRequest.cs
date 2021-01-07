using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead
{
    public class UpdateLeadStatusRequest
    {
        public int LeadStatusId { get; set; }
        public DateTime Date { get; set; }
        public short Active { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
