using System;
using System.Collections.Generic;

namespace Happy.Weddings.Identity.Core.Entity
{
    public partial class Companydistricts
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int District { get; set; }
        public short Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual Multidetail DistrictNavigation { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
