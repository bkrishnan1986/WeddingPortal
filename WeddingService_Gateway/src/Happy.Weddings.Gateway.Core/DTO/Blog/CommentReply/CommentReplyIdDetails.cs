using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Blog.CommentReply
{
    public class CommentReplyIdDetails
    {
        /// <summary>
        /// Gets or sets the CommentReply identifier.
        /// </summary>
        public int CommentReplyId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentReplyIdDetails"/> class.
        /// </summary>
        /// <param name="commentreplyId">The CommentReply identifier.</param>
        public CommentReplyIdDetails(int commentreplyId)
        {
            CommentReplyId = commentreplyId;
        }
    }
}
