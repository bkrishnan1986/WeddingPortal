using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.Domain.Blog
{
    public class Review
    {
        public int Id { get; set; }
        public int ReferenceId { get; set; }
        public string Email { get; set; }
        public int ReviewType { get; set; }
        public string EmailOf { get; set; }
        public byte? Rating { get; set; }
        public int ReviewedBy { get; set; }
        public int ApprovalStatus { get; set; }
        public short Active { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public class Ratings
        {
            public int Id { get; set; }
            public int ReferenceId { get; set; }
            public float AverageRating { get; set; }
        }
        public virtual Multidetail ApprovalStatusNavigation { get; set; }
        public virtual Multidetail ReviewTypeNavigation { get; set; }
        public virtual ICollection<Commentreply> Commentreply { get; set; }
    }
}
