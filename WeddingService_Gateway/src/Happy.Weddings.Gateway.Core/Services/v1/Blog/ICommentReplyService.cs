using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Blog.CommentReply;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Blog
{
    /// <summary>
    /// Service interface for post related operations
    /// </summary>
    public interface ICommentReplyService
    {
        /// <summary>
        /// Gets the CommentReply.
        /// </summary>
        /// <param name="commentReplyParametersRequest">The CommentReply parameters request.</param>
        /// <returns></returns>
        Task<APIResponse> GetCommentReplies(CommentReplyParametersRequest commentReplyParametersRequest);

        /// <summary>
        /// Gets the CommentReply.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> GetCommentReply(CommentReplyIdDetails details);

        /// <summary>
        /// Creates the CommentReply.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> CreateCommentReply(CreateCommentReplyBlogRequest request);

        /// <summary>
        /// Updates the CommentReply.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> UpdateCommentReply(CommentReplyIdDetails details, UpdateCommentReplyBlogRequest request);

        /// <summary>
        /// Deletes the CommentReply.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> DeleteCommentReply(CommentReplyIdDetails details);
    }
}
