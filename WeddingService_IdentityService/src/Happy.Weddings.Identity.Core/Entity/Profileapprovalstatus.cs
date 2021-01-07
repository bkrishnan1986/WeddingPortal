using System;
using System.Collections.Generic;

namespace Happy.Weddings.Identity.Core.Entity
{
    public partial class Profileapprovalstatus
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int ApprovalStatusId { get; set; }
        public DateTime Date { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Multidetail ApprovalStatus { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
