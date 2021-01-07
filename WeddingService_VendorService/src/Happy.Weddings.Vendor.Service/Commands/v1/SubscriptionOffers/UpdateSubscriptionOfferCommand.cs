#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | UpdateSubscriptionOfferCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionOffers;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.SubscriptionOffers
{
    /// <summary>
    /// Command for updating a story
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class UpdateSubscriptionOfferCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the story identifier.
        /// </summary>
        /// <value>
        /// The story identifier.
        /// </value>
        public int SubscriptionOfferId { get; set; }

        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public UpdateSubscriptionOfferRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSubscriptionPlanCommand" /> class.
        /// </summary>
        /// <param name="subscriptionPlanIdId">The story identifier.</param>
        /// <param name="Request">The request.</param>
        public UpdateSubscriptionOfferCommand(int subscriptionOfferId, UpdateSubscriptionOfferRequest request)
        {
            SubscriptionOfferId = subscriptionOfferId;
            Request = request;
        }
    }
}
