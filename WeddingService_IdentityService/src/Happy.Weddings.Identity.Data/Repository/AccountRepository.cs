#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | AccountRepository class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using Happy.Weddings.Identity.Core.Helpers;
using Happy.Weddings.Identity.Core.Repository;
using Happy.Weddings.Identity.Data.DatabaseContext;
using Happy.Weddings.Identity.Core.DTO.Requests.Account;
using Happy.Weddings.Identity.Core.DTO.Responses.Profile;

#endregion

namespace Happy.Weddings.Identity.Data.Repository
{
    /// <summary>
    /// Repository class that performs account related operations.
    /// </summary>
    public class AccountRepository : RepositoryBase<Core.Entity.Profile>, IAccountRepository
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
        /// Initializes a new instance of the <see cref="AccountRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public AccountRepository(
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
        /// Gets login details by given parameters.
        /// </summary>
        /// <param name="loginParameters">The login parameters.</param>
        /// <returns></returns>
        public async Task<Core.Entity.Profile> GetAccountDetails(AccountParameters loginParameters)
        {
            return await FindByCondition(profile => profile.UserName.Equals(loginParameters.UserName) 
                 && profile.Password.Equals(loginParameters.Password))
                .Include(ac => ac.Profilepermission)
                .Include(cd => cd.Companydistricts)
                .FirstOrDefaultAsync();
        }
    }
}
