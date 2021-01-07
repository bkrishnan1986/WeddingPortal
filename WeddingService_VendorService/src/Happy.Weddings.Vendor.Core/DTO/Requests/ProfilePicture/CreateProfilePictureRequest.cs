namespace Happy.Weddings.Vendor.Core.DTO.Requests.ProfilePicture
{
    public class CreateProfilePictureRequest
    {
        public string ProfilePicturePath { get; set; }
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public int? CreatedBy { get; set; }
    }
}
