using System;
using System.Collections.Generic;

namespace Happy.Weddings.Gateway.Core.Domain.ECommerce
{

    public partial class Orderlocation
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Lanmark { get; set; }
        public string Pincode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

