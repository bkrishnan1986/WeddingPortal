using Happy.Weddings.LeadManagement.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead
{
    public class LeadCountTotAmtParameter 
    {
        public bool IsForCPCLeadAssigned { get; set; }

        public bool IsForCommisionLeadAssigned { get; set; }
    }
}
