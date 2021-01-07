#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 03-Sep-2020 | REJI SALOOJA B S | Created and implemented.
//                                | UpdateServiceAnswerProfile  - class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceAnswer;
using Happy.Weddings.Vendor.Core.Entity;
using System;

namespace Happy.Weddings.Vendor.Core.Profile.ServiceAnswer
{
    public class UpdateServiceAnswerProfile : AutoMapper.Profile
    {
        public UpdateServiceAnswerProfile()
        {
            CreateMap<UpdateServiceAnswerRequest, Serviceanswer>()
                 .ForMember(x => x.UpdatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
