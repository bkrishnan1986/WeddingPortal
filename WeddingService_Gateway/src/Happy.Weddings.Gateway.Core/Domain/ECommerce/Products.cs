using System;
using System.Collections.Generic;

namespace Happy.Weddings.Gateway.Core.Domain.ECommerce
{

        public partial class Products
        {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string About { get; set; }
        public int? BatchNo { get; set; }
        public string Image { get; set; }
        public float? Price { get; set; }
        public float? StarRate { get; set; }
        public short IsReturnable { get; set; }
        public DateTime? ExpDate { get; set; }
        public string BarCode { get; set; }
        public short? Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
    
}
