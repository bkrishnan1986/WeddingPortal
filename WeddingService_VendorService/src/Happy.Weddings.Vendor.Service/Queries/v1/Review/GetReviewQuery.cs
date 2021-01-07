#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  11-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetReviewQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.Review
{
    /// <summary>
    /// Query for getting a Review
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetReviewQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Review identifier.
        /// </summary>
        public int ReviewId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSubscriptionPlanQuery"/> class.
        /// </summary>
        /// <param name="reviewId">The review identifier.</param>
        public GetReviewQuery(int reviewId)
        {
            ReviewId = reviewId;
        }
    }
}
