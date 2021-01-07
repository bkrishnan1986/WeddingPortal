#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 02-Sep-2020 | Reji Salooja B S  | Created and implemented.
//                                 | ServiceAnswerResponseProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses.ServiceAnswer;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Profile.ServiceAnswer
{
    public class ServiceAnswerResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceAnswerResponseProfile"/> class.
        /// </summary>
        public ServiceAnswerResponseProfile()
        {
            CreateMap<Serviceanswer, ServiceAnswerResponse>()
                 .ForMember(x => x.ControlTypeValue, opt => opt.MapFrom(o => o.ControlTypeNavigation != null ? o.ControlTypeNavigation.Value : ""));
        }
    }
}
