﻿#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | AddBenefitsProfile --class
//----------------------------------------------------------------------------------------------

#endregion File Header
using Happy.Weddings.Vendor.Core.DTO.Requests.Benefits;
using Happy.Weddings.Vendor.Core.Entity;
using System;

namespace Happy.Weddings.Vendor.Core.Profile.BenefitsProfile
{
    public class AddBenefitProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateOffersProfile"/> class.
        /// </summary>
        public AddBenefitProfile()
        {
            CreateMap<CreateBenefitRequest, Benefits>()
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }

}
