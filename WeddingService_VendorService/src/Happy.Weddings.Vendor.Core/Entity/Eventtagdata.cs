using System;

namespace Happy.Weddings.Vendor.Core.Entity
{
    public partial class Eventtagdata
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int TagId { get; set; }
        public string TagName { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Events Event { get; set; }
    }
}
