﻿#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 03-Aug-2020 | REJI SALOOJA B S | Created and implemented.
//                                | UpdateMultiCodeProfile - class
//----------------------------------------------------------------------------------------------

#endregion

using Happy.Weddings.Identity.Core.DTO.Requests.MultiCode;
using Happy.Weddings.Identity.Core.Entity;
using System;

namespace Happy.Weddings.Identity.Core.Profile.MultiCode
{
    /// <summary>
    /// This class is used to map UpdateMultiCodeProfile
    /// </summary>
    public class UpdateMultiCodeProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMultiCodeProfile"/> class.
        /// </summary>
        public UpdateMultiCodeProfile()
        {
            CreateMap<UpdateMultiCodeRequest, Multicode>()
                .ForMember(x => x.UpdatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
