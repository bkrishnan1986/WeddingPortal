using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.WalletAdjustment
{
    public class CreateWalletAdjustmentRequest
    {
        public int VendorId { get; set; }
        public int AdjustmentType { get; set; }
        public decimal AdjustmentAmount { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
    }
}
