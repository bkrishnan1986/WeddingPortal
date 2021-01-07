using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Wallet.Core.Entity
{
    public class Transactions
    {
        public int Id { get; set; }
        public int WalletId { get; set; }
        public string ReferenceNo { get; set; }
        public string Particulars { get; set; }
        public DateTime TransactionDate { get; set; }
        public int TransactionType { get; set; }
        public decimal Amount { get; set; }
        public decimal WalletBalance { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Multidetail TransactionTypeNavigation { get; set; }
        public virtual Wallets Wallet { get; set; }
    }
}
