﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.WalletRule
{
    public class WalletRuleResponse
    {
        public int Id { get; set; }
        public string ServiceCode { get; set; }
        public int ServiceCategoryId { get; set; }
        public string ServiceCategory { get; set; }
        public int Mode { get; set; }
        public string ModeValue { get; set; }
        public decimal? Cplamount { get; set; }
        public decimal? CommissionAmount { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
