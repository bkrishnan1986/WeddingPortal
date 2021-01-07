using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead
{
    public class CreateLeadStatusRequest
    {
        public int LeadStatusId { get; set; }
        public DateTime Date { get; set; }
        public int CreatedBy { get; set; }
    }
}
