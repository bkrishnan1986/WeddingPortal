using Happy.Weddings.Vendor.Core.Entity;
using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.ProfilePicture
{
    public class CreateCategoryDetailsRequest
    {
        public int ServiceType { get; set; }
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
        public int CategoryMode { get; set; }
        public string CategoryModeName { get; set; }
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public int CreatedBy { get; set; }
       public List<ProfilePictures> ProfilePictures { get; set; }
       public List<SubCategory> SubCategory { get; set; }
    }
    public class ProfilePictures
    {
        public string ProfilePicturePath { get; set; }
    }  
    public class SubCategory
    {
        public int? SubCategoryType { get; set; }
        public string SubCategoryValue { get; set; }
    }
}
