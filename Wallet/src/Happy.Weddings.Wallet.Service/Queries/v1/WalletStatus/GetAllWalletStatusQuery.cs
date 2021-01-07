#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | GetAllWalletStatusQuery --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Requests.WalletStatus;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Queries.v1.WalletStatus
{
    /// <summary>
    /// Query for getting Wallet Status
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}}" />

    public class GetAllWalletStatusQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Wallet Status parameters.
        /// </summary>
        public WalletStatusParameter WalletStatusParameter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllWalletStatusQuery"/> class.
        /// </summary>
        /// <param name="walletStatusParameter">The Wallet Status parameters.</param>
        public GetAllWalletStatusQuery(WalletStatusParameter walletStatusParameter)
        {
            WalletStatusParameter = walletStatusParameter;
        }
    }
}
