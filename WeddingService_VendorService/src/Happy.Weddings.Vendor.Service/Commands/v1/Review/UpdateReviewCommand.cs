#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  1-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | UpdateBenefitsCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.Review;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.Review
{
    /// <summary>
    /// Command for updating a Review
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class UpdateReviewCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Review identifier.
        /// </summary>
        /// <value>
        /// The Benefit identifier.
        /// </value>
        public int ReviewId { get; set; }

        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public UpdateReviewRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateBenefitsRequest" /> class.
        /// </summary>
        /// <param name="ReviewId">The story identifier.</param>
        /// <param name="Request">The request.</param>
        public UpdateReviewCommand(int reviewId, UpdateReviewRequest request)
        {
            ReviewId = reviewId;
            Request = request;
        }
    }
}
