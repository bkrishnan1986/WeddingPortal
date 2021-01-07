#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | WalletDeductionRepository --class
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
using Happy.Weddings.Wallet.Core.DTO.Requests.WalletDeduction;
using Happy.Weddings.Wallet.Core.DTO.Responses.WalletDeduction;
using Happy.Weddings.Wallet.Core.DTO.Responses.WalletAdjustment;

namespace Happy.Weddings.Wallet.Data.Repository
{
    /// <summary>
    /// WalletDeductionRepository
    /// </summary>
    /// <seealso cref="Happy.Weddings.Wallet.Data.Repository.RepositoryBase{Happy.Weddings.Wallet.Core.Entity.Walletdeduction}" />
    /// <seealso cref="Happy.Weddings.Wallet.Core.Repository.IWalletDeductionRepository" />
    public class WalletDeductionRepository : RepositoryBase<Walletdeduction>, IWalletDeductionRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<WalletDeductionResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<WalletDeductionResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="WalletDeductionRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public WalletDeductionRepository(
            WalletContext repositoryContext,
            IMapper mapper,
            ISortHelper<WalletDeductionResponse> sortHelper,
            IDataShaper<WalletDeductionResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Gets all Wallet Deduction.
        /// </summary>
        /// <param name="walletDeductionParameter">The Wallet Deduction parameters.</param>
        /// <returns></returns>
        //public async Task<List<Walletdeduction>> GetAllWalletDeduction(WalletDeductionParameter walletDeductionParameter)
        //{
        //    {
        //        var getWalletDeductionParams = new object[]
        //        {
        //            new MySqlParameter("@p_Value", walletDeductionParameter.Value),
        //            new MySqlParameter("@p_IsForSingleDeduction", walletDeductionParameter.IsForSingleDeduction),
        //            new MySqlParameter("@p_IsForLeadId", walletDeductionParameter.IsForLeadId),
        //            new MySqlParameter("@p_IsForVendorId", walletDeductionParameter.IsForVendorId)
        //        };

        //        var walletDeduction = await FindAll("CALL SpSelectActiveWalletDeduction(@p_Value,@p_IsForSingleDeduction,@p_IsForLeadId,@p_IsForVendorId)", getWalletDeductionParams).ToListAsync();

        //        return walletDeduction;
        //    }
        //}

        public async Task<List<WalletDeductionResponse>> GetAllWalletDeduction(WalletDeductionParameter walletDeductionParameter)
        {
            var walletdeductions = FindByCondition(x => x.Active == Convert.ToInt16(true))
                                  .ProjectTo<WalletDeductionResponse>(mapper.ConfigurationProvider);
            SearchByWalletDeductionById(ref walletdeductions, walletDeductionParameter);
            var result = await walletdeductions.ToListAsync();
            return result;
        }

        private void SearchByWalletDeductionById(ref IQueryable<WalletDeductionResponse> walletdeductions, WalletDeductionParameter walletDeductionParameter)
        {
            if (walletDeductionParameter.IsForSingleDeduction == true)
            {
                walletdeductions = walletdeductions.Where(x => x.Id == walletDeductionParameter.Value);
            }

            else if (walletDeductionParameter.IsForLeadId == true)
            {
                walletdeductions = walletdeductions.Where(x => x.LeadId.Equals(walletDeductionParameter.Value));
            }
            else if (walletDeductionParameter.IsForVendorId == true)
            {
                walletdeductions = walletdeductions.Where(x => x.VendorId.Equals(walletDeductionParameter.Value));
            }                
        }

        /// <summary>
        /// Gets the Wallet Deduction by identifier.
        /// </summary>
        /// <param name="WalletDeductionId">The Wallet Deduction identifier.</param>
        /// <returns></returns>
        public async Task<Walletdeduction> GetWalletDeductionById(int WalletDeductionId)
        {
            var getWalletDeductionParams = new object[]
            {
                    new MySqlParameter("@p_Value", WalletDeductionId),
                    new MySqlParameter("@p_IsForSingleDeduction", true),
                    new MySqlParameter("@p_IsForLeadId", false),
                    new MySqlParameter("@p_IsForVendorId", false)
            };

            var walletDeduction = await FindAll("CALL SpSelectActiveWalletDeduction(@p_Value,@p_IsForSingleDeduction,@p_IsForLeadId,@p_IsForVendorId)", getWalletDeductionParams).ToListAsync();

            return walletDeduction.FirstOrDefault();
        }

        public async Task<List<WalletDeductionResponse>> GetWalletDeductionsById(int WalletDeductionId)
        {
            var result = await FindByCondition(wa => wa.Id.Equals(WalletDeductionId))
                   .ProjectTo<WalletDeductionResponse>(mapper.ConfigurationProvider)
                   .ToListAsync();
            return result;
        }
        /// <summary>
        /// Creates the Wallet Deduction.
        /// </summary>
        /// <param name="walletdeduction">The Wallet Deduction.</param>
        public void CreateWalletDeduction(Walletdeduction walletdeduction)
        {
            Create(walletdeduction);
        }

        /// <summary>
        /// Updates the wallet Deduction.
        /// </summary>
        /// <param name="walletdeduction">The Wallet Deduction.</param>
        public void UpdateWalletDeduction(Walletdeduction walletdeduction)
        {
            Update(walletdeduction);
        }

        /// <summary>
        /// Deletes the Wallet Deduction.
        /// </summary>
        /// <param name = "walletdeduction" > The Wallet Deduction.</param>
        public void DeleteWalletDeduction(Walletdeduction walletdeduction)
        {
            Delete(walletdeduction);
        }
    }
}
