#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  11-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | CommentRepliesResponse --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Happy.Weddings.Vendor.Core.DTO.Responses.CommentReply
{
    /// <summary>
    /// This Class is used to map Benefits Response
    /// </summary>
    public class CommentReplyResponse
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

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

        /// <summary>
        /// Gets or sets the active.
        /// </summary>
        /// <value>
        /// The active.
        /// </value>
        public short? Active { get; set; }

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

        //public int ID { get; set; }

        //public int ReferenceID { get; set; }

        //public float AverageRatings { get; set; }

    }
}
