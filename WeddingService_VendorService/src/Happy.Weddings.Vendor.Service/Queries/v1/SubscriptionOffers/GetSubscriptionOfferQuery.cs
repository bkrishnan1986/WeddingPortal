#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetSubscriptionOfferQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.SubscriptionOffers
{
    /// <summary>
    /// Query for getting a SubscriptionOffers
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetSubscriptionOfferQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the SubscriptionOffers identifier.
        /// </summary>
        public int SubscriptionOfferId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSubscriptionBenefitQuery"/> class.
        /// </summary>
        /// <param name="SubscriptionOfferId">The SubscriptionOffers identifier.</param>
        public GetSubscriptionOfferQuery(int subscriptionOfferId)
        {
            SubscriptionOfferId = subscriptionOfferId;
        }
    }
}
