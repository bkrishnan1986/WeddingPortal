using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead
{
    public class LeadQuoteIdDetails
    {
        public int LeadQuoteId { get; set; }
        public LeadQuoteIdDetails(int leadQuoteId)
        {
            LeadQuoteId = leadQuoteId;
        }
    }
}
