#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  10-Aug-2020 |    REJI SALOOJA B S    | Created and implemented. 
//              |                        | MultiDetailResponseProfile --class
//----------------------------------------------------------------------------------------------

#endregion

using Happy.Weddings.Identity.Core.DTO.Responses.MultiDetail;
using Happy.Weddings.Identity.Core.Entity;

namespace Happy.Weddings.Identity.Core.Profile.MultiDetail
{
    public class MultiDetailResponseProfile : AutoMapper.Profile
    {
        public MultiDetailResponseProfile()
        {
            CreateMap<Multidetail, MultiDetailResponse>();
        }
    }
}
