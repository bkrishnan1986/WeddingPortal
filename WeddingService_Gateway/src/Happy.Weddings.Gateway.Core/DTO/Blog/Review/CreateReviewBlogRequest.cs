using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Blog.Review
{
    public class CreateReviewBlogRequest
    {
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public int ReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the type of the review.
        /// </summary>
        /// <value>
        /// The type of the review.
        /// </value>
        public int ReviewType { get; set; }

        /// <summary>
        /// Gets or sets the email of.
        /// </summary>
        /// <value>
        /// The email of.
        /// </value>
        public string EmailOf { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>
        /// The rating.
        /// </value>
        public byte? Rating { get; set; }

        /// <summary>
        /// Gets or sets the reviewed by.
        /// </summary>
        /// <value>
        /// The reviewed by.
        /// </value>
        public int ReviewedBy { get; set; }

        /// <summary>
        /// Gets or sets the approval status.
        /// </summary>
        /// <value>
        /// The approval status.
        /// </value>
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
