using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Happy.Weddings.Gateway.API.Filters;
using Happy.Weddings.Gateway.Core.DTO.Blog.Review;
using Happy.Weddings.Gateway.Core.Services.v1.Blog;
using Microsoft.AspNetCore.Authorization;

namespace Happy.Weddings.Gateway.API.Controllers.v1.Blog
{
    /// <summary>
    /// Review operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("review")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        /// <summary>
        /// The Review service
        /// </summary>
        private readonly IReviewService reviewService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReviewController"/> class.
        /// </summary>
        /// <param name="reviewService">The Review service.</param>
        public ReviewController(
            IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        /// <summary>
        /// Gets the Review.
        /// </summary>
        /// <param name="reviewParametersRequest">The Review parameters request.</param>
        /// <returns></returns>
        [HttpGet]
        [RequestRateLimit(Name = "Limit Request Number", Seconds = 1)]
        public async Task<IActionResult> GetReviews([FromQuery] ReviewParametersRequest reviewParametersRequest)
        {
            var result = await reviewService.GetReviews(reviewParametersRequest);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the Review.
        /// </summary>
        /// <param name="reviewId">The Review identifier.</param>
        /// <returns></returns>
        [Route("{reviewId}")]
        [HttpGet]
        public async Task<IActionResult> GetReview(int reviewId)
        {
            var result = await reviewService.GetReview(new ReviewIdDetails(reviewId));
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the Review.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        //[Authorize(Roles = "Admin, Vendor")]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewBlogRequest request)
        {
            var result = await reviewService.CreateReview(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the Review.
        /// </summary>
        /// <param name="reviewId">The Review identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{reviewId}")]
        [HttpPut]
        //[Authorize(Roles = "Admin, Vendor")]
        public async Task<IActionResult> UpdateReview(int reviewId, [FromBody] UpdateReviewBlogRequest request)
        {
            var result = await reviewService.UpdateReview(new ReviewIdDetails(reviewId), request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the Review.
        /// </summary>
        /// <param name="reviewId">The Review identifier.</param>
        /// <returns></returns>
        [Route("{reviewId}")]
        [HttpDelete]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            var result = await reviewService.DeleteReview(new ReviewIdDetails(reviewId));
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
