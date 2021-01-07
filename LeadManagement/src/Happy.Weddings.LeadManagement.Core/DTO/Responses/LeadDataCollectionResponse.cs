#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | LeadController class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Happy.Weddings.LeadManagement.Core.DTO.Responses
{
    public class LeadDataCollectionResponse
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone1 { get; set; }
        public string CustomerPhone2 { get; set; }
        public string CustomerLocation { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? UpdatedBy { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? UpdatedAt { get; set; }

        public List<LeadsResponse> Leads { get; set; }
    }
    public class LeadsResponse
    {
        public int Id { get; set; }
        public int DataCollectionId { get; set; }
        public string CustomerId { get; set; }
        public DateTime? EventDate { get; set; }
        public int? EventLocation { get; set; }
        public string EventLocationName { get; set; }
        public string LeadId { get; set; }
        public int Owner { get; set; }
        public string OwnerName { get; set; }
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
        public string CustomerPhone1 { get; set; }
        public string CustomerPhone2 { get; set; }
        public string CustomerEmail { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? UpdatedBy { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? UpdatedAt { get; set; }

        public List<LeadValidationResponse> Leadvalidation { get; set; }

        public List<LeadAssignResponse> Leadassign { get; set; }

        public List<LeadQuoteResponse> Leadquote { get; set; }

    }
    public class LeadStatusResponse
    {
        public int Id { get; set; }
        public int LeadId { get; set; }
        public string LeadName { get; set; }
        public int LeadStatusId { get; set; }

        public string StatusName { get; set; }
        public DateTime Date { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? UpdatedBy { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? UpdatedAt { get; set; }
    }
}
