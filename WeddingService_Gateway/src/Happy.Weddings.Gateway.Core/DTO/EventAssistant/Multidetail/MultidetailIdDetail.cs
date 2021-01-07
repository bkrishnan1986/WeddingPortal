using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.EventAssistant.Multidetail
{
    public class MultidetailIdDetail
    {
        public int MultidetailId { get; set; }
        public MultidetailIdDetail(int multidetailId)
        {
            MultidetailId = multidetailId;
        }
    }
}
