using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Vendor.Core.DTO.Responses.SubscriptionBenefits
{
    public class SubBenefitDataResponse : SubscriptionBenefitsResponse
    {
        public string Subscription { get; set; }

        public string BenefitValue { get; set; } 
    }
    public class SubsBenefitDataResponse : SubBenefitDataResponse
    {
        public int id { get; set; }
    }
}
