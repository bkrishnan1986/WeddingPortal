#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | DeleteOfferCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.Offers
{
    /// <summary>
    /// Command for deleting a Offer
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class DeleteOfferCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Offer identifier.
        /// </summary>
        public int OfferId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteOfferCommand"/> class.
        /// </summary>
        /// <param name="storyId">The Offer identifier.</param>
        public DeleteOfferCommand(int offerId)
        {
            OfferId = offerId;
        }
    }
}
