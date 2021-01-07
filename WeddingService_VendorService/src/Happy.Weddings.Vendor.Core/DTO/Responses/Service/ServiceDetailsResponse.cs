using Happy.Weddings.Vendor.Core.DTO.Responses.MultiDetail;
using Happy.Weddings.Vendor.Core.DTO.Responses.ServiceSubscriptions;
using Happy.Weddings.Vendor.Core.DTO.Responses.ServiceTopup;
using Happy.Weddings.Vendor.Core.DTO.Responses.SubscriptionBenefits;
using Happy.Weddings.Vendor.Core.DTO.Responses.SubscriptionLocation;
using Happy.Weddings.Vendor.Core.DTO.Responses.SubscriptionPlans;
using Happy.Weddings.Vendor.Core.DTO.Responses.TopUps;
using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.DTO.Responses.Service
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
