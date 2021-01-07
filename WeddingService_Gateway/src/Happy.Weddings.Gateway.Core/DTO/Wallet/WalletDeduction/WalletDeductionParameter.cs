using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.WalletDeduction
{
    public class WalletDeductionParameter
    {
        public int Value { get; set; }
        public bool IsForSingleDeduction { get; set; }
        public bool IsForLeadId { get; set; }
        public bool IsForVendorId { get; set; }
    }
}
