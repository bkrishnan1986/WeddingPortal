#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 18-SEP-2020 | NIKHIL K DAS | Created and implemented.
//                                | UpdatePaymentBookProfile - class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Requests.PaymentBook;
using Happy.Weddings.Wallet.Core.Entity;

namespace Happy.Weddings.Wallet.Core.Profile.PaymentBook
{
    /// <summary>
    /// This class is used to map UpdatePaymentBookProfile
    /// </summary>
    public class UpdatePaymentBookProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdatePaymentBookProfile"/> class.
        /// </summary>
        public UpdatePaymentBookProfile()
        {
            CreateMap<UpdatePaymentBookRequest, Paymentbook>()
                .ForMember(x => x.UpdatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
