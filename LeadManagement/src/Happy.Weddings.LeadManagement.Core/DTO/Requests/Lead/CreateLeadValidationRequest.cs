#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | CreateFollowLeadRequest class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead
{
    public class CreateLeadValidationRequest
    {
        public int LeadId { get; set; }
        public int CalledBy { get; set; }
        public DateTime CalledOn { get; set; }
        public int Status { get; set; }
        public string Remark { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public string CallRecordings { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
