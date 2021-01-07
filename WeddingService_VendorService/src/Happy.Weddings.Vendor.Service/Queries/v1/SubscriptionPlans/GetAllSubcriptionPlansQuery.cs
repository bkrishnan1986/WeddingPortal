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
using Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionPlans;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.SubscriptionPlans
{
    /// <summary>
    /// Query for getting SubcriptionPlans
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetAllSubscriptionPlansQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the SubcriptionPlans parameters.
        /// </summary>
        public SubscriptionPlansParameter SubscriptionPlansParameter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllSubscriptionplansQuery"/> class.
        /// </summary>
        /// <param name="subscriptionPlansParameter">The SubcriptionPlans parameters.</param>
        public GetAllSubscriptionPlansQuery(SubscriptionPlansParameter subscriptionPlansParameter)
        {
            SubscriptionPlansParameter = subscriptionPlansParameter;
        }
    }
}
