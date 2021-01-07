using System;

namespace Happy.Weddings.Vendor.Core.Entity
{
    public partial class Subcategory
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategoryType { get; set; }
        public string SubCategoryValue { get; set; }
        public short? Active { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Categorydetails CategoryTypeNavigation { get; set; }
        public virtual Multidetail SubCategoryTypeNavigation { get; set; }
    }
}
