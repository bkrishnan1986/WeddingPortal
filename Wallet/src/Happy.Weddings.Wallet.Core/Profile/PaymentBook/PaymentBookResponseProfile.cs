#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date         | Author          | Description
//----------------------------------------------------------------------------------------------
// 18-SEP-2020 | NIKHIL K DAS  | Created and implemented.
//             |                    | PaymentBookResponseProfile class.
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Responses.PaymentBook;
using Happy.Weddings.Wallet.Core.Entity;

namespace Happy.Weddings.Wallet.Core.Profile.PaymentBook
{
    public class PaymentBookResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentBookResponseProfile"/> class.
        /// </summary>
        public PaymentBookResponseProfile()
        {
            CreateMap<Paymentbook, PaymentBookResponse>()
                .ForMember(x => x.PackageTypeName, opt => opt.MapFrom(o => o.PackageTypeNavigation != null ? o.PackageTypeNavigation.Value : ""))
                .ForMember(x => x.PaymentTypeName, opt => opt.MapFrom(o => o.PaymentTypeNavigation != null ? o.PaymentTypeNavigation.Value : ""))
                .ForMember(x => x.PaymentStatusName, opt => opt.MapFrom(o => o.PaymentStatusNavigation != null ? o.PaymentStatusNavigation.Value : ""))
                .ForMember(x => x.PaymentModeName, opt => opt.MapFrom(o => o.PaymentModeNavigation != null ? o.PaymentModeNavigation.Value : ""))
                .ForMember(x => x.FinanceApprovalStatusName, opt => opt.MapFrom(o => o.FinanceApprovalStatusNavigation != null ? o.FinanceApprovalStatusNavigation.Value : ""))
                .ForMember(x => x.BhstatusName, opt => opt.MapFrom(o => o.BhstatusNavigation != null ? o.BhstatusNavigation.Value : ""));
        }
    }
}
