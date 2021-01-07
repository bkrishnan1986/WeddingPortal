using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Happy.Weddings.Vendor.Core.DTO.Responses.ProfilePicture;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Helpers;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Happy.Weddings.Vendor.Data.Repository
{
    public class ProfilePictureRepository : RepositoryBase<Profilepictures>, IProfilePictureRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<ProfilePictureResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<ProfilePictureResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfilePictureRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public ProfilePictureRepository(
            VendorContext repositoryContext,
            IMapper mapper,
            ISortHelper<ProfilePictureResponse> sortHelper,
            IDataShaper<ProfilePictureResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        public async Task<Profilepictures> GetProfilePictureById(int profilePictureId)
        {
            var getProfilePictureParameters = new object[] {
                new MySqlParameter("@limit", null),
                new MySqlParameter("@offset", null),
                new MySqlParameter("@value", profilePictureId),
                new MySqlParameter("@fromDate", null),
                new MySqlParameter("@toDate", null),
                new MySqlParameter("@IsForVendor", true)
            };

            var events = await FindAll("CALL SpSelectActiveProfilePicture(@limit, @offset, @value, @IsForVendor, @fromDate, @toDate)", getProfilePictureParameters).ToListAsync();
            return events.FirstOrDefault(); 
        }

        /// <summary>
        /// Creates the event.
        /// </summary>
        /// <param name="event">The event.</param>
        public void CreateProfilePicture(Profilepictures profilepictures)
        {
            Create(profilepictures);
        }

        /// <summary>
        /// Updates the event.
        /// </summary>
        /// <param name="event">The event.</param>
        public void UpdateProfilePicture(Profilepictures profilepictures)
        {
            Update(profilepictures);
        }
    }
}
