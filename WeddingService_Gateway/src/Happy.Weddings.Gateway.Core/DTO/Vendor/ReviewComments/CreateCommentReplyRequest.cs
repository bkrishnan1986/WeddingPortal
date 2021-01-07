using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.ReviewComments
{
    /// <summary>
    /// This Class is used to map Create CommentReply Request
    /// </summary>
    public class CreateCommentReplyRequest
    {
        /// <summary>
        /// Gets or sets the review identifier.
        /// </summary>
        /// <value>
        /// The review identifier.
        /// </value>
        public int ReviewId { get; set; }

        /// <summary>
        /// Gets or sets the comment reply.
        /// </summary>
        /// <value>
        /// The comment reply.
        /// </value>
        public string CommentReply { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public int Type { get; set; }

        /// <summary>
        /// Gets or sets the parent comment identifier.
        /// </summary>
        /// <value>
        /// The parent comment identifier.
        /// </value>
        public int? ParentCommentId { get; set; }

        /// <summary>
        /// Gets or sets the parent reply identifier.
        /// </summary>
        /// <value>
        /// The parent reply identifier.
        /// </value>
        public int? ParentReplyId { get; set; }


        public int ApprovalStatus { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public int CreatedBy { get; set; }

    }
}
