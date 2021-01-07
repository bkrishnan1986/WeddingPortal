using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.ReviewComments
{
    /// <summary>
    /// This Class is used to map Offers Parameter
    /// </summary>
    public class CommentReplyParameter : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentReplyParameter"/> class.
        /// </summary>
        public CommentReplyParameter()
        {
            //OrderBy = "ReferenceId";
        }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int value { get; set; }

        public int ApprovalStatus { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is for single commentreply.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is for single commentreply; otherwise, <c>false</c>.
        /// </value>
        public bool IsForSingleCommentreply { get; set; }

        /// <summary>
        /// Gets or sets the is for comment.
        /// </summary>
        /// <value>
        /// The is for comment.
        /// </value>
        public bool IsForComment { get; set; }

        /// <summary>
        /// Gets or sets the is for reply.
        /// </summary>
        /// <value>
        /// The is for reply.
        /// </value>
        public bool IsForReply { get; set; }

        /// <summary>
        /// Gets or sets the is for child reply.
        /// </summary>
        /// <value>
        /// The is for child reply.
        /// </value>
        public bool IsForChildReply { get; set; }

    }
}
