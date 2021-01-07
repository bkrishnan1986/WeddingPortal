#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetAllSubscriptionOffersQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header
using Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionOffers;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.SubscriptionOffers
{
    /// <summary>
    /// Query for getting SubcriptionOffers
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetAllSubscriptionOffersQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the SubcriptionOffers parameters.
        /// </summary>
        public SubscriptionOffersParameter SubscriptionOfferParameter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllSubscriptionBenefitsQuery"/> class.
        /// </summary>
        /// <param name="subscriptionOffersParameter">The SubcriptionPlans parameters.</param>
        public GetAllSubscriptionOffersQuery(SubscriptionOffersParameter subscriptionOffersParameter)
        {
            SubscriptionOfferParameter = subscriptionOffersParameter;
        }
    }
}
