#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | GetAllWalletAdjustmentQuery --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Requests.WalletAdjustment;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Queries.v1.WalletAdjustment
{
    /// <summary>
    /// Query for getting Wallet Adjustment
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}}" />
    public class GetAllWalletAdjustmentQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Wallet Adjustment parameters.
        /// </summary>
        public WalletAdjustmentParameter WalletAdjustmentParameter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllWalletAdjustmentQuery"/> class.
        /// </summary>
        /// <param name="walletAdjustmentParameter">The Wallet Adjustment parameters.</param>
        public GetAllWalletAdjustmentQuery(WalletAdjustmentParameter walletAdjustmentParameter)
        {
            WalletAdjustmentParameter = walletAdjustmentParameter;
        }
    }
}
