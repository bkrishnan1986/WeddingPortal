using System;

namespace Happy.Weddings.Vendor.Core.Entity
{
    public partial class Subscriptionlocation
    {
        public int Id { get; set; }
        public int SubscriptionId { get; set; }
        public int LocationId { get; set; }
        public int CategoryId { get; set; }
        public int PackageType { get; set; }
        public int? Mode { get; set; }
        public decimal? RegistrationFee { get; set; }
        public decimal? ServiceFee { get; set; }
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
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Multidetail Category { get; set; }
        public virtual Multidetail Location { get; set; }
        public virtual Multidetail ModeNavigation { get; set; }
        public virtual Multidetail PackageTypeNavigation { get; set; }
        public virtual Subscription Subscription { get; set; }
    }
}
