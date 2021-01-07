using System;
using System.Collections.Generic;

namespace Happy.Weddings.LeadManagement.Core.Entity
{
    public partial class Leadquote
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public int LeadId { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public int LeadType { get; set; }
        public int SubLeadType { get; set; }
        public decimal? QuotedRate { get; set; }
        public short IsSelected { get; set; }
        public short Active { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Leads Lead { get; set; }
        public virtual Multidetail LeadTypeNavigation { get; set; }
        public virtual Multidetail SubLeadTypeNavigation { get; set; }
    }
}
