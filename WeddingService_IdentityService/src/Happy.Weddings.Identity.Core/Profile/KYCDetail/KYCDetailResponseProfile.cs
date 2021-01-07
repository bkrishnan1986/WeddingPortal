#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | KYCDetailResponseProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using Happy.Weddings.Identity.Core.DTO.Responses.KYCDetail;

#endregion

namespace Happy.Weddings.Identity.Core.Profile.KYCDetail
{
    /// <summary>
    /// Automapper profile for kyc detail response.
    /// </summary>
    public class KYCDetailResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KYCDetailResponseProfile"/> class.
        /// </summary>
        public KYCDetailResponseProfile()
        {
            CreateMap<KYCDataResponse, KYCDetailResponse>();
        }
    }
}
