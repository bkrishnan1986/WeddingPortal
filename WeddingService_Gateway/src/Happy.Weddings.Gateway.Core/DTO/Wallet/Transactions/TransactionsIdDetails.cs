using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.Transactions
{
    public class TransactionsIdDetails
    {
        public int TransactionsId { get; set; }
        public TransactionsIdDetails(int transactionsId)
        {
            TransactionsId = transactionsId;
        }
    }
}
