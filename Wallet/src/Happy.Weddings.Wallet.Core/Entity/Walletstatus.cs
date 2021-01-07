using System;
using System.Collections.Generic;

namespace Happy.Weddings.Wallet.Core.Entity
{
    public partial class Walletstatus
    {

        public int Id { get; set; }
        public int WalletId { get; set; }
        public string Action { get; set; }
        public int Status { get; set; }
        public string Reason { get; set; }
        public DateTime StatusDate { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Multidetail StatusNavigation { get; set; }
        public virtual Wallets Wallet { get; set; }

    }
}
