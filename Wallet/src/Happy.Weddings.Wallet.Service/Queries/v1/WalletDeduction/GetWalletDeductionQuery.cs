
#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | GetWalletDeductionQuery --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Queries.v1.WalletDeduction
{
    /// <summary>
    /// Query for getting a WalletDeduction
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}}" />
    public class GetWalletDeductionQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Wallet Deduction identifier.
        /// </summary>
        public int WalletDeductionId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWalletDeductionQuery"/> class.
        /// </summary>
        /// <param name="walleDeductiontId">The Wallet Deduction identifier.</param>
        public GetWalletDeductionQuery(int walleDeductiontId)
        {
            WalletDeductionId = walleDeductiontId;
        }
    }
}
