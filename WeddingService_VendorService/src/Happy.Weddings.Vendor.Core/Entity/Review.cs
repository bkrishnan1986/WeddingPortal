#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | Benefits --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using System;
using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.Entity
{
    public partial class Review
    {
        public Review()
        {
            Commentreply = new HashSet<Commentreply>();
        }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

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
        /// Gets or sets the active.
        /// </summary>
        /// <value>
        /// The active.
        /// </value>
        public short Active { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        public int? UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>
        /// The updated at.
        /// </value>
        public DateTime? UpdatedAt { get; set; }


        public  class Ratings
        {
            public int Id { get; set; }

            public int ReferenceId { get; set; }

            public float AverageRating { get; set; }
        }
        /// <summary>
        /// Gets or sets the approval status navigation.
        /// </summary>
        /// <value>
        /// The approval status navigation.
        /// </value>
        public virtual Multidetail ApprovalStatusNavigation { get; set; }

        /// <summary>
        /// Gets or sets the review type navigation.
        /// </summary>
        /// <value>
        /// The review type navigation.
        /// </value>
        public virtual Multidetail ReviewTypeNavigation { get; set; }

        /// <summary>
        /// Gets or sets the commentreply.
        /// </summary>
        /// <value>
        /// The commentreply.
        /// </value>
        public virtual ICollection<Commentreply> Commentreply { get; set; }
    }
}
