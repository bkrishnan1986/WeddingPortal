using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.ECommerce.Multidetail
{
    public class MulticodeIdDetail
    {
        public int MulticodeId { get; set; }
        public MulticodeIdDetail(int multicodeId)
        {
            MulticodeId = multicodeId;
        }
    }
}
