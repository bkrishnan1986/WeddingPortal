#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | CreateBenefitCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.CommentReply
{
    /// <summary>
    /// Command for deleting a CommentReply
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class DeleteCommentReplyCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the CommentReply identifier.
        /// </summary>
        public int CommentReplyId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCommentReplyCommand"/> class.
        /// </summary>
        /// <param name="CommentReplyId">The CommentReply identifier.</param>
        public DeleteCommentReplyCommand(int commentReplyId)
        {
            CommentReplyId = commentReplyId;
        }
    }
}
