using System;

namespace Happy.Weddings.Gateway.Core.Domain.Identity
{
    public partial class Companydistricts
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int District { get; set; }
        public short? Active { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
