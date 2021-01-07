using System;
using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.Entity
{
    public partial  class Branchserviceoffered
    {
        public Branchserviceoffered()
        {
            Categorydetails = new HashSet<Categorydetails>();
        }

        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int BranchId { get; set; }
        public string ContactPerson { get; set; }
        public string PrimaryMobileNumber { get; set; }
        public string EmailId { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Branches Branch { get; set; }
        public virtual Multidetail Service { get; set; }
        public virtual ICollection<Categorydetails> Categorydetails { get; set; }
    }
}
