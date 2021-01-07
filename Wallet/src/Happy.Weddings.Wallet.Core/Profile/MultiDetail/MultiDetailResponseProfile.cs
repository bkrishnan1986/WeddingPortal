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

using Happy.Weddings.Wallet.Core.DTO.Responses.MultiDetail;
using Happy.Weddings.Wallet.Core.Entity;

namespace Happy.Weddings.Wallet.Core.Profile.MultiDetail
{
    public class MultiDetailResponseProfile : AutoMapper.Profile
    {
        public MultiDetailResponseProfile()
        {
            CreateMap<Multidetail, MultiDetailResponse>();
        }
    }
}
