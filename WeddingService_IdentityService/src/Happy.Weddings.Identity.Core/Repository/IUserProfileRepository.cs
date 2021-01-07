#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | IUserProfileRepository interface.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System.Threading.Tasks;
using Happy.Weddings.Identity.Core.Domain;
using Happy.Weddings.Identity.Core.DTO.Requests.Profile;
using Happy.Weddings.Identity.Core.DTO.Responses.Profile;

#endregion

namespace Happy.Weddings.Identity.Core.Repository
{
    /// <summary>
    /// Repository interface for user profile operations.
    /// </summary>
    public interface IUserProfileRepository : IRepositoryBase<Entity.Profile>
    {

        /// <summary>
        /// Create user profile.
        /// </summary>
        /// <param name="profile">The profile.</param>
        void CreateUserProfile(Entity.Profile profile);

        /// <summary>
        /// Update user profile.
        /// </summary>
        /// <param name="profile"></param>
        void UpdateUserProfile(Entity.Profile profile);

        /// <summary>
        /// Update user profile portion.
        /// </summary>
        /// <param name="">profile</param>
        void UpdateUserProfilePortion(Entity.Profile profile);

        /// <summary>
        /// Gets all user profiles.
        /// </summary>
        /// <param name="profileParameters">The profile parameters.</param>
        /// <returns></returns>
        Task<PagedList<Domain.Entity>> GetAllUserProfiles(UserProfileParameters profileParameters);

        /// <summary>
        /// Gets the user profile by identifier.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns></returns>
        Task<Entity.Profile> GetUserProfileById(int profileId);

        /// <summary>
        /// Gets the user profile permission by identifier.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns></returns>
        Task<ProfileResponse> GetUserProfilePermissionById(int profileId);

        /// <summary>
        /// Gets the last inserted identifier.
        /// </summary>
        /// <returns></returns>
        Task<int> GetLastInsertedId();
    }
}
