using Happy.Weddings.Vendor.Core.Domain;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.ProfilePicture
{
    public class ProfilePictureParameters : QueryStringParameters
    {
        public string ProfilePicturePath { get; set; }
    }
}
