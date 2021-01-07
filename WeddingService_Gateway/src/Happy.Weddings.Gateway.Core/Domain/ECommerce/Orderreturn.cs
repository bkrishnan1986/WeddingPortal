using System;
using System.Collections.Generic;

namespace Happy.Weddings.Gateway.Core.Domain.ECommerce
{
    public partial class Orderreturn
    {
        public int Id { get; set; }
        public int OrderdetailId { get; set; }
        public string Reason { get; set; }
        public string Conclusion { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
