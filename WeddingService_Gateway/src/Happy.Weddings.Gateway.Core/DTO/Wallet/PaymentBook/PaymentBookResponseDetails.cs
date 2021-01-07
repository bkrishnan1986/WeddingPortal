using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.Domain.Wallet;
using Newtonsoft.Json;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.PaymentBook
{
    public class PaymentBookResponseDetails : PaymentBookResponse
    {
        /// <summary>
        /// Gets or sets the PaymentBook.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Domain.Wallet.PaymentBook> PaymentBook { get; set; }
    }
}
