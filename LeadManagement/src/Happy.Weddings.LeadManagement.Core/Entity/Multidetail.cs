using System;
using System.Collections.Generic;

namespace Happy.Weddings.LeadManagement.Core.Entity
{
    public partial class Multidetail
    {
        public Multidetail()
        {
            Leadassign = new HashSet<Leadassign>();
            LeadquoteLeadTypeNavigation = new HashSet<Leadquote>();
            LeadquoteSubLeadTypeNavigation = new HashSet<Leadquote>();
            LeadsCategoryNavigation = new HashSet<Leads>();
            LeadsEventLocationNavigation = new HashSet<Leads>();
            LeadsEventTypeNavigation = new HashSet<Leads>();
            LeadsLeadModeNavigation = new HashSet<Leads>();
            LeadsLeadQualityNavigation = new HashSet<Leads>();
            LeadsLeadStatus = new HashSet<Leads>();
            LeadsLeadTypeNavigation = new HashSet<Leads>();
            LeadsWalletStatusNavigation = new HashSet<Leads>();
            Leadstatus = new HashSet<Leadstatus>();
            Leadvalidation = new HashSet<Leadvalidation>();
        }

        public int Id { get; set; }
        public int MultiCodeId { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Multicode MultiCode { get; set; }
        public virtual ICollection<Leadassign> Leadassign { get; set; }
        public virtual ICollection<Leadquote> LeadquoteLeadTypeNavigation { get; set; }
        public virtual ICollection<Leadquote> LeadquoteSubLeadTypeNavigation { get; set; }
        public virtual ICollection<Leads> LeadsCategoryNavigation { get; set; }
        public virtual ICollection<Leads> LeadsEventLocationNavigation { get; set; }
        public virtual ICollection<Leads> LeadsEventTypeNavigation { get; set; }
        public virtual ICollection<Leads> LeadsLeadModeNavigation { get; set; }
        public virtual ICollection<Leads> LeadsLeadQualityNavigation { get; set; }
        public virtual ICollection<Leads> LeadsLeadStatus { get; set; }
        public virtual ICollection<Leads> LeadsLeadTypeNavigation { get; set; }
        public virtual ICollection<Leads> LeadsWalletStatusNavigation { get; set; }
        public virtual ICollection<Leadstatus> Leadstatus { get; set; }
        public virtual ICollection<Leadvalidation> Leadvalidation { get; set; }
    }
}
