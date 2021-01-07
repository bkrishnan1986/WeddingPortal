using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Vendor.ReviewComments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Vendor
{
    public interface IReviewCommentService
    {
        Task<APIResponse> GetReviews(ReviewsParameter reviewsParameter);
        Task<APIResponse> GetReview(int reviewId);
        Task<APIResponse> DeleteReview(int reviewId);
        Task<APIResponse> UpdateReview(int reviewId, UpdateReviewRequest request);
        Task<APIResponse> CreateReview(CreateReviewRequest request);
        Task<APIResponse> DeleteCommentReply(int commentReplyId);
        Task<APIResponse> UpdateCommentReply(int commentreplyId, UpdateCommentReplyRequest request);
        Task<APIResponse> GetCommentReply(int commentreplyId, ReplyCountParameter replyCountParameter);
        Task<APIResponse> CreateCommentReply(CreateCommentReplyRequest request);
        Task<APIResponse> GetCommentReplies(CommentReplyParameter commentReplyParameter);
    }
}
