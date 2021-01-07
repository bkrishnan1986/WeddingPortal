#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetSubscriptionBenefitQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.SubscriptionBenefits
{
    /// <summary>
    /// Query for getting a SubscriptionBenefit
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetSubscriptionBenefitQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the SubscriptionPlans identifier.
        /// </summary>
        public int SubscriptionBenefitId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSubscriptionBenefitQuery"/> class.
        /// </summary>
        /// <param name="SubscriptionBenefitId">The SubscriptionPlans identifier.</param>
        public GetSubscriptionBenefitQuery(int subscriptionBenefitId)
        {
            SubscriptionBenefitId = subscriptionBenefitId;
        }
    }
}
