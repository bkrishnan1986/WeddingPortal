#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetServiceSubscriptionofVendorQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceSubscription;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.ServiceSubscriptions
{
    /// <summary>
    /// Query for getting a GetServiceSubscriptionofVendorQuery
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetServiceSubscriptionofVendorQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the ServiceSubscriptions identifier.
        /// </summary>
        public ServiceSubscriptionsParameter ServiceSubscriptionsParameter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetVendorSubscriptionQuery"/> class.
        /// </summary>
        /// <param name="VendorSubscriptionId">The ServiceSubscriptions identifier.</param>
        public GetServiceSubscriptionofVendorQuery(ServiceSubscriptionsParameter serviceSubscriptionsParameter)
        {
            ServiceSubscriptionsParameter = serviceSubscriptionsParameter;
        }
    }
}
