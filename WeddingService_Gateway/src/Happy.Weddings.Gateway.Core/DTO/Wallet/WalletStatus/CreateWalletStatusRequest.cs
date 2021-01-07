using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.WalletStatus
{
    public class CreateWalletStatusRequest
    {
        public int WalletId { get; set; }
        public string Action { get; set; }
        public string Reason { get; set; }
        public int CreatedBy { get; set; }
    }
}
