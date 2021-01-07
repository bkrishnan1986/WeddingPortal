namespace Happy.Weddings.Vendor.Core.DTO.Requests.ProfilePicture
{
    public class UpdateProfilePictureRequest
    {
        public int ProflePictureId { get; set; }
        public string ProfilePicturePath { get; set; }
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public int? UpdatedBy { get; set; }
    }
}
