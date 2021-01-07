using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Blog.Multidetail
{
    public class MulticodeIdDetails
    {
        public string MulticodeId { get; set; }
        public MulticodeIdDetails(string multicodeId)
        {
            MulticodeId = multicodeId;
        }
    }
}
