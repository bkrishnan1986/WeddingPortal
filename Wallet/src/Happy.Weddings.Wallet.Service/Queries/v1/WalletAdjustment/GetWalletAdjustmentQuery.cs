#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | GetWalletAdjustmentQuery --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Queries.v1.WalletAdjustment
{
    /// <summary>
    /// Query for getting a Wallet Adjustment
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}}" />
    public class GetWalletAdjustmentQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Wallet Adjustment identifier.
        /// </summary>
        public int WalletAdjustmentId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWalletAdjustmentQuery"/> class.
        /// </summary>
        /// <param name="walletAdjustmentId">The Wallet Adjustment identifier.</param>
        public GetWalletAdjustmentQuery(int walletAdjustmentId)
        {
            WalletAdjustmentId = walletAdjustmentId;
        }
    }
}
