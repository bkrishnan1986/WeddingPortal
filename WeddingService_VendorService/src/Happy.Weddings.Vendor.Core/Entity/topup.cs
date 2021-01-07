using System;
using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.Entity
{
    public partial class Topup
    {
        public Topup()
        {
            Servicetopup = new HashSet<Servicetopup>();
            Topupbenefit = new HashSet<Topupbenefit>();
        }

        public int Id { get; set; }
        public int TopUpType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Mode { get; set; }
        public decimal Price { get; set; }
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

        public virtual Multidetail ModeNavigation { get; set; }
        public virtual Multidetail TopUpTypeNavigation { get; set; }
        public virtual ICollection<Servicetopup> Servicetopup { get; set; }
        public virtual ICollection<Topupbenefit> Topupbenefit { get; set; }
    }
}
