#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  11-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | AverageRatingParameter --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using System;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.Review
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
            OrderBy = "ReferenceId";
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


