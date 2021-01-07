
#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetAllSubscriptionBenefitsQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header
using Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionBenefits;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.SubscriptionBenefits
{
    /// <summary>
    /// Query for getting SubcriptionBenefits
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetAllSubscriptionBenefitsQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the SubcriptionBenefits parameters.
        /// </summary>
        public SubscriptionBenefitsParameter SubscriptionBenefitsParameter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllSubscriptionBenefitsQuery"/> class.
        /// </summary>
        /// <param name="subscriptionPlansParameter">The SubcriptionPlans parameters.</param>
        public GetAllSubscriptionBenefitsQuery(SubscriptionBenefitsParameter subscriptionBenefitsParameter)
        {
            SubscriptionBenefitsParameter = subscriptionBenefitsParameter;
        }
    }
}
