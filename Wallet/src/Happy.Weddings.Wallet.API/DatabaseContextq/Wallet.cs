using System;
using System.Collections.Generic;

namespace Happy.Weddings.Wallet.API.DatabaseContextq
{
    public partial class Wallet
    {
        public Wallet()
        {
            Transactions = new HashSet<Transactions>();
            Walletstatus = new HashSet<Walletstatus>();
        }

        public int Id { get; set; }
        public int VendorId { get; set; }
        public int Status { get; set; }
        public decimal Balance { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Multidetail StatusNavigation { get; set; }
        public virtual ICollection<Transactions> Transactions { get; set; }
        public virtual ICollection<Walletstatus> Walletstatus { get; set; }
    }
}
