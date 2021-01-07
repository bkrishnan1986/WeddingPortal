using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.Domain.Wallet
{
    public class Wallet
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public int Status { get; set; }
        public string StatusValue { get; set; }
        public decimal Balance { get; set; }
        public short Active { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
