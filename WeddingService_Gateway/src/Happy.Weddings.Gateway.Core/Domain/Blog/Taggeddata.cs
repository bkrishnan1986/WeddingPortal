using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.Domain.Blog
{
    public class Taggeddata
    {
        public int Id { get; set; }
        public int StoryId { get; set; }
        public int TagId { get; set; }
        public string TagName { get; set; }
        public short Active { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public virtual Stories Story { get; set; }
    }
}
