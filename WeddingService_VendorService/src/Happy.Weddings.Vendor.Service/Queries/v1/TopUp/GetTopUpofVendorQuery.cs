#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetTopUpofVendorQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.TopUp;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.TopUp
{
    /// <summary>
    /// Query for getting a GetVendorSubscriptionofVendorQuery
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetTopUpofVendorQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the TopUp identifier.
        /// </summary>
        public TopUpParameter VendorSubscriptionsParameter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTopUpQuery"/> class.
        /// </summary>
        /// <param name="VendorSubscriptionId">The TopUp identifier.</param>
        public GetTopUpofVendorQuery(TopUpParameter vendorSubscriptionsParameter)
        {
            VendorSubscriptionsParameter = vendorSubscriptionsParameter;
        }
    }
}
