using Happy.Weddings.Gateway.Core.DTO.Vendor.ServiceSubscriptions;
using Happy.Weddings.Gateway.Core.DTO.Vendor.ServiceTopup;
using Happy.Weddings.Gateway.Core.DTO.Vendor.SubscriptionBenefits;
using Happy.Weddings.Gateway.Core.DTO.Vendor.SubscriptionLocation;
using Happy.Weddings.Gateway.Core.DTO.Vendor.SubscriptionPlans;
using Happy.Weddings.Gateway.Core.DTO.Vendor.TopUps;
using System.Collections.Generic;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.Service
{
    public class ServiceDetailsResponse  : ServiceResponse
    {
        public List<ServiceSubscriptionsResponse> Servicesubscription { get; set; }
        public List<SubscriptionLocationResponse> SubscriptionLocation { get; set; }
        public List<SubscriptionPlansResponse> SubscriptionPlan { get; set; }
        public List<SubscriptionBenefitsResponse> Subscriptionbenefit { get; set; }
        public List<ServiceTopupResponse> Servicetopup { get; set; }
        public List<TopUpsResponse> TopUp { get; set; }
        public List<TopUpBenefitResponse> Topupbenefit { get; set; }

    }   
}
