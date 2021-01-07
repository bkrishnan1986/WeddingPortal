#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | UpdateBenefitsCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.CommentReply;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.CommentReply
{
    /// <summary>
    /// Command for updating a CommentReply
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class UpdateCommentReplyCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the commentReply identifier.
        /// </summary>
        /// <value>
        /// The Benefit identifier.
        /// </value>
        public int CommentReplyId { get; set; }

        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public UpdateCommentReplyRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateBenefitsRequest" /> class.
        /// </summary>
        /// <param name="commentReplyId">The commentReply identifier.</param>
        /// <param name="request">The request.</param>
        public UpdateCommentReplyCommand(int commentReplyId, UpdateCommentReplyRequest request)
        {
            CommentReplyId = commentReplyId;
            Request = request;
        }
    }
}
