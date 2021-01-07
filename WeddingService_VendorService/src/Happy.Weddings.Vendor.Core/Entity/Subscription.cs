using System;
using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.Entity
{
    public partial class Subscription
    {
        public Subscription()
        {
            InverseParentsubscription = new HashSet<Subscription>();
            Servicesubscription = new HashSet<Servicesubscription>();
            Subscriptionbenefit = new HashSet<Subscriptionbenefit>();
            Subscriptionlocation = new HashSet<Subscriptionlocation>();
            Subscriptionoffer = new HashSet<Subscriptionoffer>();
            Suggestionlist = new HashSet<Suggestionlist>();
        }

        public int Id { get; set; }
        public int? ParentsubscriptionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Mode { get; set; }
        public decimal RegistrationFee { get; set; }
        public decimal ServiceFee { get; set; }
        public int? CgstRatePercentage { get; set; }
        public decimal? Cgstamount { get; set; }
        public int? SgstRatePercentage { get; set; }
        public decimal? Sgstamount { get; set; }
        public int? IgstRatePercentage { get; set; }
        public decimal? Igstamount { get; set; }
        public int? GstRatePercentage { get; set; }
        public decimal? Gstamount { get; set; }
        public decimal? Cplamount { get; set; }
        public decimal? CommissionAmount { get; set; }
        public decimal TotalPrice { get; set; }
        public int Validity { get; set; }
        public int ValidityUnit { get; set; }
        public int ApprovalStatus { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Multidetail ApprovalStatusNavigation { get; set; }
        public virtual Multidetail ModeNavigation { get; set; }
        public virtual Subscription Parentsubscription { get; set; }
        public virtual Multidetail ValidityUnitNavigation { get; set; }
        public virtual ICollection<Subscription> InverseParentsubscription { get; set; }
        public virtual ICollection<Servicesubscription> Servicesubscription { get; set; }
        public virtual ICollection<Subscriptionbenefit> Subscriptionbenefit { get; set; }
        public virtual ICollection<Subscriptionlocation> Subscriptionlocation { get; set; }
        public virtual ICollection<Subscriptionoffer> Subscriptionoffer { get; set; }
        public virtual ICollection<Suggestionlist> Suggestionlist { get; set; }
    }
}
