#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  04-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | RepositoryWrapper class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using AutoMapper;
using System.Threading.Tasks;
using Happy.Weddings.Identity.Core.Helpers;
using Happy.Weddings.Identity.Core.Repository;
using Happy.Weddings.Identity.Data.DatabaseContext;
using Happy.Weddings.Identity.Core.DTO.Responses.Role;
using Happy.Weddings.Identity.Core.DTO.Responses.Profile;
using Happy.Weddings.Identity.Core.DTO.Responses.MultiDetail;
using Happy.Weddings.Identity.Core.DTO.Responses.MultiCode;
using Happy.Weddings.Identity.Core.DTO.Responses.KYCDetail;
using Happy.Weddings.Identity.Core.DTO.Responses.UserRole;

#endregion

namespace Happy.Weddings.Identity.Data.Repository
{
    /// <summary>
    /// RepositoryWrapper class.
    /// </summary>
    /// <seealso cref="Happy.Weddings.Identity.Core.Repository.IRepositoryWrapper" />
    public class RepositoryWrapper : IRepositoryWrapper
    {
        /// <summary>
        /// Gets or sets the repository context.
        /// </summary>
        /// <value>
        /// The repository context.
        /// </value>
        private IdentityContext repositoryContext { get; set; }

        /// <summary>
        /// Gets or sets the multi code.
        /// </summary>
        /// <value>
        /// The multi code.
        /// </value>
        private IMultiCodeRepository multiCode { get; set; }

        /// <summary>
        /// Gets or sets the multidetail.
        /// </summary>
        /// <value>
        /// The multidetail.
        /// </value>
        private IMultiDetailRepository multidetail { get; set; }

        /// <summary>
        /// Gets or sets the user role.
        /// </summary>
        /// <value>
        /// The user role.
        /// </value>
        private IUserRoleRepository userRole { get; set; }

        /// <summary>
        /// The multicode sort helper
        /// </summary>
        private ISortHelper<MultiCodeResponse> multicodeSortHelper;

        /// <summary>
        /// The multidetail sort helper
        /// </summary>
        private ISortHelper<MultiDetailResponse> multidetailSortHelper;

        /// <summary>
        /// The multidetail data shaper
        /// </summary>
        private IDataShaper<MultiDetailResponse> multidetailDataShaper;

        /// <summary>
        /// The multicode data shaper
        /// </summary>
        private IDataShaper<MultiCodeResponse> multicodeDataShaper;

        /// <summary>
        /// The user role data shaper
        /// </summary>
        private IDataShaper<UserRoleResponse> userRoleDataShaper;

        /// <summary>
        /// The user role sort helper
        /// </summary>
        private ISortHelper<UserRoleResponse> userRoleSortHelper;

        /// <summary>
        /// The profile sort helper
        /// </summary>
        private ISortHelper<ProfileResponse> profileSortHelper;

        /// <summary>
        /// The profile data shaper
        /// </summary>
        private IDataShaper<ProfileResponse> profileDataShaper;

        /// <summary>
        /// The account sort helper
        /// </summary>
        private ISortHelper<ProfileResponse> accountSortHelper;

        /// <summary>
        /// The account data shaper
        /// </summary>
        private IDataShaper<ProfileResponse> accountDataShaper;

        /// <summary>
        /// The role sort helper
        /// </summary>
        private ISortHelper<RoleResponse> roleSortHelper;

        /// <summary>
        /// The role data shaper
        /// </summary>
        private IDataShaper<RoleResponse> roleDataShaper;

        /// <summary>
        /// The kyc sort helper
        /// </summary>
        private ISortHelper<KYCDataResponse> kycSortHelper;

        /// <summary>
        /// The kyc data shaper
        /// </summary>
        private IDataShaper<KYCDataResponse> kycDataShaper;

        /// <summary>
        /// The kyc sort helper
        /// </summary>
        private ISortHelper<KYCDetailResponse> kycDetailSortHelper;

        /// <summary>
        /// The kyc data shaper
        /// </summary>
        private IDataShaper<KYCDetailResponse> kycDetailDataShaper;

