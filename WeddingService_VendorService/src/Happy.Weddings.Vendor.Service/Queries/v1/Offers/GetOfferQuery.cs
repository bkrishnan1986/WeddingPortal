#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetOfferQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.Offers
{
    /// <summary>
    /// Query for getting a Offer
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetOfferQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the offer identifier.
        /// </summary>
        public int OfferId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSubscriptionPlanQuery"/> class.
        /// </summary>
        /// <param name="SubscriptionPlanId">The offer identifier.</param>
        public GetOfferQuery(int offerId)
        {
            OfferId = offerId;
        }
    }
}
