using Happy.Weddings.Vendor.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.Utility
{
    public class SubscriptionUtilityParameters
    {
        public string VendorId { get; set; }

        public int BenefitId { get; set; }

        public int? ServiceSubscriptionId { get; set; }

        public int? TopupId { get; set; }
    }
}