        /// <summary>
        /// Gets or sets the profiles.
        /// </summary>
        /// <value>
        /// The profiles.
        /// </value>
        private IUserProfileRepository profiles { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        private IRoleRepository role { get; set; }

        /// <summary>
        /// Gets or sets the account.
        /// </summary>
        /// <value>
        /// The account.
        /// </value>
        private IAccountRepository account { get; set; }

        /// <summary>
        /// Gets or sets the kyc detail.
        /// </summary>
        /// <value>
        /// The kyc detail.
        /// </value>
        public IKYCDataRepository kycData { get; set; }

        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryWrapper"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="profileDataShaper">The profile data shaper.</param>
        /// <param name="profileSortHelper">The profile sort helper.</param>
        /// <param name="roleDataShaper">The role data shaper.</param>
        /// <param name="roleSortHelper">The role sort helper.</param>
        /// <param name="accountDataShaper">The account data shaper.</param>
        /// <param name="accountSortHelper">The account sort helper.</param>
        /// <param name="multicodeSortHelper">The multicode sort helper.</param>
        /// <param name="multicodeDataShaper">The multicode data shaper.</param>
        /// <param name="multidetailSortHelper">The multidetail sort helper.</param>
        /// <param name="multidetailDataShaper">The multidetail data shaper.</param>
        /// <param name="kycSortHelper">The kyc sort helper.</param>
        /// <param name="kycDataShaper">The kyc data shaper.</param>
        public RepositoryWrapper(
            IdentityContext repositoryContext,
            IMapper mapper,
            IDataShaper<ProfileResponse> profileDataShaper,
            ISortHelper<ProfileResponse> profileSortHelper,
            IDataShaper<RoleResponse> roleDataShaper,
            ISortHelper<RoleResponse> roleSortHelper,
            IDataShaper<ProfileResponse> accountDataShaper,
            ISortHelper<ProfileResponse> accountSortHelper,
            ISortHelper<MultiCodeResponse> multicodeSortHelper,
            IDataShaper<MultiCodeResponse> multicodeDataShaper,
            ISortHelper<MultiDetailResponse> multidetailSortHelper,
            IDataShaper<MultiDetailResponse> multidetailDataShaper,
            ISortHelper<KYCDataResponse> kycSortHelper,
            IDataShaper<KYCDataResponse> kycDataShaper,
            ISortHelper<KYCDetailResponse> kycDetailSortHelper,
            IDataShaper<KYCDetailResponse> kycDetailDataShaper,
            ISortHelper<UserRoleResponse> userRoleSortHelper,
            IDataShaper<UserRoleResponse> userRoleDataShaper)
        {
            this.multicodeSortHelper = multicodeSortHelper;
            this.multicodeDataShaper = multicodeDataShaper;
            this.multidetailSortHelper = multidetailSortHelper;
            this.multidetailDataShaper = multidetailDataShaper;
            this.repositoryContext = repositoryContext;
            this.mapper = mapper;
            this.profileDataShaper = profileDataShaper;
            this.profileSortHelper = profileSortHelper;
            this.roleDataShaper = roleDataShaper;
            this.roleSortHelper = roleSortHelper;
            this.userRoleDataShaper = userRoleDataShaper;
            this.userRoleSortHelper = userRoleSortHelper;
            this.accountDataShaper = accountDataShaper;
            this.accountSortHelper = accountSortHelper;
            this.kycDataShaper = kycDataShaper;
            this.kycSortHelper = kycSortHelper;
            this.kycDetailDataShaper = kycDetailDataShaper;
            this.kycDetailSortHelper = kycDetailSortHelper;
        }

        /// <summary>
        /// Gets the multicode.
        /// </summary>
        public IMultiCodeRepository MultiCodes
        {
            get
            {
                if (multiCode == null)
                {
                    multiCode = new MultiCodeRepository(repositoryContext, mapper, multicodeSortHelper, multicodeDataShaper);
                }
                return multiCode;
            }
        }

        /// <summary>
        /// Gets the multidetails.
        /// </summary>
        public IMultiDetailRepository MultiDetails
        {
            get
            {
                if (multidetail == null)
                {
                    multidetail = new MultiDetailRepository(repositoryContext, mapper, multidetailSortHelper, multidetailDataShaper);
                }
                return multidetail;
            }
        }

        public IUserRoleRepository UserRolesRepository
        {
            get
            {
                if (userRole == null)
                {
                    userRole = new UserRoleRepository(repositoryContext, mapper, userRoleSortHelper, userRoleDataShaper);
                }
                return userRole;
            }
        }

        /// <summary>
        /// ProfileRepository instance
        /// </summary>
        public IUserProfileRepository ProfileRepository
        {
            get
            {
                if (profiles == null)
                {
                    profiles = new UserProfileRepository(repositoryContext, mapper, profileSortHelper, profileDataShaper);
                }
                return profiles;
            }
        }

        /// <summary>
        /// RpoleRepository instance
        /// </summary>
        public IRoleRepository RoleRepository
        {
            get
            {
                if (role == null)
                {
                    role = new RoleRepository(repositoryContext, mapper, roleSortHelper, roleDataShaper);
                }
                return role;
            }
        }

        /// <summary>
        /// Gets the account repository.
        /// </summary>
        /// <value>
        /// The account repository.
        /// </value>
        public IAccountRepository AccountRepository
        {
            get
            {
                if (account == null)
                {
                    account = new AccountRepository(repositoryContext, mapper, accountSortHelper, accountDataShaper);
                }
                return account;
            }
        }

        /// <summary>
        /// Gets the kyc detail repository.
        /// </summary>
        /// <value>
        /// The kyc detail repository.
        /// </value>
        public IKYCDataRepository KYCDataRepository
        {
            get
            {
                if (kycData == null)
                {
                    kycData = new KYCDataRepository(repositoryContext, mapper, kycSortHelper, kycDataShaper);
                }
                return kycData;
            }
        }

        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveAsync()
        {
            return await repositoryContext.SaveChangesAsync() >= 0;
        }
    }
}
