#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | CreateOfferCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.Offers;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.Offers
{
    /// <summary>
    /// Command for creating a Offer
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Blog.Core.DTO.Responses.APIResponse}" />
    public class CreateOfferCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the request.
        /// </summary>
        public CreateOfferRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateOfferCommand"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public CreateOfferCommand(CreateOfferRequest request)
        {
            Request = request;
        }
    }
}
