using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead
{
    public class LeadQuote
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public int LeadType { get; set; }
        public int SubLeadType { get; set; }
        public decimal? QuotedRate { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
    }
    public class CreateLeadQuoteRequest
    {
        public List<LeadQuote> LeadQuotes { get; set; }
    }
}
