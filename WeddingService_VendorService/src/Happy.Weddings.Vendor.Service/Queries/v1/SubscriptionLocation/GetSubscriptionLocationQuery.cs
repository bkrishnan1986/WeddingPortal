#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
// 28-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetSubscriptionLocationQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionLocation;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.SubscriptionLocation
{
    /// <summary>
    /// Query for getting a SubscriptionLocation
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetSubscriptionLocationQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the SubscriptionLocation identifier.
        /// </summary>
        public LocationParameters LocationParameters{ get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSubscriptionLocationQuery"/> class.
        /// </summary>
        /// <param name="LocationParameters">The SubscriptionLocation identifier.</param>
        public GetSubscriptionLocationQuery(LocationParameters locationParameters)
        {
            LocationParameters = locationParameters;
        }
    }
}
