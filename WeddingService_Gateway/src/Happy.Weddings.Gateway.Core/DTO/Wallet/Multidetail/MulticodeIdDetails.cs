﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.Multidetail
{
    public class MulticodeIdDetails
    {
        public int MulticodeId { get; set; }
        public MulticodeIdDetails(int multicodeId)
        {
            MulticodeId = multicodeId;
        }
    }
}
