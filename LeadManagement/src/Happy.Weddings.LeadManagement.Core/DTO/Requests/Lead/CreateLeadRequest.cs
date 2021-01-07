#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | CreateLeadRequest class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead
{
    public class CreateLeadRequest
    {
        public DateTime? EventDate { get; set; }
        public int EventLocation { get; set; }
        public string LeadId { get; set; }
        public int Owner { get; set; }
        public string OwnerName { get; set; }
        public string Description { get; set; }
        public int LeadType { get; set; }
        public int EventType { get; set; }
        public int LeadStatusId { get; set; }
        public int LeadMode { get; set; }
        public int Category { get; set; }
        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }
        public decimal? Cplvalue { get; set; }
        public decimal? CommisionValue { get; set; }
        public int? WalletStatus { get; set; }
        public int? LeadQuality { get; set; }
        public int CreatedBy { get; set; }
        public List<CreateLeadStatusRequest> LeadStatus { get; set; }
    }
}
