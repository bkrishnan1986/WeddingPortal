#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  11-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetAllCommentsQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.CommentReply;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.CommentReply
{
    /// <summary>
    /// Query for getting Comment Replies
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetAllCommentsQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Comment Reply parameters.
        /// </summary>
        public CommentParameter CommentParameter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllCommentRepliesQuery"/> class.
        /// </summary>
        /// <param name="commentReplyParameter">The Comment Reply parameters.</param>
        public GetAllCommentsQuery(CommentParameter commentParameter)
        {
            CommentParameter = commentParameter;
        }
    }
}
