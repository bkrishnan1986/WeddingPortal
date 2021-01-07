using System;
using System.Collections.Generic;

namespace Happy.Weddings.Identity.Core.Entity
{
    public partial class Profilepermission
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int RoleId { get; set; }
        public string ProfilePermissions { get; set; }
        public string Description { get; set; }
        public short Active { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
