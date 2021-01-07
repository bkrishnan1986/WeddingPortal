using System;
using System.Collections.Generic;

namespace Happy.Weddings.Identity.Core.Entity
{
    public partial class Rolesettings
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string RolePermissions { get; set; }
        public string Description { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Multidetail Role { get; set; }
    }
}
