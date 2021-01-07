using System;
using System.Collections.Generic;

namespace Happy.Weddings.Gateway.Core.Domain.ECommerce
{

    public partial class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Status { get; set; }
        public float Price { get; set; }
        public int Qty { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

