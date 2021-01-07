using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.ReviewComments
{
    /// <summary>
    /// This Class is used to map Offers Parameter
    /// </summary>
    public class ReviewsParameter : QueryStringParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReviewsParameter"/> class.
        /// </summary>
        public ReviewsParameter()
        {
            //OrderBy = "Rating desc";
        }

        /// <summary>
        /// Gets or sets the type of the review.
        /// </summary>
        /// <value>
        /// The type of the review.
        /// </value>
        public int ReviewTypeId { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public int ReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the approval status.
        /// </summary>
        /// <value>
        /// The approval status.
        /// </value>
        public int ApprovalStatusOrId { get; set; }

        public bool IsForSingReview { get; set; }
    }
}
