#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  25-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetWalletQuery --class
//----------------------------------------------------------------------------------------------

#endregion

using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Queries.v1.Wallet
{
    /// <summary>
    /// Query for getting a Wallet
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}}" />
    public class GetWalletQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Wallet identifier.
        /// </summary>
        public int WalletId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWalletQuery"/> class.
        /// </summary>
        /// <param name="walletId">The Wallet identifier.</param>
        public GetWalletQuery(int walletId)
        {
            WalletId = walletId;
        }
    }
}
