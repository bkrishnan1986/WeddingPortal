using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Blog.Review
{
    public class ReviewIdDetails
    {
        /// <summary>
        /// Gets or sets the Review identifier.
        /// </summary>
        public int ReviewId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReviewIdDetails"/> class.
        /// </summary>
        /// <param name="reviewId">The Review identifier.</param>
        public ReviewIdDetails(int reviewId)
        {
            ReviewId = reviewId;
        }
    }
}
