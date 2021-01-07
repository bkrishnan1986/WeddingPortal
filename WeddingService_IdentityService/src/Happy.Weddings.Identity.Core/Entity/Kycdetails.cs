﻿using System;
using System.Collections.Generic;

namespace Happy.Weddings.Identity.Core.Entity
{
    public partial class Kycdetails
    {
        public int Id { get; set; }
        public int Kycid { get; set; }
        public string KycdocPath { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Kycdata Kyc { get; set; }
    }
}
