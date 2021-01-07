using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.Utility
{
    public class UpdateUtilityRequest
    {
        public int ServiceSubscriptionId { get; set; }
        public int? ServiceTopupId { get; set; }
        public int Benefit { get; set; }
        public string VendorId { get; set; }
        public int UtilityCount { get; set; }
        public int UpdatedBy { get; set; }
    }
}
