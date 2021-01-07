#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetAllWalletsQuery --class
//----------------------------------------------------------------------------------------------

#endregion

using Happy.Weddings.Wallet.Core.DTO.Requests.Wallet;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Queries.v1.Wallet
{
    /// <summary>
    /// Query for getting Wallet
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}}" />
    public class GetAllWalletsQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Wallet parameters.
        /// </summary>
        public WalletsParameter WalletsParameter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllWalletsQuery"/> class.
        /// </summary>
        /// <param name="walletsParameter">The Wallet parameters.</param>
        public GetAllWalletsQuery(WalletsParameter walletsParameter)
        {
            WalletsParameter = walletsParameter;
        }
    }
}
