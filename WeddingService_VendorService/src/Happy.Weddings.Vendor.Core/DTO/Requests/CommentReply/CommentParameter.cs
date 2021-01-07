#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  11-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | CommentParameter --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using System;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.CommentReply
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
            OrderBy = "ReferenceId";
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


