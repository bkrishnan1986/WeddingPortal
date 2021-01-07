#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetAllReviewsQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.Review;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.Review
{
    /// <summary>
    /// Query for getting Reviews
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetAllReviewsQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Reviews parameters.
        /// </summary>
        public ReviewsParameter ReviewsParameter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllOffersQuery"/> class.
        /// </summary>
        /// <param name="reviewsParameter">The Offers parameters.</param>
        public GetAllReviewsQuery(ReviewsParameter reviewsParameter)
        {
            ReviewsParameter = reviewsParameter;
        }
    }
}
