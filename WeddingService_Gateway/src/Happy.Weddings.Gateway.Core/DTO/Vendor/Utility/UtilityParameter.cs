using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.Utility
{
    public class UtilityParameter
    {
        public string VendorId { get; set; }

        public int BenefitId { get; set; }

        public int? ServiceSubscriptionId { get; set; }

        public int? TopupId { get; set; }
    }
}
