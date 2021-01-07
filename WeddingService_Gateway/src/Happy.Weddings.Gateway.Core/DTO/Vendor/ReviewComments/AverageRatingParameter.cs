using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.ReviewComments
{
    /// <summary>
    /// This Class is used to map AverageRating Parameter
    /// </summary>
    public class AverageRatingParameter : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentReplyParameter"/> class.
        /// </summary>
        public AverageRatingParameter()
        {
            //OrderBy = "ReferenceId";
        }

        public int ReviewTypeID { get; set; }

        /// <summary>
        /// Gets or sets the is for reply.
        /// </summary>
        /// <value>
        /// The is for reply.
        /// </value>
        public int ReferenceId { get; set; }

        public int AprovalStatus { get; set; }

    }
}
