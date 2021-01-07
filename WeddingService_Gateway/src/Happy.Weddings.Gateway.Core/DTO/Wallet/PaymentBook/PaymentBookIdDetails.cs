using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.PaymentBook
{
    public class PaymentBookIdDetails
    {
        public int PaymentBookId { get; set; }
        public PaymentBookIdDetails(int paymentBookId)
        {
            PaymentBookId = paymentBookId;
        }
    }
}
