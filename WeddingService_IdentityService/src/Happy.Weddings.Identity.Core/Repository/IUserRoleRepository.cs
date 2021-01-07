#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | IUserRoleRepository interface.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System.Threading.Tasks;
using Happy.Weddings.Identity.Core.Domain;
using Happy.Weddings.Identity.Core.DTO.Requests.Profile;
using Happy.Weddings.Identity.Core.DTO.Requests.UserRole;
using Happy.Weddings.Identity.Core.DTO.Responses.Profile;
using Happy.Weddings.Identity.Core.Entity;

#endregion

namespace Happy.Weddings.Identity.Core.Repository
{
    /// <summary>
    /// Repository interface for user role operations.
    /// </summary>
    public interface IUserRoleRepository : IRepositoryBase<Rolesettings>
    {

        /// <summary>
        /// Creates the user role.
        /// </summary>
        /// <param name="role">The role.</param>
        void CreateUserRole(Rolesettings role);

        /// <summary>
        /// Updates the user role.
        /// </summary>
        /// <param name="role">The role.</param>
        void UpdateUserRole(Rolesettings role);

        /// <summary>
        /// Gets all user profiles.
        /// </summary>
        /// <param name="profileParameters">The profile parameters.</param>
        /// <returns></returns>
        Task<PagedList<Domain.Entity>> GetAllUserRoles(UserRoleParameters roleParameters);

        /// <summary>
        /// Gets the user profile by identifier.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns></returns>
        Task<Rolesettings> GetUserRole(int roleId);
    }
}
