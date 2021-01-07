#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 02-Sep-2020 | Reji Salooja B S  | Created and implemented.
//                                 | ServiceQuestionResponseProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses.ServiceQuestion;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Profile.ServiceQuestion
{
    public class ServiceQuestionResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceQuestionResponseProfile"/> class.
        /// </summary>
        public ServiceQuestionResponseProfile()
        {
            CreateMap<Servicequestion, ServiceQuestionDetailsResponse>()
                .ForMember(x => x.ServiceName, opt => opt.MapFrom(o => o.ServiceTypeNavigation != null ? o.ServiceTypeNavigation.Value : ""));
        }
    }
}
