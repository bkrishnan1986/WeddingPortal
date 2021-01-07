using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.LeadManagement.Core.DTO.Responses
{
    public class LeadAssignResponse
    {
        public int Id { get; set; }
        public int LeadId { get; set; }
        public DateTime? LeadSentDate { get; set; }
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public int? Category { get; set; }
        public string CategoryName { get; set; }
        public decimal? ProposedBudget { get; set; }
        public int? Packs { get; set; }
        public string Remarks { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class LeadAssignDetailResponse : LeadAssignResponse
    {
        public LeadsResponse1 Lead { get; set; }
    }

    public class LeadsResponse1
    {
        public int Id { get; set; }
        public int DataCollectionId { get; set; }
        public string CustomerId { get; set; }
        public DateTime? EventDate { get; set; }
        public int? EventLocation { get; set; }
        public string EventLocationName { get; set; }
        public string LeadId { get; set; }
        public int Owner { get; set; }
        public string Description { get; set; }
        public int LeadType { get; set; }
        public string LeadTypeName { get; set; }
        public int EventType { get; set; }
        public string EventTypeName { get; set; }
        public int LeadMode { get; set; }
        public string LeadModeName { get; set; }
        public int Category { get; set; }
        public string CategoryName { get; set; }
        public int LeadStatusId { get; set; }
        public string LeadStatusName { get; set; }
        public int? LeadQuality { get; set; }
        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }
        public decimal? Cplvalue { get; set; }
        public decimal? CommisionValue { get; set; }
        public int? WalletStatus { get; set; }
        public string WalletStatusName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? UpdatedBy { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? UpdatedAt { get; set; }

        public List<LeadStatusResponse> Leadstatus { get; set; }

        public List<LeadValidationResponse> Leadvalidation { get; set; }

        public List<LeadQuoteResponse> Leadquote { get; set; }

    }
}
