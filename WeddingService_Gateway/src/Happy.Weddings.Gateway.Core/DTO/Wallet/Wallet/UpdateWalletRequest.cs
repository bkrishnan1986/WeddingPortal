using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.Wallet
{
    public class UpdateWalletRequest
    {
        public int Status { get; set; }
        public decimal Balance { get; set; }
        public int UpdatedBy { get; set; }
    }
}
