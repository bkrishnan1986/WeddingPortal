#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetTopUpQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.TopUp
{
    /// <summary>
    /// Query for getting a TopUp
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetTopUpQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the TopUp identifier.
        /// </summary>
        public int VendorSubscriptionId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTopUpQuery"/> class.
        /// </summary>
        /// <param name="vendorSubscriptionId">The TopUp identifier.</param>
        public GetTopUpQuery(int vendorSubscriptionId)
        {
            VendorSubscriptionId = vendorSubscriptionId;
        }
    }
}
