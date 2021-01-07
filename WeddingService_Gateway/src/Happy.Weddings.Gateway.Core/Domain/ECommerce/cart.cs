using System;
using System.Collections.Generic;

namespace Happy.Weddings.Gateway.Core.Domain.ECommerce
{

        public partial class Carts
        {
            public int Id { get; set; }
            public int UserId { get; set; }
            public int ProductId { get; set; }
            public int Quantity { get; set; }
            public float Price { get; set; }
            public short Active { get; set; }
            public int CreatedBy { get; set; }
            public DateTime CreatedAt { get; set; }
            public int? UpdatedBy { get; set; }
            public DateTime? UpdatedAt { get; set; }
        }
    }

