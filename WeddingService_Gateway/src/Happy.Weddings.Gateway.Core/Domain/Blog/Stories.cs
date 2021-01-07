using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.Domain.Blog
{
    public class Stories
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int EventType { get; set; }
        public int ServiceId { get; set; }
        public string CoverPhotoOrVideo { get; set; }
        public int VendorId { get; set; }
        public int CustomerId { get; set; }
        public int ApprovalStatus { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Multidetail ApprovalStatusNavigation { get; set; }
        public virtual Multidetail EventTypeNavigation { get; set; }
        public virtual ICollection<Taggeddata> Taggeddata { get; set; }
    }
}
