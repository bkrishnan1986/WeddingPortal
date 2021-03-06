﻿#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 03-Aug-2020 | REJI SALOOJA B S | Created and implemented.
//                                | CreateMultiCodeProfile  - class
//----------------------------------------------------------------------------------------------

#endregion

using Happy.Weddings.Wallet.Core.DTO.Requests.MultiCode;
using Happy.Weddings.Wallet.Core.Entity;
using System;

namespace Happy.Weddings.Wallet.Core.Profile.MultiCode
{
    /// <summary>
    /// This class is used to map CreateMultiCodeProfile
    /// </summary>
    public class CreateMultiCodeProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMultiCodeProfile"/> class.
        /// </summary>
        public CreateMultiCodeProfile()
        {
            CreateMap<CreateMultiCodeRequest, Multicode>()
                 .ForMember(x => x.CreatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
