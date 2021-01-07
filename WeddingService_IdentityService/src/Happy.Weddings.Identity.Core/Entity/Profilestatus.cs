using System;
using System.Collections.Generic;

namespace Happy.Weddings.Identity.Core.Entity
{
    public partial class Profilestatus
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int ProfileStatusId { get; set; }
        public DateTime Date { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Profile Profile { get; set; }
        public virtual Multidetail ProfileStatus { get; set; }
    }
}
