using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead
{
    public class UpdateLeadQuoteRequest
    {
        public decimal? QuotedRate { get; set; }
        public int UpdatedBy { get; set; }
    }
}
