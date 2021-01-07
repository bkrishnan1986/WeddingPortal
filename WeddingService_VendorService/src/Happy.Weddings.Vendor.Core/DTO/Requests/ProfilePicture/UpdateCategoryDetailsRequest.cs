using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.ProfilePicture
{
    public class UpdateCategoryDetailsRequest
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
        public short? Active { get; set; }
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public int UpdatedBy { get; set; }
        public List<ProfilePictureS> ProfilePictureS { get; set; }
        public List<SuBCategory> SuBCategory { get; set; }
    }
    public class ProfilePictureS
    {
        public int ProflePictureId { get; set; }
        public string ProfilePicturePath { get; set; }
        public int CategoryId { get; set; }
        public int UpdatedBy { get; set; }     
    }
    public class SuBCategory
    {
        public int? CategoryId { get; set; }
        public int? SubCategoryType { get; set; }
        public string SubCategoryValue { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
