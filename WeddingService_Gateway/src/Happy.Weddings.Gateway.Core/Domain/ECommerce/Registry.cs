using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.Domain.ECommerce
{

        public partial class Registry
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int UserId { get; set; }
            public int ProductId { get; set; }
            public short Active { get; set; }
            public int CreatedBy { get; set; }
            public DateTime CreatedAt { get; set; }
            public int? UpdatedBy { get; set; }
            public DateTime? UpdatedAt { get; set; }
        }
}
