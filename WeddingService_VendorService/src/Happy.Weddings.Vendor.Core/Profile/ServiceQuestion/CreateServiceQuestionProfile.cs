#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 03-Sep-2020 | REJI SALOOJA B S | Created and implemented.
//                                | CreateServiceQuestionProfile  - class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceQuestion;
using Happy.Weddings.Vendor.Core.Entity;
using System;

namespace Happy.Weddings.Vendor.Core.Profile.ServiceQuestion
{
    public class CreateServiceQuestionProfile : AutoMapper.Profile
    {
        public CreateServiceQuestionProfile()
        {
            CreateMap<CreateServiceQuestionRequest, Servicequestion>()
                 .ForMember(x => x.CreatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
