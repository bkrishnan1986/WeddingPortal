#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  10-Aug-2020 |    REJI SALOOJA B S    | Created and implemented. 
//              |                         | MultiCodeResponseProfile --class
//----------------------------------------------------------------------------------------------

#endregion

using Happy.Weddings.Wallet.Core.DTO.Responses.MultiCode;
using Happy.Weddings.Wallet.Core.Entity;

namespace Happy.Weddings.Wallet.Core.Profile.MuliCode
{
    public class MultiCodeResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiCodeResponseProfile"/> class.
        /// </summary>
        public MultiCodeResponseProfile()
        {
            CreateMap<Multicode, MultiCodeResponse>();
        }
    }
}
