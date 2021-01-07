using System.Threading.Tasks;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Repository
{
    public interface IProfilePictureRepository : IRepositoryBase<Profilepictures>
    {
        /// <summary>
        /// Gets  event.
        /// </summary>
        /// <param name="profilePictureId"></param>
        /// <returns></returns>
        Task<Profilepictures> GetProfilePictureById(int profilePictureId);

        /// <summary>
        /// Creates the profilepictures.
        /// </summary>
        /// <param name="profilepictures">The event.</param>
        void CreateProfilePicture(Profilepictures profilepictures);

        /// <summary>
        /// Updates the profilepictures.
        /// </summary>
        /// <param name="profilepictures">The event.</param>
        void UpdateProfilePicture(Profilepictures profilepictures);

    }
}
