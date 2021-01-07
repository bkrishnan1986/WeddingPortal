using System;
using System.Collections.Generic;

namespace Happy.Weddings.LeadManagement.Core.Entity
{
    public partial class Leadassign
    {
        public int Id { get; set; }
        public int LeadId { get; set; }
        public DateTime? LeadSentDate { get; set; }
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public int? Category { get; set; }
        public decimal? ProposedBudget { get; set; }
        public int? Packs { get; set; }
        public string Remarks { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Multidetail CategoryNavigation { get; set; }
        public virtual Leads Lead { get; set; }
    }
}
