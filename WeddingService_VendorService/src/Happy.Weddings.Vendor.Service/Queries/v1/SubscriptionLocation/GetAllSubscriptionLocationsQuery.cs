#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  28-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetAllSubscriptionLocationsQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header
using Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionLocation;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.SubscriptionLocation
{
    /// <summary>
    /// Query for getting SubscriptionLocation
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetAllSubscriptionLocationsQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the SubscriptionLocation parameters.
        /// </summary>
        public SubscriptionLocationsParameter SubscriptionLocationsParameter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllSubscriptionLocationsQuery"/> class.
        /// </summary>
        /// <param name="subscriptionLocationsParameter">The SubscriptionLocation parameters.</param>
        public GetAllSubscriptionLocationsQuery(SubscriptionLocationsParameter subscriptionLocationsParameter)
        {
            SubscriptionLocationsParameter = subscriptionLocationsParameter;
        }
    }
}
