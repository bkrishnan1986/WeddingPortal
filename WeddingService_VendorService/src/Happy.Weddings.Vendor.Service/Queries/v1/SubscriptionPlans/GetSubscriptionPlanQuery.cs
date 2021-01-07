#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetSubscriptionPlanQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.SubscriptionPlans
{
    /// <summary>
    /// Query for getting a SubscriptionPlans
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetSubscriptionPlanQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the SubscriptionPlans identifier.
        /// </summary>
        public int SubscriptionPlanId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSubscriptionPlanQuery"/> class.
        /// </summary>
        /// <param name="SubscriptionPlanId">The SubscriptionPlans identifier.</param>
        public GetSubscriptionPlanQuery(int subscriptionPlanId)
        {
            SubscriptionPlanId = subscriptionPlanId;
        }
    }
}
