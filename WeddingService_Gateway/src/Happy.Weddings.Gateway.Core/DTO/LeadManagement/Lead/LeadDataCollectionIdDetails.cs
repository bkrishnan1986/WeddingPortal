using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead
{
    public class LeadDataCollectionIdDetails
    {
        public int LeadCollectionId { get; set; }
        public LeadDataCollectionIdDetails(int leadCollectionId)
        {
            LeadCollectionId = leadCollectionId;
        }
    }
}
