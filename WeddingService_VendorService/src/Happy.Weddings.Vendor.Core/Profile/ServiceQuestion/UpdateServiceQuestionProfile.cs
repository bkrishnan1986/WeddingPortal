#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 03-Sep-2020 | REJI SALOOJA B S | Created and implemented.
//                                | UpdateServiceQuestionProfile  - class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceQuestion;
using Happy.Weddings.Vendor.Core.Entity;
using System;

namespace Happy.Weddings.Vendor.Core.Profile.ServiceQuestion
{
    public class UpdateServiceQuestionProfile : AutoMapper.Profile
    {
        public UpdateServiceQuestionProfile()
        {
            CreateMap<UpdateServiceQuestionRequest, Servicequestion>()
                 .ForMember(x => x.UpdatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
