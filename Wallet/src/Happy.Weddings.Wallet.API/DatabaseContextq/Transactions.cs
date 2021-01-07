using System;
using System.Collections.Generic;

namespace Happy.Weddings.Wallet.API.DatabaseContextq
{
    public partial class Transactions
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
        public virtual Wallet Wallet { get; set; }
    }
}
