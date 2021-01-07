using System;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.WalletStatus
{
    public class WalletStatusResponse
    {
        public int Id { get; set; }
        public int WalletId { get; set; }
        public string Action { get; set; }
        public int Status { get; set; }
        public string StatusValue { get; set; }
        public string Reason { get; set; }
        public DateTime? StatusDate { get; set; }
        public short Active { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class WalletStatusResponseData
    {
        public int WalletId { get; set; }
        public int WalletStatusId { get; set; }
    }
}
