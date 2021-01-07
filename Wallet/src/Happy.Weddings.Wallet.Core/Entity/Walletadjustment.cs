using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Wallet.Core.Entity
{
    public partial class Walletadjustment
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public int AdjustmentType { get; set; }
        public decimal AdjustmentAmount { get; set; }
        public string Remarks { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Multidetail AdjustmentTypeNavigation { get; set; }
    }
}
