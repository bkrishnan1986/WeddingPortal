using System;
using System.Collections.Generic;

namespace Happy.Weddings.Wallet.API.DatabaseContextq
{
    public partial class Multidetail
    {
        public Multidetail()
        {
            PaymentbookBhstatusNavigation = new HashSet<Paymentbook>();
            PaymentbookFinanceApprovalStatusNavigation = new HashSet<Paymentbook>();
            PaymentbookPackageTypeNavigation = new HashSet<Paymentbook>();
            PaymentbookPaymentModeNavigation = new HashSet<Paymentbook>();
            PaymentbookPaymentStatusNavigation = new HashSet<Paymentbook>();
            PaymentbookPaymentTypeNavigation = new HashSet<Paymentbook>();
            Refund = new HashSet<Refund>();
            Transactions = new HashSet<Transactions>();
            Wallet = new HashSet<Wallet>();
            Walletadjustment = new HashSet<Walletadjustment>();
            WalletdeductionCategory = new HashSet<Walletdeduction>();
            WalletdeductionWalletStatusNavigation = new HashSet<Walletdeduction>();
            Walletrule = new HashSet<Walletrule>();
            Walletstatus = new HashSet<Walletstatus>();
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
        public virtual ICollection<Paymentbook> PaymentbookBhstatusNavigation { get; set; }
        public virtual ICollection<Paymentbook> PaymentbookFinanceApprovalStatusNavigation { get; set; }
        public virtual ICollection<Paymentbook> PaymentbookPackageTypeNavigation { get; set; }
        public virtual ICollection<Paymentbook> PaymentbookPaymentModeNavigation { get; set; }
        public virtual ICollection<Paymentbook> PaymentbookPaymentStatusNavigation { get; set; }
        public virtual ICollection<Paymentbook> PaymentbookPaymentTypeNavigation { get; set; }
        public virtual ICollection<Refund> Refund { get; set; }
        public virtual ICollection<Transactions> Transactions { get; set; }
        public virtual ICollection<Wallet> Wallet { get; set; }
        public virtual ICollection<Walletadjustment> Walletadjustment { get; set; }
        public virtual ICollection<Walletdeduction> WalletdeductionCategory { get; set; }
        public virtual ICollection<Walletdeduction> WalletdeductionWalletStatusNavigation { get; set; }
        public virtual ICollection<Walletrule> Walletrule { get; set; }
        public virtual ICollection<Walletstatus> Walletstatus { get; set; }
    }
}
