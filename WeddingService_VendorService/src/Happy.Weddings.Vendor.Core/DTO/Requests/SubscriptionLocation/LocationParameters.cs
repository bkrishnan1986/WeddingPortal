using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionLocation
{
  public  class LocationParameters
    {    
        public bool IsForSubscription { get; set; }
        public bool IsForSingleSubscriptionLocation { get; set; }
        public bool IsForLocation { get; set; }
        public decimal Value { get; set; }
    }
}
