﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Identity.Multidetail
{
    public class MultidetailIdDetails
    {
        public int MultidetailId { get; set; }
        public MultidetailIdDetails(int multidetailId)
        {
            MultidetailId = multidetailId;
        }
    }
}
