#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
// 20-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                        | GetServiceSubscriptionQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.ServiceSubscriptions
{
    /// <summary>
    /// Query for getting a VendorSubscriptions
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetServiceSubscriptionQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the VendorSubscription identifier.
        /// </summary>
        public int ServiceSubscriptionId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetServiceSubscriptionQuery"/> class.
        /// </summary>
        /// <param name="SubscriptionPlanId">The VendorSubscriptions identifier.</param>
        public GetServiceSubscriptionQuery(int vendorSubscriptionId)
        {
            ServiceSubscriptionId = vendorSubscriptionId;
        }
    }
}
