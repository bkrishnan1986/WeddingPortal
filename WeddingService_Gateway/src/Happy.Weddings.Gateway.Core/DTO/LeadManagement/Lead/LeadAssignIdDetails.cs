﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead
{
    public class LeadAssignIdDetails
    {
        public int LeadAssignId { get; set; }
        public LeadAssignIdDetails(int leadAssignId)
        {
            LeadAssignId = leadAssignId;
        }
    }
}
