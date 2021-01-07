#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  26-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | UpdateKYCPortionProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using Happy.Weddings.Identity.Core.DTO.Requests.KYCDetail;
using Happy.Weddings.Identity.Core.Entity;

#endregion

namespace Happy.Weddings.Identity.Core.Profile.KYCDetail
{
    /// <summary>
    /// Automapper profile for update KYC portion.
    /// </summary>
    public class UpdateKYCPortionProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateKYCPortionProfile"/> class.
        /// </summary>
        public UpdateKYCPortionProfile()
        {
            CreateMap<KYCPortionData, Kycdata>()
                .ForMember(x => x.UpdatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}