#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | WalletStatusRepository --class
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
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
using Happy.Weddings.Wallet.Core.DTO.Requests.WalletStatus;
using Happy.Weddings.Wallet.Core.DTO.Responses.WalletStatus;

namespace Happy.Weddings.Wallet.Data.Repository
{
    /// <summary>
    /// WalletRepository
    /// </summary>
    /// <seealso cref="Happy.Weddings.Wallet.Data.Repository.RepositoryBase{Happy.Weddings.Wallet.Core.Entity.Walletstatus}" />
    /// <seealso cref="Happy.Weddings.Wallet.Core.Repository.IWalletStatusRepository" />
    public class WalletStatusRepository : RepositoryBase<Walletstatus>, IWalletStatusRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<WalletStatusResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<WalletStatusResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="WalletStatusRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public WalletStatusRepository(
            WalletContext repositoryContext,
            IMapper mapper,
            ISortHelper<WalletStatusResponse> sortHelper,
            IDataShaper<WalletStatusResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Gets all Wallet Status.
        /// </summary>
        /// <param name="walletsStatusParameter">The Wallet Status parameters.</param>
        /// <returns></returns>
        //public async Task<List<Walletstatus>> GetAllWalletStatus(WalletStatusParameter walletsStatusParameter)
        //{
        //    {
        //        var getWalletStatusParams = new object[] { new MySqlParameter("@p_Value", walletsStatusParameter.Value), new MySqlParameter("@p_IsForWallet", walletsStatusParameter.IsForWallet) };

        //        var walletStatus = await FindAll("CALL SpSelectActiveWalletStatus(@p_Value,@p_IsForWallet)", getWalletStatusParams).ToListAsync();

        //        return walletStatus;
        //    }
        //}

        public async Task<List<WalletStatusResponse>> GetAllWalletStatus(WalletStatusParameter walletsStatusParameter)
        {
            var walletstatus = FindByCondition(x => x.Active == Convert.ToInt16(true)).OrderBy(x => x.WalletId)
                              .ProjectTo<WalletStatusResponse>(mapper.ConfigurationProvider);
            SearchWalletStatusById(ref walletstatus, walletsStatusParameter);
            var result = await walletstatus.ToListAsync();
            return result;
        }   

        private void SearchWalletStatusById(ref IQueryable<WalletStatusResponse> walletstatus, WalletStatusParameter walletsStatusParameter)
        {
            if (walletsStatusParameter.Value > 0)
            {
                if (walletsStatusParameter.IsForWallet == true)
                {
                    walletstatus = walletstatus.Where(x => x.WalletId.Equals(walletsStatusParameter.Value)).OrderBy(x => x.WalletId);
                }
                else
                {
                    walletstatus = walletstatus.Where(x => x.Id.Equals(walletsStatusParameter.Value)).OrderBy(x => x.WalletId);
                }
            }
        }

        /// <summary>
        /// Gets the Wallet Status by identifier.
        /// </summary>
        /// <param name="WalletStatusId">The Wallet Status identifier.</param>
        /// <returns></returns>
        public async Task<Walletstatus> GetWalletStatusById(int walletStatusId)
        {
            var getWalletStatusParams = new object[] { new MySqlParameter("@p_Value", walletStatusId), new MySqlParameter("@p_IsForWallet", false) };

            var walletStatus = await FindAll("CALL SpSelectActiveWalletStatus(@p_Value,@p_IsForWallet)", getWalletStatusParams).ToListAsync();

            return walletStatus.FirstOrDefault();
        }

        public async Task<List<WalletStatusResponse>> GetWalletsStatusById(int walletStatusId)
        {
            var result = await FindByCondition(wa => wa.Id.Equals(walletStatusId)).OrderBy(x => x.WalletId)
                    .ProjectTo<WalletStatusResponse>(mapper.ConfigurationProvider)
                    .ToListAsync();
            return result;
        }


        /// <summary>
        /// Creates the Wallet Status.
        /// </summary>
        /// <param name="walletstatus">The Wallet Status.</param>
        public void CreateWalletStatus(Walletstatus walletstatus)
        {
            Create(walletstatus);
        }

        /// <summary>
        /// Updates the wallet Status.
        /// </summary>
        /// <param name="walletstatus">The Wallet Status.</param>
        public void UpdateWalletStatus(Walletstatus walletstatus)
        {
            Update(walletstatus);
        }

        /// <summary>
        /// Deletes the Wallet Status.
        /// </summary>
        /// <param name = "walletstatus" > The Wallet Status.</param>
        public void DeleteWalletStatus(Walletstatus walletstatus)
        {
            Delete(walletstatus);
        }
    }
}

