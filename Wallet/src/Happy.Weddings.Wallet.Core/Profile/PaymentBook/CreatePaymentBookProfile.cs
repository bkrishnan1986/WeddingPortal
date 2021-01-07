#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | CreatePaymentBookProfile --class
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
    /// Initializes a new instance of the <see cref="CreatePaymentBookProfile"/> class.
    /// </summary>
    public class CreatePaymentBookProfile : AutoMapper.Profile
    {
        public CreatePaymentBookProfile()
        {
            CreateMap<CreatePaymentBook, Paymentbook>()
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
