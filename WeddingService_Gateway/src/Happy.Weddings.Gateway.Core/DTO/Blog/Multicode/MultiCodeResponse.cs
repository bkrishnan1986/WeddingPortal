using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Blog.Multicode
{
    public class MultiCodeResponse
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string SystemCode { get; set; }
        public string Description { get; set; }
        public short IsRequired { get; set; }
        public short Active { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
