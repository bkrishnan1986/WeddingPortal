#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS   | Created and implemented. 
//              |                         | GetWalletStatusQuery --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Queries.v1.WalletStatus
{
    /// <summary>
    /// Query for getting a Wallet Status
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}}" />
    public class GetWalletStatusQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Wallet identifier.
        /// </summary>
        public int WalletStatusId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWalletStatusQuery"/> class.
        /// </summary>
        /// <param name="walletStatusId">The Wallet identifier.</param>
        public GetWalletStatusQuery(int walletStatusId)
        {
            WalletStatusId = walletStatusId;
        }
    }
}
