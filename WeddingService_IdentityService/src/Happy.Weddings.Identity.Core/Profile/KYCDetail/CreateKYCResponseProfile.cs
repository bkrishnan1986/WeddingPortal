#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  25-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | CreateKYCResponseProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using Happy.Weddings.Identity.Core.DTO.Requests.KYCDetail;
using Happy.Weddings.Identity.Core.DTO.Responses.KYCDetail;
using Happy.Weddings.Identity.Core.Entity;

#endregion

namespace Happy.Weddings.Identity.Core.Profile.KYCDetail
{
    /// <summary>
    /// Automapper profile for create KYC doc path.
    /// </summary>
    public class CreateKYCResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateKYCResponseProfile"/> class.
        /// </summary>
        public CreateKYCResponseProfile()
        {

            CreateMap<Kycdata, KYCDetailResponse>()
                .ForMember(x => x.KycName, opt => opt.MapFrom(o => o.Kyc != null ? o.Kyc.Value : ""))
                .ForMember(x => x.KycStatusName, opt => opt.MapFrom(o => o.KycstatusNavigation != null ? o.KycstatusNavigation.Value : ""));

            CreateMap<Kycdetails, KycDetailsDTO>();

            CreateMap<Gstdetails, GstDetailsDTO>()
               .ForMember(x => x.GststateName, opt => opt.MapFrom(o => o.GststateNavigation != null ? o.GststateNavigation.Value : ""))
               .ForMember(x => x.GstcityName, opt => opt.MapFrom(o => o.GstcityNavigation != null ? o.GstcityNavigation.Value : ""));
        }
    }
}