#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  19-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetAllServiceSubscriptionsQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceSubscription;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.ServiceSubscriptions
{
    /// <summary>
    /// Query for getting Service Subscriptions
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetAllServiceSubscriptionsQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Service Subscriptions parameters.
        /// </summary>
        public ServiceSubscriptionsParameter ServiceSubscriptionsParameter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllServiceSubscriptionsQuery"/> class.
        /// </summary>
        /// <param name="serviceSubscriptionsParameter">The Service Subscriptions  parameters.</param>
        public GetAllServiceSubscriptionsQuery(ServiceSubscriptionsParameter serviceSubscriptionsParameter)
        {
            ServiceSubscriptionsParameter = serviceSubscriptionsParameter;
        }
    }
}
