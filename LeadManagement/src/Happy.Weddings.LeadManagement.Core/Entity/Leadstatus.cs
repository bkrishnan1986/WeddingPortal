using System;
using System.Collections.Generic;

namespace Happy.Weddings.LeadManagement.Core.Entity
{
    public partial class Leadstatus
    {
        public int Id { get; set; }
        public int LeadId { get; set; }
        public int LeadStatusId { get; set; }
        public DateTime Date { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Leads Lead { get; set; }
        public virtual Multidetail LeadStatus { get; set; }
    }
}
