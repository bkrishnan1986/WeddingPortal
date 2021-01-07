#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  11-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetCommentReplyQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.CommentReply;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.CommentReply
{
    /// <summary>
    /// Query for getting a CommentReply
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetCommentReplyQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the comment Reply identifier.
        /// </summary>
        public int CommentReplyId { get; set; }


        public ReplyCountParameter ReplyCountParameter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCommentReplyQuery"/> class.
        /// </summary>
        /// <param name="commentReplyId">The comment Reply  identifier.</param>
        public GetCommentReplyQuery(int commentReplyId,ReplyCountParameter replyCountParameter)
        {
            CommentReplyId = commentReplyId;
            ReplyCountParameter = replyCountParameter;
        }
    }
}
