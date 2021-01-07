#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | UpdateOfferCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.Offers;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.Offers
{
    /// <summary>
    /// Command for updating a Offer
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class UpdateOfferCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Offer identifier.
        /// </summary>
        /// <value>
        /// The Offer identifier.
        /// </value>
        public int OfferId { get; set; }

        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public UpdateOfferRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateOfferCommand" /> class.
        /// </summary>
        /// <param name="offerId">The story identifier.</param>
        /// <param name="Request">The request.</param>
        public UpdateOfferCommand(int offerId, UpdateOfferRequest request)
        {
            OfferId = offerId;
            Request = request;
        }
    }
}
