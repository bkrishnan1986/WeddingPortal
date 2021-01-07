using System;
using System.ComponentModel.DataAnnotations;

namespace Happy.Weddings.Gateway.Core.Domain.Blog
{
    public class Commentreply
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public string CommentReply { get; set; }
        public int Type { get; set; }
        public int? ParentCommentId { get; set; }
        public int? ParentReplyId { get; set; }
        public int? ApprovalStatus { get; set; }
        public short Active { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public class ReplyCount
        {
            [Key]
            public int Count { get; set; }
        }
        public virtual Review Review { get; set; }
        public virtual Multidetail TypeNavigation { get; set; }
    }
}
