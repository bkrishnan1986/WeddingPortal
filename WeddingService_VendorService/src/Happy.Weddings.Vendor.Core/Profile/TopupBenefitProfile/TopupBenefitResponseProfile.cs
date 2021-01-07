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


using Happy.Weddings.Vendor.Core.DTO.Responses.TopUps;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Profile.TopupBenefitProfile
{
    public class TopupBenefitResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResponseProfile"/> class.
        /// </summary>
        public TopupBenefitResponseProfile()
        {
            CreateMap<Topupbenefit, TopUpBenefitResponse>()
                .ForMember(x => x.TopUpName, opt => opt.MapFrom(o => o.TopUp != null ? o.TopUp.Name : ""))
                .ForMember(x => x.BenefitName, opt => opt.MapFrom(o => o.BenefitNavigation != null ? o.BenefitNavigation.Value : ""))
                .ForMember(x => x.ApprovalStatusName, opt => opt.MapFrom(o => o.ApprovalStatusNavigation != null ? o.ApprovalStatusNavigation.Value : ""));
        }
    }
}