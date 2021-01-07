#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | RoleRepository class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.Identity.Core.Entity;
using Happy.Weddings.Identity.Core.Domain;
using Happy.Weddings.Identity.Core.Helpers;
using Happy.Weddings.Identity.Core.Repository;
using Happy.Weddings.Identity.Data.DatabaseContext;
using Happy.Weddings.Identity.Core.DTO.Requests.Role;
using Happy.Weddings.Identity.Core.DTO.Responses.Role;
using System.Collections.Generic;

#endregion

namespace Happy.Weddings.Identity.Data.Repository
{
    /// <summary>
    /// Repository class that performs role settings related operations.
    /// </summary>
    public class RoleRepository : RepositoryBase<Profilepermission>, IRoleRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<RoleResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<RoleResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public RoleRepository(
            IdentityContext repositoryContext,
            IMapper mapper,
            ISortHelper<RoleResponse> sortHelper,
            IDataShaper<RoleResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Gets the role settings by profile identifier.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns></returns>
        public async Task<Profilepermission> GetUserPermissonsByProfileId(int profileId)
        {
            var getProfileParams = new object[] {
                new MySqlParameter("@p_SearchKeyword", "ProfileId"),
                new MySqlParameter("@p_Value", profileId),
                new MySqlParameter("@p_Limit", null),
                new MySqlParameter("@p_Offset", null),
                new MySqlParameter("@p_FromDate", null),
                new MySqlParameter("@p_ToDate", null)
            };
            var role = await FindAll("CALL spGetUserPermissions(@p_SearchKeyword,@p_Value, @p_Limit, @p_Offset, @p_FromDate, @p_FromDate)",
                getProfileParams).ToListAsync();
            return role.FirstOrDefault();
        }

    }
}
