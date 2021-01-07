using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.Refund
{
    public class RefundParameter
    {
        public int Value { get; set; }
        public bool IsforSingleRefund { get; set; }
        public bool IsforRaisedBy { get; set; }
    }
}
