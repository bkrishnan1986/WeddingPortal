using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.LeadManagement.Multidetail
{
    public class MultidetailIdDetails
    {
        public int MultidetailId { get; set; }
        public MultidetailIdDetails(int multidetailId)
        {
            MultidetailId = multidetailId;
        }
    }
}
