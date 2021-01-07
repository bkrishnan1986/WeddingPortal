using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.Domain.LeadManagement
{
    public class Leadassign
    {
        public int Id { get; set; }
        public int LeadId { get; set; }
        public DateTime? LeadSentDate { get; set; }
        public int VendorId { get; set; }
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
