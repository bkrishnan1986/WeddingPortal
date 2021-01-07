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

#endregion

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.Wallet.Core.Domain;
using Happy.Weddings.Wallet.Core.Entity;
using Happy.Weddings.Wallet.Core.Helpers;
using Happy.Weddings.Wallet.Core.Repository;
using Happy.Weddings.Wallet.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Happy.Weddings.Wallet.Core.DTO.Requests.Wallet;
using Happy.Weddings.Wallet.Core.DTO.Responses.Wallet;
using System.Collections.Generic;
using System;

namespace Happy.Weddings.Wallet.Data.Repository
{
    /// <summary>
    /// WalletRepository
    /// </summary>
    /// <seealso cref="Happy.Weddings.Wallet.Data.Repository.RepositoryBase{Happy.Weddings.Wallet.Core.Entity.Wallets}" />
    /// <seealso cref="Happy.Weddings.Wallet.Core.Repository.IWalletRepository" />
    public class WalletRepository : RepositoryBase<Wallets>, IWalletRepository
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
        /// Initializes a new instance of the <see cref="WalletRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public WalletRepository(
            WalletContext repositoryContext,
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
        public async Task<List<Wallets>> GetAllWallets(WalletsParameter walletsParameter)
        {
                var getWalletsParams = new object[]
                {
                    new MySqlParameter("@p_Limit", walletsParameter.PageSize),
                    new MySqlParameter("@p_Offset", (walletsParameter.PageNumber - 1) * walletsParameter.PageSize),
                    new MySqlParameter("@p_VendorId", walletsParameter.VendorId),
                    new MySqlParameter("@p_StatusId", walletsParameter.StatusId),
                    new MySqlParameter("@p_Balance", walletsParameter.Balance),
                    new MySqlParameter("@p_IsForCutoff", walletsParameter.IsForCutoff),
                    new MySqlParameter("@p_IsForBalance", walletsParameter.IsForBalance),
                    new MySqlParameter("@p_FromDate", walletsParameter.FromDate),
                    new MySqlParameter("@p_ToDate", walletsParameter.ToDate)
                };

                var wallets = await FindAll("CALL SpSearchWallet(@p_Limit,@p_Offset,@p_VendorId,@p_StatusId,@p_Balance,@p_IsForCutoff,@p_IsForBalance,@p_FromDate,@p_ToDate)", getWalletsParams).ToListAsync();

                return wallets;
        }

        public async Task<List<WalletResponse>> GetAllWallet(WalletsParameter walletsParameter)
        {
            var wallets = FindByCondition(x => x.Active == Convert.ToInt16(true)).ProjectTo<WalletResponse>(mapper.ConfigurationProvider);
            SearchByWallet(ref wallets, walletsParameter);
            FilterByDate(ref wallets, walletsParameter.FromDate, walletsParameter.ToDate);
            var sortedWallets = sortHelper.ApplySort(wallets, walletsParameter.OrderBy);
            var pagedWallets = sortedWallets
                               .Skip((walletsParameter.PageNumber - 1) * walletsParameter.PageSize)
                               .Take(walletsParameter.PageSize);
            return await pagedWallets.ToListAsync();
        }

        private void SearchByWallet(ref IQueryable<WalletResponse> wallets, WalletsParameter walletsParameter)
        {
            if (walletsParameter.VendorId > 0)
            {
                wallets = wallets.Where(x => x.VendorId.Equals(walletsParameter.VendorId));
            }
            if (walletsParameter.StatusId > 0)
            {
                wallets = wallets.Where(x => x.Status.Equals(walletsParameter.StatusId));
            }
            if (walletsParameter.IsForCutoff == true)
            {
                wallets = wallets.Where(x => x.Balance < walletsParameter.Balance);
            }
            else if (walletsParameter.IsForBalance == true)
            {
                wallets = wallets.Where(x => x.Balance == walletsParameter.Balance);
            }
        }

        private void FilterByDate(ref IQueryable<WalletResponse> wallets, DateTime? fromDate, DateTime? toDate)
        {
            if (!wallets.Any())
                return;

            if (fromDate != null && toDate == null)
            {
                wallets = wallets.Where(s => s.CreatedAt >= fromDate);
            }
            else if (toDate != null && fromDate == null)
            {
                wallets = wallets.Where(s => s.CreatedAt <= toDate);
            }
            else if (fromDate != null && toDate != null)
            {
                wallets = wallets.Where(s => s.CreatedAt >= fromDate && s.CreatedAt <= toDate);
            }
        }

        /// <summary>
        /// Gets the Wallet by identifier.
        /// </summary>
        /// <param name="WalletId">The Wallet identifier.</param>
        /// <returns></returns>
        public async Task<Wallets> GetWalletById(int WalletId)
        {
            var getWalletsParams = new object[] { new MySqlParameter("@p_Value", WalletId) };

            var wallets = await FindAll("CALL SpSelectActiveWallet(@p_Value)", getWalletsParams).ToListAsync();

            return wallets.FirstOrDefault();
        }

        public async Task<List<WalletResponse>> GetWalletsById(int WalletId)
        {
            var result = await FindByCondition(wa => wa.Id.Equals(WalletId))
                  .ProjectTo<WalletResponse>(mapper.ConfigurationProvider)
                  .ToListAsync();
            return result;
        }

        /// <summary>
        /// Creates the Wallet.
        /// </summary>
        /// <param name="wallet">The Wallet.</param>
        public void CreateWallet(Wallets wallet)
        {
            Create(wallet);
        }

        /// <summary>
        /// Updates the wallet.
        /// </summary>
        /// <param name="wallet">The Wallet.</param>
        public void UpdateWallet(Wallets wallet)
        {
            Update(wallet);
        }

        /// <summary>
        /// Deletes the Wallet.
        /// </summary>
        /// <param name = "wallet" > The Wallet.</param>
        public void DeleteWallet(Wallets wallet)
        {
            Delete(wallet);
        }
    }
}

