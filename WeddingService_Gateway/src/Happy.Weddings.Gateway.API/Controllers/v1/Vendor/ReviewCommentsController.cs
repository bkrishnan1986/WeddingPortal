using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.Vendor.ReviewComments;
using Happy.Weddings.Gateway.Core.Services.v1.Vendor;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Gateway.API.Controllers.v1.Vendor
{
    /// <summary>
    /// Reviews operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("reviews")]
    [ApiController]
    public class ReviewCommentsController : ControllerBase
    {
        /// <summary>
        /// The review comment service
        /// </summary>
        private readonly IReviewCommentService reviewCommentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReviewCommentsController"/> class.
        /// </summary>
        /// <param name="reviewCommentService">The review comment service.</param>
        public ReviewCommentsController(
            IReviewCommentService reviewCommentService)
        {
            this.reviewCommentService = reviewCommentService;
        }
        /// <summary>
        /// Gets the  Reviews
        /// </summary>
        /// <param name="reviewsParameter">The  Reviews Parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetReviews([FromQuery] ReviewsParameter reviewsParameter)
        {
            var result = await reviewCommentService.GetReviews(reviewsParameter);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Get the  Reviews.
        /// </summary>
        /// <param name="reviewId">The Review identifier.</param>
        /// <returns></returns>
        [Route("{reviewId}")]
        [HttpGet]
        public async Task<IActionResult> GetReview(int reviewId)
        {
            var result = await reviewCommentService.GetReview(reviewId);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Create the Review.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewRequest request)
        {
            var result = await reviewCommentService.CreateReview(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Update the Reviews.
        /// </summary>
        /// <param name="reviewId">The offer identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{reviewId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateReview(int reviewId, [FromBody] UpdateReviewRequest request)
        {
            var result = await reviewCommentService.UpdateReview(reviewId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Delete the Reviews.
        /// </summary>
        /// <param name="reviewId">The review identifier.</param>
        /// <returns></returns>
        [Route("{reviewId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            var result = await reviewCommentService.DeleteReview(reviewId);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the  Comment Replies
        /// </summary>
        /// <param name="commentReplyParameter">The  Comment Replies Parameters.</param>
        /// <returns></returns>
        [Route("comments")]
        [HttpGet]
        public async Task<IActionResult> GetCommentReplies([FromQuery] CommentReplyParameter commentReplyParameter)
        {
            var result = await reviewCommentService.GetCommentReplies(commentReplyParameter);
            return StatusCode((int)result.Code, result.Value);
        }

        [Route("{reviewId}/commentreply")]
        [HttpPost]
        public async Task<IActionResult> CreateCommentReply([FromBody] CreateCommentReplyRequest request)
        {
            var result = await reviewCommentService.CreateCommentReply(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Get the  CommentReply.
        /// </summary>
        /// <param name="replyCountParameter">The CommentReply identifier.</param>
        /// <param name="commentreplyId">The CommentReply identifier.</param>
        /// <returns></returns>
        [Route("{reviewId}/commentreply/{commentreplyId}")]
        [HttpGet]
        public async Task<IActionResult> GetCommentReply(int commentreplyId, [FromQuery] ReplyCountParameter replyCountParameter)
        {
            var result = await reviewCommentService.GetCommentReply(commentreplyId,replyCountParameter);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Update the CommentReply.
        /// </summary>
        /// <param name="commentreplyId">The CommentReply identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{reviewId}/commentreply/{commentreplyId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateCommentReply(int commentreplyId, [FromBody] UpdateCommentReplyRequest request)
        {
            var result = await reviewCommentService.UpdateCommentReply(commentreplyId,request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Delete the CommentReply.
        /// </summary>
        /// <param name="commentReplyId">The CommentReply identifier.</param>
        /// <returns></returns>
        [Route("{reviewId}/commentreply/{commentreplyId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCommentReply(int commentReplyId)
        {
            var result = await reviewCommentService.DeleteCommentReply(commentReplyId);
            return StatusCode((int)result.Code, result.Value);
        }

    }
}
