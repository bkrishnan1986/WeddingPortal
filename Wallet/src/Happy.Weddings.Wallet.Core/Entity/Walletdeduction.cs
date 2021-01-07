using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Wallet.Core.Entity
{
    public partial class Walletdeduction
    {
        public int Id { get; set; }
        public int LeadId { get; set; }
        public int VendorId { get; set; }
        public int? CustomerId { get; set; }
        public int CategoryId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public decimal WalletBalance { get; set; }
        public int WalletStatus { get; set; }
        public decimal DeductedAmount { get; set; }
        public DateTime DeductedDate { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Multidetail Category { get; set; }
        public virtual Multidetail WalletStatusNavigation { get; set; }
    }
}
