#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | UserProfileRepository class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using AutoMapper;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.Identity.Core.Domain;
using Happy.Weddings.Identity.Core.Helpers;
using Happy.Weddings.Identity.Core.Repository;
using Happy.Weddings.Identity.Data.DatabaseContext;
using Happy.Weddings.Identity.Core.DTO.Requests.Profile;
using Happy.Weddings.Identity.Core.DTO.Responses.Profile;
using System;

#endregion

namespace Happy.Weddings.Identity.Data.Repository
{
    /// <summary>
    /// Repository class that performs user profile related operations.
    /// </summary>
    public class UserProfileRepository : RepositoryBase<Core.Entity.Profile>, IUserProfileRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<ProfileResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<ProfileResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfileRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public UserProfileRepository(
            IdentityContext repositoryContext,
            IMapper mapper,
            ISortHelper<ProfileResponse> sortHelper,
            IDataShaper<ProfileResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Method to perform profile create.
        /// </summary>
        /// <param name="profile">Profile data model</param>
        public void CreateUserProfile(Core.Entity.Profile profile)
        {
            Create(profile);
        }

        /// <summary>
        /// Method to perform profile update.
        /// </summary>
        /// <param name="profile">Profile data model</param>
        public void UpdateUserProfile(Core.Entity.Profile profile)
        {
            Update(profile);
        }

        /// <summary>
        /// Gets all Profiless.
        /// </summary>
        /// <param name="profileParameters">The Profile parameters.</param>
        /// <returns></returns>
        public async Task<PagedList<Entity>> GetAllUserProfiles(UserProfileParameters profileParameters)
        {
            var profiles = FindByCondition(x => x.Active == Convert.ToInt16(true));

            var filteredProfiles = FilterUserProfiles(profiles, profileParameters.UserId, profileParameters.SearchKeyword)
                .Include(ac => ac.Profilepermission)
                .Include(cd => cd.Companydistricts)
                .ProjectTo<ProfileResponse>(mapper.ConfigurationProvider);

            var sortedProfiles = sortHelper.ApplySort(filteredProfiles, profileParameters.OrderBy);

            var pagedProfiles = sortedProfiles
                .Skip((profileParameters.PageNumber - 1) * profileParameters.PageSize)
                .Take(profileParameters.PageSize);

            var mappedProfiles = pagedProfiles;

            var shapedProfiles = dataShaper.ShapeData(mappedProfiles, profileParameters.Fields);

            return await PagedList<Entity>
                .ToPagedList(shapedProfiles, profileParameters.PageNumber, profileParameters.PageSize);
        }

        /// <summary>
        /// Gets the user profile by identifier.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns></returns>
        public async Task<Core.Entity.Profile> GetUserProfileById(int profileId)
        {
            return await FindByCondition(profile => profile.Id.Equals(profileId) && profile.Active == Convert.ToInt16(true))
                .Include(ac => ac.Profilepermission)
                .Include(cd => cd.Companydistricts)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Method to update profile approval status.
        /// </summary>
        /// <param name="profile"></param>
        public void UpdateUserProfilePortion(Core.Entity.Profile profile)
        {
            Update(profile);
        }

        /// <summary>
        /// Gets the user profile permission by identifier.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns></returns>
        public async Task<ProfileResponse> GetUserProfilePermissionById(int profileId)
        {
            return await FindByCondition(profile => profile.Id.Equals(profileId))
                .Include(ac => ac.Profilepermission)
                .Include(cd => cd.Companydistricts)
                .ProjectTo<ProfileResponse>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Filters the user profiles.
        /// </summary>
        /// <param name="profileList">The profile list.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        private IQueryable<Core.Entity.Profile> FilterUserProfiles(IQueryable<Core.Entity.Profile> profileList, string userId ,string name)
        {
            if (!profileList.Any())
            {
                return profileList;
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                profileList = profileList.Where(o => o.FirstName.ToLower().Contains(name.Trim().ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(userId))
            {
                profileList = profileList.Where(o => o.UserId.ToLower().Contains(userId.Trim().ToLower()));
            }

            return profileList;
        }

        /// <summary>
        /// Gets the last inserted identifier.
        /// </summary>
        /// <returns></returns>
        public Task<int> GetLastInsertedId()
        {
            var id = RepositoryContext.Profile.OrderByDescending(x => x.Id)?.FirstOrDefault()?.Id;
            int id2 = (int)(id == null ? default(int) : id);
            return Task.FromResult(id2);
        }
    }
}