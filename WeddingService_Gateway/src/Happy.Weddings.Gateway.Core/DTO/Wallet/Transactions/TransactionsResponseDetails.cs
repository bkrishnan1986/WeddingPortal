using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.Domain.Wallet;
using Newtonsoft.Json;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.Transactions
{
    public class TransactionsResponseDetails : TransactionsResponse
    {
        /// <summary>
        /// Gets or sets the Transactions.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Domain.Wallet.Transactions> Transactions { get; set; }
    }
}
