using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Happy.Weddings.Gateway.API.Filters;
using Happy.Weddings.Gateway.Core.DTO.Blog.CommentReply;
using Happy.Weddings.Gateway.Core.Services.v1.Blog;
using Microsoft.AspNetCore.Authorization;

namespace Happy.Weddings.Gateway.API.Controllers.v1.Blog
{
    /// <summary>
    /// Review operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("CommentReply")]
    [ApiController]
    public class CommentReplyController : ControllerBase
    {
        /// <summary>
        /// The CommentReply service
        /// </summary>
        private readonly ICommentReplyService commentReplyService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentReplyController"/> class.
        /// </summary>
        /// <param name="commentReplyService">The CommentReply service.</param>
        public CommentReplyController(
            ICommentReplyService commentReplyService)
        {
            this.commentReplyService = commentReplyService;
        }

        /// <summary>
        /// Gets the CommentReply.
        /// </summary>
        /// <param name="commentReplyParametersRequest">The CommentReply parameters request.</param>
        /// <returns></returns>
        [HttpGet]
        [RequestRateLimit(Name = "Limit Request Number", Seconds = 1)]
        public async Task<IActionResult> GetReviews([FromQuery] CommentReplyParametersRequest commentReplyParametersRequest)
        {
            var result = await commentReplyService.GetCommentReplies(commentReplyParametersRequest);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the CommentReply.
        /// </summary>
        /// <param name="commentreplyId">The CommentReply identifier.</param>
        /// <returns></returns>
        [Route("{commentreplyId}")]
        [HttpGet]
        public async Task<IActionResult> GetReview(int commentreplyId)
        {
            var result = await commentReplyService.GetCommentReply(new CommentReplyIdDetails(commentreplyId));
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the CommentReply.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        //[Authorize(Roles = "Admin, Vendor")]
        public async Task<IActionResult> CreateReview([FromBody] CreateCommentReplyBlogRequest request)
        {
            var result = await commentReplyService.CreateCommentReply(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the CommentReply.
        /// </summary>
        /// <param name="commentreplyId">The CommentReply identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{commentreplyId}")]
        [HttpPut]
        //[Authorize(Roles = "Admin, Vendor")]
        public async Task<IActionResult> UpdateReview(int commentreplyId, [FromBody] UpdateCommentReplyBlogRequest request)
        {
            var result = await commentReplyService.UpdateCommentReply(new CommentReplyIdDetails(commentreplyId), request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the CommentReply.
        /// </summary>
        /// <param name="commentreplyId">The CommentReply identifier.</param>
        /// <returns></returns>
        [Route("{commentreplyId}")]
        [HttpDelete]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteReview(int commentreplyId)
        {
            var result = await commentReplyService.DeleteCommentReply(new CommentReplyIdDetails(commentreplyId));
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
