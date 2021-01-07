using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.Refund
{
    public class RefundIdDetails
    {
        public int RefundId { get; set; }
        public bool IsApproved { get; set; }
        public bool IsRejected { get; set; }
        public RefundIdDetails(int refundId, bool isApproved = false, bool isRejected = false)
        {
            RefundId = refundId;
            IsApproved = isApproved;
            IsRejected = isRejected;
        }
    }
}
