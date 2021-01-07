#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  26-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | WalletRepository --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Helpers;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Happy.Weddings.Vendor.Core.DTO.Requests.Wallet;
using Happy.Weddings.Vendor.Core.DTO.Responses.Wallet;

namespace Happy.Weddings.Vendor.Data.Repository
{
    /// <summary>
    /// SubscriptionPlansRepository
    /// </summary>
    /// <seealso cref="Happy.Weddings.Vendor.Data.Repository.RepositoryBase{Happy.Weddings.Vendor.Core.Entity.Subscription}" />
    /// <seealso cref="Happy.Weddings.Vendor.Core.Repository.ISubscriptionPlansRepository" />
    public class WalletRepository : RepositoryBase<Wallet>, IWalletRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<WalletResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<WalletResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoriesRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public WalletRepository(
            VendorContext repositoryContext,
            IMapper mapper,
            ISortHelper<WalletResponse> sortHelper,
            IDataShaper<WalletResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Gets all Wallet.
        /// </summary>
        /// <param name="walletsParameter">The Wallet parameters.</param>
        /// <returns></returns>
        public async Task<PagedList<Entity>> GetAllWallets(WalletsParameter walletsParameter)
        {
            {
                var getWalletsParams = new object[] {
                new MySqlParameter("@p_IsForSingleTransaction", walletsParameter.IsForSingleTransaction),
                new MySqlParameter("@p_IsForVendor", walletsParameter.IsForVendor),
                new MySqlParameter("@p_IsForTransactionType", walletsParameter.IsForTransactionType),
                new MySqlParameter("@p_Value", walletsParameter.Value),
            };
                var wallets = await FindAll("CALL SpSelectActiveWalletTransaction(@p_IsForSingleTransaction, @p_IsForVendor,@p_IsForTransactionType,@p_Value)", getWalletsParams).ToListAsync();
                var mappedSubscriptions = wallets.AsQueryable().ProjectTo<WalletResponse>(mapper.ConfigurationProvider);
                var sortedSubscriptions = sortHelper.ApplySort(mappedSubscriptions, walletsParameter.OrderBy);
                var shapedSubscriptions = dataShaper.ShapeData(sortedSubscriptions, walletsParameter.Fields);

                return await PagedList<Entity>.ToPagedList(shapedSubscriptions, walletsParameter.PageNumber, walletsParameter.PageSize);

            }

        }
        /// <summary>
        /// Gets the Wallet by identifier.
        /// </summary>
        /// <param name="WalletId">The Wallet identifier.</param>
        /// <returns></returns>
        public async Task<Wallet> GetWalletById(int WalletId)
        {
            var getWalletsParams = new object[] {
                new MySqlParameter("@p_IsForSingleTransaction", true),
                new MySqlParameter("@p_IsForVendor", false),
                new MySqlParameter("@p_IsForTransactionType", false),
                new MySqlParameter("@p_Value", WalletId),
            };
            var wallets = await FindAll("CALL SpSelectActiveWalletTransaction(@p_IsForSingleTransaction, @p_IsForVendor,@p_IsForTransactionType,@p_Value)", getWalletsParams).ToListAsync();
            return wallets.FirstOrDefault();
        }


        /// <summary>
        /// Gets the Wallet by identifier.
        /// </summary>
        /// <param name="VendorId">The Wallet identifier.</param>
        /// <returns></returns>
        public async Task<Wallet> GetWalletByVendorId(int VendorId)
        {
            var getWalletsParams = new object[] {
                new MySqlParameter("@p_IsForSingleTransaction", false),
                new MySqlParameter("@p_IsForVendor", true),
                new MySqlParameter("@p_IsForTransactionType", false),
                new MySqlParameter("@p_Value", VendorId),
            };
            var wallets = await FindAll("CALL SpSelectActiveWalletTransaction(@p_IsForSingleTransaction, @p_IsForVendor,@p_IsForTransactionType,@p_Value)", getWalletsParams).ToListAsync();
            return wallets.LastOrDefault();
        }
        /// <summary>
        /// Creates the Wallet.
        /// </summary>
        /// <param name="story">The Wallet.</param>
        public void CreateWallet(Wallet wallet)
        {

            Create(wallet);
        }

        /// <summary>
        /// Updates the SubscriptionPlan.
        /// </summary>
        /// <param name="subscriptionPlans">The SubscriptionPlan.</param>
        //public void UpdateSubscriptionPlan(Subscription subscriptionPlans)
        //{

        //    Update(subscriptionPlans);
        //}
    }
}

