#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 05-Aug-2020 | REJI SALOOJA B S | Created and implemented.
//                                | CreateMultiDetailProfile    - class
//----------------------------------------------------------------------------------------------

#endregion

using Happy.Weddings.Identity.Core.DTO.Requests.MultiDetail;
using Happy.Weddings.Identity.Core.Entity;
using System;

namespace Happy.Weddings.Identity.Core.Profile.MultiDetail
{
    /// <summary>
    /// This class is used to map CreateMultiDetailProfile
    /// </summary>
    public class CreateMultiDetailProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMultiDetailProfile"/> class.
        /// </summary>
        public CreateMultiDetailProfile()
        {
            CreateMap<CreateMultiDetailsRequest, Multidetail>()
                 .ForMember(x => x.CreatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
