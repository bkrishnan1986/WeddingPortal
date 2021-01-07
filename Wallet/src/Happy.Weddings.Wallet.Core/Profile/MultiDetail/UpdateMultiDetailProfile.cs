#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 05-Aug-2020 | REJI SALOOJA B S | Created and implemented.
//                                | UpdateMultiDetailProfile   - class
//----------------------------------------------------------------------------------------------

#endregion

using Happy.Weddings.Wallet.Core.DTO.Requests.MultiDetail;
using Happy.Weddings.Wallet.Core.Entity;
using System;

namespace Happy.Weddings.Wallet.Core.Profile.MultiDetail
{
    /// <summary>
    /// This class is used to map UpdateMultiDetailProfile
    /// </summary>
    public class UpdateMultiDetailProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMultiDetailProfile"/> class.
        /// </summary>
        public UpdateMultiDetailProfile()
        {
            CreateMap<UpdateMultiDetailsRequest, Multidetail>()
                 .ForMember(x => x.UpdatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
