#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 03-Sep-2020 | REJI SALOOJA B S | Created and implemented.
//                                | CreateServiceAnswerProfile  - class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceAnswer;
using Happy.Weddings.Vendor.Core.Entity;
using System;

namespace Happy.Weddings.Vendor.Core.Profile.ServiceAnswer
{
    public  class CreateServiceAnswerProfile : AutoMapper.Profile
    {
        public CreateServiceAnswerProfile()
        {
            CreateMap<CreateServiceAnswerRequest, Serviceanswer>()
                 .ForMember(x => x.CreatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
