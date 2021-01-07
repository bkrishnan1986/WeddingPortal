using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.Utility
{
    public class CreateUtilityRequest
    {
        public int? ServiceSubscriptionId { get; set; }
        public int? ServiceTopupId { get; set; }
        public int Benefit { get; set; }
        public string VendorId { get; set; }
        public int UtilityCount { get; set; }
        public int CreatedBy { get; set; }
    }
}
