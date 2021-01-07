#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | WalletRuleRepository --class
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
using Happy.Weddings.Wallet.Core.DTO.Requests.WalletRule;
using Happy.Weddings.Wallet.Core.DTO.Responses.WalletRule;

namespace Happy.Weddings.Wallet.Data.Repository
{
    /// <summary>
    /// WalletRuleRepository
    /// </summary>
    /// <seealso cref="Happy.Weddings.Wallet.Data.Repository.RepositoryBase{Happy.Weddings.Wallet.Core.Entity.Walletrule}" />
    /// <seealso cref="Happy.Weddings.Wallet.Core.Repository.IWalletRuleRepository" />
    public class WalletRuleRepository : RepositoryBase<Walletrule>, IWalletRuleRepository
    {

        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<WalletRuleResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<WalletRuleResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="WalletRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public WalletRuleRepository(
            WalletContext repositoryContext,
            IMapper mapper,
            ISortHelper<WalletRuleResponse> sortHelper,
            IDataShaper<WalletRuleResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Gets all WalletRule.
        /// </summary>
        /// <param name="walletRuleParameter">The WalletRule parameters.</param>
        /// <returns></returns>
        public async Task<List<WalletRuleResponse>> GetAllWalletRule(WalletRuleParameter walletRuleParameter)
        {
            var walletrule = FindByCondition(x => x.Active == Convert.ToInt16(true)).OrderByDescending(x => x.Id)
                                .ProjectTo<WalletRuleResponse>(mapper.ConfigurationProvider);
            SearchWalletRule(ref walletrule, walletRuleParameter);
            var result = await walletrule.ToListAsync();

            return result;
        }

        /// <summary>
        /// Search WalletRule.
        /// </summary>
        /// <param name="walletrule">The walletRuleResponse Ref.</param>
        /// <param name="walletRuleParameter">The WalletRule parameters.</param>
        /// <returns></returns>
        private void SearchWalletRule(ref IQueryable<WalletRuleResponse> walletrule, WalletRuleParameter walletRuleParameter)
        {
            if (walletRuleParameter.Value > 0)
            {
                if (walletRuleParameter.IsForServiceCategory == true) walletrule = walletrule.Where(x => x.ServiceCategoryId.Equals(walletRuleParameter.Value));
                else walletrule = walletrule.Where(x => x.Id.Equals(walletRuleParameter.Value));
            }
        }

        /// <summary>
        /// Gets the Wallet Rule by identifier.
        /// </summary>
        /// <param name="walletruleId">The Wallet Rule identifier.</param>
        /// <returns></returns>
        public async Task<Walletrule> GetWalletRuleById(int walletruleId)
        {
            var getWalletsRuleParams = new object[]
            {
                new MySqlParameter("@p_Value", walletruleId),
                new MySqlParameter("@p_IsForServiceCategory", false)
            };

            var wallets = await FindAll("CALL SpSelectActiveWalletRule(@p_Value,@p_IsForServiceCategory)", getWalletsRuleParams).ToListAsync();

            return wallets.FirstOrDefault();
        }
        public async Task<WalletRuleResponse> GetWalletRulesById(int walletruleId)
        {
            var result = await FindByCondition(wr => wr.Id.Equals(walletruleId))
                 .ProjectTo<WalletRuleResponse>(mapper.ConfigurationProvider)
                 .FirstOrDefaultAsync();

            return result;
        }

        /// <summary>
        /// Creates the Wallet Rule.
        /// </summary>
        /// <param name="walletrule">The Wallet Rule.</param>
        public void CreateWalletRule(Walletrule walletrule)
        {
            Create(walletrule);
        }

        /// <summary>
        /// Updates the wallet Rule.
        /// </summary>
        /// <param name="walletrule">The Wallet Rule.</param>
        public void UpdateWalletRule(Walletrule walletrule)
        {
            Update(walletrule);
        }

        /// <summary>
        /// Deletes the Wallet Rule.
        /// </summary>
        /// <param name = "walletrule" > The Wallet Rule.</param>
        public void DeleteWalletRule(Walletrule walletrule)
        {
            Delete(walletrule);
        }

    }
}
