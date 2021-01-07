using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Blog.Review;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Blog
{
    /// <summary>
    /// Service interface for post related operations
    /// </summary>
    public interface IReviewService
    {
        /// <summary>
        /// Gets the Review.
        /// </summary>
        /// <param name="reviewParametersRequest">The Review parameters request.</param>
        /// <returns></returns>
        Task<APIResponse> GetReviews(ReviewParametersRequest reviewParametersRequest);

        /// <summary>
        /// Gets the Review.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> GetReview(ReviewIdDetails details);

        /// <summary>
        /// Creates the Review.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> CreateReview(CreateReviewBlogRequest request);

        /// <summary>
        /// Updates the Review.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> UpdateReview(ReviewIdDetails details, UpdateReviewBlogRequest request);

        /// <summary>
        /// Deletes the Review.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> DeleteReview(ReviewIdDetails details);
    }
}
