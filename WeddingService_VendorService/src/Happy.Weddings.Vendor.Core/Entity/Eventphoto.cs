using System;

namespace Happy.Weddings.Vendor.Core.Entity
{
    public partial class Eventphoto
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string Photo { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Events Event { get; set; }
    }
}
