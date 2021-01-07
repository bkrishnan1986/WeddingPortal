using System;
using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.Entity
{
    public partial class Categorydetails
    {
        public Categorydetails()
        {
            Profilepictures = new HashSet<Profilepictures>();
            Subcategory = new HashSet<Subcategory>();
        }

        public int CategoryId { get; set; }
        public int? ServiceType { get; set; }
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public int VendorStatus { get; set; }
        public string VendorStatusName { get; set; }
        public string WebsiteLink { get; set; }
        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public string PinterestLink { get; set; }
        public string TwitterHandle { get; set; }
        public string ProfilePicture { get; set; }
        public string VideoLink { get; set; }
        public int? CategoryMode { get; set; }
        public string CategoryModeName { get; set; }
        public short? Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Branchserviceoffered ServiceTypeNavigation { get; set; }
        public virtual ICollection<Profilepictures> Profilepictures { get; set; }
        public virtual ICollection<Subcategory> Subcategory { get; set; }
    }
}
