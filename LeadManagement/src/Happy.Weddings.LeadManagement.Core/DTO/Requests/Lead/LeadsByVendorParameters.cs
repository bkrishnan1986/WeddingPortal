#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  16-Nov-2020 |    Nikhil K Das      | Created and implemented. 
//              |                   | LeadsByVendorParameters class.
//----------------------------------------------------------------------------------------------

#endregion File Header

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.LeadManagement.Core.Domain;

namespace Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead
{
    public class LeadsByVendorParameters
    {
        public string VendorId { get; set; }
        public bool IsForAssignedLead { get; set; }
        public bool IsForQuotedLead { get; set; }
    }
}
