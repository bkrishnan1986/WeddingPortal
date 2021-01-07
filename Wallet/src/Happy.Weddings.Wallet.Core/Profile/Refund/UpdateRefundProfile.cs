#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 18-SEP-2020 | NIKHIL K DAS | Created and implemented.
//                                | UpdateRefundProfile - class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Requests.Refund;
using Happy.Weddings.Wallet.Core.Entity;

namespace Happy.Weddings.Wallet.Core.Profile.Refund
{
    /// <summary>
    /// This class is used to map UpdateRefundProfile
    /// </summary>
    public class UpdateRefundProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateRefundProfile"/> class.
        /// </summary>
        public UpdateRefundProfile()
        {
            CreateMap<UpdateRefundRequest, Entity.Refund>()
                .ForMember(x => x.UpdatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
