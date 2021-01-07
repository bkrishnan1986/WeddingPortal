using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Blog.Multidetail
{
    public class UpdateMultidetailBlogRequest
    {
        public string Value { get; set; }
        public string Description { get; set; }
        public int UpdatedBy { get; set; }
    }
}
