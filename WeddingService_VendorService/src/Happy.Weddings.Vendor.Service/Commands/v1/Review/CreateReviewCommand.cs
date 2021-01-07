#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  11-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | CreateBenefitCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.Review;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.Review
{
    /// <summary>
    /// Command for creating a Review
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class CreateReviewCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the reqest.
        /// </summary>
        public CreateReviewRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateStoryCommand"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public CreateReviewCommand(CreateReviewRequest request)
        {
            Request = request;
        }
    }
}
