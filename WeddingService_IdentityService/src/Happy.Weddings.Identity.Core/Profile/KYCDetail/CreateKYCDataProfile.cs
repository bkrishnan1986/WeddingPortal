#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  24-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | CreateKYCDataProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using System.Collections.Generic;
using Happy.Weddings.Identity.Core.DTO.Requests.KYCDetail;
using Happy.Weddings.Identity.Core.Entity;

#endregion

namespace Happy.Weddings.Identity.Core.Profile.KYCDetail
{
    /// <summary>
    /// Automapper profile for create KYC.
    /// </summary>
    public class CreateKYCDataProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateKYCDataProfile"/> class.
        /// </summary>
        public CreateKYCDataProfile()
        {
            CreateMap<KYCCreateData, Kycdata>()
               .ForMember(x => x.CreatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
