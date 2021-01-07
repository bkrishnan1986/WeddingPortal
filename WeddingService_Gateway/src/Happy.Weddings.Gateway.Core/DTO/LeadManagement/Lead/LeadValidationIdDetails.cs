using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead
{
    public class LeadValidationIdDetails
    {
        public int LeadValidationId { get; set; }
        public LeadValidationIdDetails(int leadValidationId)
        {
            LeadValidationId = leadValidationId;
        }
    }
}
