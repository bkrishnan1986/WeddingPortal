#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | Commentreply --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using System;
using System.ComponentModel.DataAnnotations;

namespace Happy.Weddings.Vendor.Core.Entity
{
    public partial class Commentreply
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public string CommentReply { get; set; }
        public int Type { get; set; }
        public int? ParentCommentId { get; set; }
        public int? ParentReplyId { get; set; }

        public int ApprovalStatus { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public class ReplyCount
        {
            [Key]
            public int Count { get; set; }
        }
        public virtual Multidetail ApprovalStatusNavigation { get; set; }
        public virtual Review Review { get; set; }
        public virtual Multidetail TypeNavigation { get; set; }
    }
}
