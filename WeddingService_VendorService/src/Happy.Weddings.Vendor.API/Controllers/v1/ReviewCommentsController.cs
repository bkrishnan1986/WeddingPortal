#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  12-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | ReviewCommentsController Controller.
//----------------------------------------------------------------------------------------------

#endregion File Header

using System.Net;
using System.Threading.Tasks;
using Happy.Weddings.Vendor.Core.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Happy.Weddings.Vendor.Core.DTO.Requests.Review;
using Happy.Weddings.Vendor.Service.Queries.v1.Review;
using Happy.Weddings.Vendor.Service.Commands.v1.Review;
using Happy.Weddings.Vendor.Core.DTO.Requests.CommentReply;
using Happy.Weddings.Vendor.Service.Commands.v1.CommentReply;
using Happy.Weddings.Vendor.Service.Queries.v1.CommentReply;

namespace Happy.Weddings.Vendor.API.Controllers.v1
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
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReviewCommentsController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public ReviewCommentsController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }
        /// <summary>
        /// Gets the  Reviews
        /// </summary>
        /// <param name="reviewsParameter">The  Reviews Parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetReviews([FromQuery] ReviewsParameter reviewsParameter)
        {
            var getAllReviewsQuery = new GetAllReviewsQuery(reviewsParameter);
            var result = await mediator.Send(getAllReviewsQuery);

            if (result.Code == HttpStatusCode.OK)
            {
                Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));
            }

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
            var getReviewQuery = new GetReviewQuery(reviewId);
            var result = await mediator.Send(getReviewQuery);
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
            var createReviewCommand = new CreateReviewCommand(request);
            var result = await mediator.Send(createReviewCommand);
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
            var updateReviewCommand = new UpdateReviewCommand(reviewId, request);
            var result = await mediator.Send(updateReviewCommand);
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
            var deleteReviewCommand = new DeleteReviewCommand(reviewId);
            var result = await mediator.Send(deleteReviewCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Average Rating the Reviews.
        /// </summary>
        /// <param name="averageRatingParameter">The review identifier.</param>
        /// <returns></returns>
        //[HttpGet]
        //public async Task<IActionResult> GetAverageReview([FromQuery] AverageRatingParameter averageRatingParameter)
        //{    
        //    var getAverageRatingQuery = new GetAllAverageRatingQuery(averageRatingParameter);
        //    var result = await mediator.Send(getAverageRatingQuery);
        //    if (result.Code == HttpStatusCode.OK)
        //    {
        //        Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));
        //    }

        //    return StatusCode((int)result.Code, result.Value);
        //}


        /// <summary>
        /// Gets the  Comment Replies
        /// </summary>
        /// <param name="commentReplyParameter">The  Comment Replies Parameters.</param>
        /// <returns></returns>
        [Route("comments")]
        [HttpGet]
        public async Task<IActionResult> GetCommentReplies([FromQuery] CommentReplyParameter commentReplyParameter)
        {
            var getAllCommentRepliesQuery = new GetAllCommentRepliesQuery(commentReplyParameter);
            var result = await mediator.Send(getAllCommentRepliesQuery);

            if (result.Code == HttpStatusCode.OK)
            {
                Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));
            }

            return StatusCode((int)result.Code, result.Value);
        }
        /// <summary>
        /// Gets the  Comment Replies
        /// </summary>
        /// <param name="commentParameter">The  Comment Replies Parameters.</param>
        /// <returns></returns>
        //[Route("allactivecomments")]
        //[HttpGet]
        //public async Task<IActionResult> GetComments([FromQuery] CommentParameter commentParameter)
        //{
        //    var getAllCommentsQuery = new GetAllCommentsQuery(commentParameter);
        //    var result = await mediator.Send(getAllCommentsQuery);

        //    if (result.Code == HttpStatusCode.OK)
        //    {
        //        Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));
        //    }

        //    return StatusCode((int)result.Code, result.Value);
        //}
 
        /// <summary>
        /// Create the CommentReply.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{reviewId}/commentreply")]
        [HttpPost]
        public async Task<IActionResult> CreateCommentReply([FromBody] CreateCommentReplyRequest request)
        {
            var createCommentReplyCommand = new CreateCommentReplyCommand(request);
            var result = await mediator.Send(createCommentReplyCommand);
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
        public async Task<IActionResult> GetCommentReply(int commentreplyId , [FromQuery] ReplyCountParameter replyCountParameter)
        {
            var getCommentReplyQuery = new GetCommentReplyQuery(commentreplyId, replyCountParameter);
            var result = await mediator.Send(getCommentReplyQuery);
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
            var updateCommentReplyCommand = new UpdateCommentReplyCommand(commentreplyId, request);
            var result = await mediator.Send(updateCommentReplyCommand);
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
            var deleteCommentReplyCommand = new DeleteCommentReplyCommand(commentReplyId);
            var result = await mediator.Send(deleteCommentReplyCommand);
            return StatusCode((int)result.Code, result.Value);
        }

    }
}