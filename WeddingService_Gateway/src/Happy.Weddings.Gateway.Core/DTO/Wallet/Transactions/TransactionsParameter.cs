using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.Transactions
{
    public class TransactionsParameter
    {
        public int Value { get; set; }
        public bool IsForVendor { get; set; }
        public bool IsForWallet { get; set; }
        public string ReferenceNo { get; set; }
        public int TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
