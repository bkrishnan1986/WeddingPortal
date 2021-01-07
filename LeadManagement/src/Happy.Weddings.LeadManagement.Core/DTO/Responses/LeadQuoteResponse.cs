﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.LeadManagement.Core.DTO.Responses
{
    public class LeadQuoteResponse
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public int LeadId { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public int LeadType { get; set; }
        public string LeadTypeName { get; set; }
        public int SubLeadType { get; set; }
        public string SubLeadTypeName { get; set; }
        public decimal? QuotedRate { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
