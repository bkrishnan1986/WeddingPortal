﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.Multicode
{
    public class MulticodeIdDetails
    {
        public string Code { get; set; }
        public MulticodeIdDetails(string code)
        {
            Code = code;
        }
    }
}
