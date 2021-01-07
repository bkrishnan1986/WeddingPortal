#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date         | Author          | Description
//----------------------------------------------------------------------------------------------
// 18-SEP-2020 | NIKHIL K DAS  | Created and implemented.
//             |                    | RefundResponseProfile class.
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Responses.Refund;
using Happy.Weddings.Wallet.Core.Entity;

namespace Happy.Weddings.Wallet.Core.Profile.Refund
{
    public class RefundResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RefundResponseProfile"/> class.
        /// </summary>
        public RefundResponseProfile()
        {
            CreateMap<Entity.Refund, RefundResponse>()
                .ForMember(x => x.BhstatusName, opt => opt.MapFrom(o => o.BhstatusNavigation != null ? o.BhstatusNavigation.Value : ""));
        }
    }
}
