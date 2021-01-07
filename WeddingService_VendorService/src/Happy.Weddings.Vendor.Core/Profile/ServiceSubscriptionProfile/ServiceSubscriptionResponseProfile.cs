#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date         | Author          | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | ARAVIND PERUMAL S  | Created and implemented.
//             |                    | VendorSubscriptionResponseProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses.ServiceSubscriptions;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Profile.VendorSubscriptionProfile
{
    public class ServiceSubscriptionResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResponseProfile"/> class.
        /// </summary>
        public ServiceSubscriptionResponseProfile()
        {
            CreateMap<Servicesubscription, ServiceSubscriptionsResponse>()
                .ForMember(x => x.ServiceName, opt => opt.MapFrom(o => o.Service != null ? o.Service.ServiceTypeNavigation.Value : ""))
                .ForMember(x => x.SubscriptionName, opt => opt.MapFrom(o => o.SubscriptionNavigation != null ? o.SubscriptionNavigation.Name : ""))
                .ForMember(x => x.PaymentStatusValue, opt => opt.MapFrom(o => o.PaymentStatusNavigation != null ? o.PaymentStatusNavigation.Value : ""))
                .ForMember(x => x.ApprovalStatusValue, opt => opt.MapFrom(o => o.ApprovalStatusNavigation != null ? o.ApprovalStatusNavigation.Value : ""));
        }
    }
}