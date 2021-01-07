#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | ARAVIND PERUMAL S  | Created and implemented.
//             |                    | SubscriptionResponsProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header


using Happy.Weddings.Vendor.Core.DTO.Responses.SubscriptionPlans;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Profile.OffersProfile
{
    public class SubscriptionResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionResponseProfile"/> class.
        /// </summary>
        public SubscriptionResponseProfile()
        {
            CreateMap<Subscription, SubscriptionPlansResponse>()
                 .ForMember(x => x.ModeName, opt => opt.MapFrom(o => o.ModeNavigation != null ? o.ModeNavigation.Value : ""))
                 .ForMember(x => x.ValidityUnitName, opt => opt.MapFrom(o => o.ValidityUnitNavigation != null ? o.ValidityUnitNavigation.Value : ""))
                .ForMember(x => x.ApprovalStatusName, opt => opt.MapFrom(o => o.ApprovalStatusNavigation != null ? o.ApprovalStatusNavigation.Value : ""));
        }
    }
}
