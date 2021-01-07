#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetAllSubscriptionPlansQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header
using Happy.Weddings.Vendor.Core.DTO.Requests.Wallet;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.Wallet
{
    /// <summary>
    /// Query for getting Wallet
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetAllWalletsQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the SubcriptionPlans parameters.
        /// </summary>
        public WalletsParameter WalletsParameter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllSubscriptionplansQuery"/> class.
        /// </summary>
        /// <param name="subscriptionPlansParameter">The SubcriptionPlans parameters.</param>
        public GetAllWalletsQuery(WalletsParameter walletsParameter)
        {
            WalletsParameter = walletsParameter;
        }
    }
}
