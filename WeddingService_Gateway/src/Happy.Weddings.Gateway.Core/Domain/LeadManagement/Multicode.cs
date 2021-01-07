using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.Domain.LeadManagement
{
    public class Multicode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string SystemCode { get; set; }
        public string Description { get; set; }
        public short? IsRequired { get; set; }
        public short Active { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
