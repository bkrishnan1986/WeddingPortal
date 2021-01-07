using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Wallet.Core.DTO.Requests.Transactions
{
    public class CreateTransactionsRequest
    {
        public int WalletId { get; set; }
        public string ReferenceNo { get; set; }
        public string Particulars { get; set; }
        public DateTime TransactionDate { get; set; }
        public int TransactionType { get; set; }
        public decimal Amount { get; set; }
        public decimal WalletBalance { get; set; }
        public int CreatedBy { get; set; }
    }
}
