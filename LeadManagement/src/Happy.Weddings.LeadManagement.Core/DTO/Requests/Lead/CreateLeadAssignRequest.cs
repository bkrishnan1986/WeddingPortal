#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | CreateAssignLeadRequest class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead;
using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead
{
    public class CreateLeadAssignRequest
    {
        public DateTime? LeadSentDate { get; set; }
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public int? Category { get; set; }
        public decimal? ProposedBudget { get; set; }
        public int? Packs { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<CreateLeadStatusRequest> LeadStatusRequest { get; set; }
    }
}
