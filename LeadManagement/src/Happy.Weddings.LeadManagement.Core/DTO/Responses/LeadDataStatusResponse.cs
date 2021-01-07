using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.LeadManagement.Core.DTO.Responses
{
    public class LeadDataStatusResponse : LeadStatusResponse
    {
        public string LeadName { get; set; }

        public string StatusName { get; set; }
    }
}
