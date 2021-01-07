#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | GetAllWalletDeductionQuery --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Requests.WalletDeduction;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Queries.v1.WalletDeduction
{
    /// <summary>
    /// Query for getting Wallet Deduction
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}}" />

    public class GetAllWalletDeductionQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the WalletDeduction parameters.
        /// </summary>
        public WalletDeductionParameter WalletDeductionParameter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllWalletDeductionQuery"/> class.
        /// </summary>
        /// <param name="walletDeductionParameter">The WalletDeduction parameters.</param>
        public GetAllWalletDeductionQuery(WalletDeductionParameter walletDeductionParameter)
        {
            WalletDeductionParameter = walletDeductionParameter;
        }

    }
}
