using System;
using System.Collections.Generic;

namespace Happy.Weddings.LeadManagement.Core.Entity
{
    public partial class Leads
    {
        public Leads()
        {
            Leadassign = new HashSet<Leadassign>();
            Leadquote = new HashSet<Leadquote>();
            Leadstatus = new HashSet<Leadstatus>();
            Leadvalidation = new HashSet<Leadvalidation>();
        }

        public int Id { get; set; }
        public int DataCollectionId { get; set; }
        public DateTime? EventDate { get; set; }
        public int EventLocation { get; set; }
        public string LeadId { get; set; }
        public int Owner { get; set; }
        public string OwnerName { get; set; }
        public string Description { get; set; }
        public int LeadType { get; set; }
        public int EventType { get; set; }
        public int LeadMode { get; set; }
        public int Category { get; set; }
        public int LeadStatusId { get; set; }
        public int? LeadQuality { get; set; }
        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }
        public decimal? Cplvalue { get; set; }
        public decimal? CommisionValue { get; set; }
        public int? WalletStatus { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Multidetail CategoryNavigation { get; set; }
        public virtual Leaddatacollection DataCollection { get; set; }
        public virtual Multidetail EventLocationNavigation { get; set; }
        public virtual Multidetail EventTypeNavigation { get; set; }
        public virtual Multidetail LeadModeNavigation { get; set; }
        public virtual Multidetail LeadQualityNavigation { get; set; }
        public virtual Multidetail Status { get; set; }
        public virtual Multidetail LeadTypeNavigation { get; set; }
        public virtual Multidetail WalletStatusNavigation { get; set; }
        public virtual ICollection<Leadassign> Leadassign { get; set; }
        public virtual ICollection<Leadquote> Leadquote { get; set; }
        public virtual ICollection<Leadstatus> Leadstatus { get; set; }
        public virtual ICollection<Leadvalidation> Leadvalidation { get; set; }
    }
}
