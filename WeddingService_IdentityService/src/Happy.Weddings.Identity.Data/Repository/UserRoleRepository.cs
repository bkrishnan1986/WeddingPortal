#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | UserRoleRepository class.
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
using Happy.Weddings.Identity.Core.Entity;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using Happy.Weddings.Identity.Core.DTO.Requests.UserRole;
using Happy.Weddings.Identity.Core.DTO.Responses.UserRole;

#endregion

namespace Happy.Weddings.Identity.Data.Repository
{
    /// <summary>
    /// Repository class that performs user role related operations.
    /// </summary>
    public class UserRoleRepository : RepositoryBase<Rolesettings>, IUserRoleRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<UserRoleResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<UserRoleResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfileRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public UserRoleRepository(
            IdentityContext repositoryContext,
            IMapper mapper,
            ISortHelper<UserRoleResponse> sortHelper,
            IDataShaper<UserRoleResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        public void CreateUserRole(Rolesettings role)
        {
            Create(role);
        }

        public Task<PagedList<Entity>> GetAllUserRoles(UserRoleParameters roleParameters)
        {
            return null;//await FindByCondition(role => role.Id.Equals(roleId)).ToListAsync();
        }

        /// <summary>
        /// Gets the user profile by identifier.
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<Rolesettings> GetUserRole(int roleId)
        {
            return await FindByCondition(role => role.Id.Equals(roleId))
                .FirstOrDefaultAsync();
        }

        public void UpdateUserRole(Rolesettings role)
        {
            Update(role);
        }
    }
}