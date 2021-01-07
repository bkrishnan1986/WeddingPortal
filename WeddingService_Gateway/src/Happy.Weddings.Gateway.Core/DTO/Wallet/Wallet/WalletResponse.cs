using System;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.Wallet
{
    public class WalletResponse
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
