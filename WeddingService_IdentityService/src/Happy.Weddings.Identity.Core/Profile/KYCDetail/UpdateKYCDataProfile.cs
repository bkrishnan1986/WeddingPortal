#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  25-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | UpdateKYCDataProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using Happy.Weddings.Identity.Core.DTO.Requests.KYCDetail;
using Happy.Weddings.Identity.Core.DTO.Requests.Profile;
using Happy.Weddings.Identity.Core.Entity;

#endregion

namespace Happy.Weddings.Identity.Core.Profile.KYCDetail
{
    /// <summary>
    /// Automapper profile for update KYC.
    /// </summary>
    public class UpdateKYCDataProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateKYCDataProfile"/> class.
        /// </summary>
        public UpdateKYCDataProfile()
        {
            CreateMap<KYCUpdateData, Kycdetails>()
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
