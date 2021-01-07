using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.ReviewComments
{
    /// <summary>
    /// This Class is used to map Comment Parameter
    /// </summary>
    public class CommentParameter : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentReplyParameter"/> class.
        /// </summary>
        public CommentParameter()
        {
            //OrderBy = "ReferenceId";
        }
        /// <summary>
        /// Gets or sets the is for comment.
        /// </summary>
        /// <value>
        /// The is for comment.
        /// </value>
        public int ReviewType { get; set; }

        /// <summary>
        /// Gets or sets the is for reply.
        /// </summary>
        /// <value>
        /// The is for reply.
        /// </value>
        public int ReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int ApprovalStatus { get; set; }

    }
}
