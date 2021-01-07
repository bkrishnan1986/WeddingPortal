#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date         | Author          | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | ARAVIND PERUMAL S  | Created and implemented.
//             |                    | SubscriptionBenefitsResponseProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses.SubscriptionBenefits;
using Happy.Weddings.Vendor.Core.Entity;
using static Happy.Weddings.Vendor.Core.Entity.Subscriptionbenefit;

namespace Happy.Weddings.Vendor.Core.Profile.ServicesProfile
{
    public class SubscriptionBenefitsResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResponseProfile"/> class.
        /// </summary>
        public SubscriptionBenefitsResponseProfile()
        {
            CreateMap<Subscriptionbenefit, SubscriptionBenefitsResponse>()
                .ForMember(x => x.SubscriptionValue, opt => opt.MapFrom(o => o.Subscriptions != null ? o.Subscriptions.Name : ""))
                .ForMember(x => x.BenefitValue, opt => opt.MapFrom(o => o.BenefitNavigation != null ? o.BenefitNavigation.Value : ""))
                .ForMember(x => x.ApprovalStatusValue, opt => opt.MapFrom(o => o.ApprovalStatusNavigation != null ? o.ApprovalStatusNavigation.Value : ""));
           // CreateMap<SubsBenefit, SubsBenefitDataResponse>();
        }
    }
}