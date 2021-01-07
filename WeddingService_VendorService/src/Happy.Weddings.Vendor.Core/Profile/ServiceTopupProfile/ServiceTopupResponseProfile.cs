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


using Happy.Weddings.Vendor.Core.DTO.Responses.ServiceTopup;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Profile.ServiceTopupProfile
{
    public class ServiceTopupResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionResponseProfile"/> class.
        /// </summary>
        public ServiceTopupResponseProfile()
        {
            CreateMap<Servicetopup, ServiceTopupResponse>()
                 .ForMember(x => x.ServiceName, opt => opt.MapFrom(o => o.Service != null ? o.Service.ServiceTypeNavigation.Value : ""))
                 .ForMember(x => x.TopUpName, opt => opt.MapFrom(o => o.TopUp != null ? o.TopUp.Name : ""))
                 .ForMember(x => x.PaymentStatusValue, opt => opt.MapFrom(o => o.PaymentStatusNavigation != null ? o.PaymentStatusNavigation.Value : ""))
                .ForMember(x => x.ApprovalStatusValue, opt => opt.MapFrom(o => o.ApprovalStatusNavigation != null ? o.ApprovalStatusNavigation.Value : ""));
        }
    }
}
