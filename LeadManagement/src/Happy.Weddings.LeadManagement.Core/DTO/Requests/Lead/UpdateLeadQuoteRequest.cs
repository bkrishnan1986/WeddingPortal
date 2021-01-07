using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead
{
    public class UpdateLeadQuoteRequest
    {
        public decimal? QuotedRate { get; set; }
        public short IsSelected { get; set; }
        public int UpdatedBy { get; set; }
    }
}
