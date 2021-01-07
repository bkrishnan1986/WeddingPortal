﻿#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | UpdateLeadPortionRequest class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead
{
    public class UpdateLeadPortionRequest
    {
        public int? LeadQuality { get; set; }
        public int LeadStatus { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime Date { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
