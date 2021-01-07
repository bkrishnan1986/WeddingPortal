#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS   | Created and implemented. 
//              |                         | WalletAdjustmentRepository --class
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
using Happy.Weddings.Wallet.Core.DTO.Requests.WalletAdjustment;
using Happy.Weddings.Wallet.Core.DTO.Responses.WalletAdjustment;

namespace Happy.Weddings.Wallet.Data.Repository
{
    /// <summary>
    /// WalletAdjustmentRepository
    /// </summary>
    /// <seealso cref="Happy.Weddings.Wallet.Data.Repository.RepositoryBase{Happy.Weddings.Wallet.Core.Entity.Walletadjustment}" />
    /// <seealso cref="Happy.Weddings.Wallet.Core.Repository.IWalletAdjustmentRepository" />
    public class WalletAdjustmentRepository : RepositoryBase<Walletadjustment>, IWalletAdjustmentRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<WalletAdjustmentResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<WalletAdjustmentResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="WalletAdjustmentRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public WalletAdjustmentRepository(
            WalletContext repositoryContext,
            IMapper mapper,
            ISortHelper<WalletAdjustmentResponse> sortHelper,
            IDataShaper<WalletAdjustmentResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Gets all Wallet Adjustment.
        /// </summary>
        /// <param name="walletAdjustmentParameter">The Wallet Adjustment parameters.</param>
        /// <returns></returns>
        //public async Task<List<Walletadjustment>> GetAllWalletAdjustment(WalletAdjustmentParameter walletAdjustmentParameter)
        //{
        //    {
        //        var getWalletAdjustmentParams = new object[]
        //        {
        //            new MySqlParameter("@p_Value", walletAdjustmentParameter.Value),
        //            new MySqlParameter("@p_AdjustmentType", walletAdjustmentParameter.AdjustmentType),
        //            new MySqlParameter("@p_IsForVendor", walletAdjustmentParameter.IsForVendor)
        //        };

        //        var walletAdjustment = await FindAll("CALL SpSelectActiveWalletAdjustment(@p_Value,@p_AdjustmentType,@p_IsForVendor)", getWalletAdjustmentParams).ToListAsync();

        //        return walletAdjustment;
        //    }
        //}

        public async Task<List<WalletAdjustmentResponse>> GetAllWalletAdjustment(WalletAdjustmentParameter walletAdjustmentParameter)
        {
            var walletadjustments = FindByCondition(x => x.Active == Convert.ToInt16(true)).OrderBy(x => x.VendorId)
                                    .ProjectTo<WalletAdjustmentResponse>(mapper.ConfigurationProvider);
            SearchByAdjustmentTypeOrVendorId(ref walletadjustments, walletAdjustmentParameter);
            var result = await walletadjustments.ToListAsync();
            return result;
        }

        private void SearchByAdjustmentTypeOrVendorId(ref IQueryable<WalletAdjustmentResponse> walletadjustments, WalletAdjustmentParameter walletAdjustmentParameter)
        {
            if (walletAdjustmentParameter.AdjustmentType > 0)
            {
                walletadjustments = walletadjustments.Where(x => x.AdjustmentType == walletAdjustmentParameter.AdjustmentType).OrderBy(x => x.VendorId);
            }

            if (walletAdjustmentParameter.Value > 0)
            {
                if (walletAdjustmentParameter.IsForVendor == true)
                {
                    walletadjustments = walletadjustments.Where(x => x.VendorId.Equals(walletAdjustmentParameter.Value)).OrderBy(x => x.VendorId);
                }
                else
                {
                    walletadjustments = walletadjustments.Where(x => x.Id.Equals(walletAdjustmentParameter.Value)).OrderBy(x => x.VendorId);
                }
            }
        }

        /// <summary>
        /// Gets the Wallet Adjustment by identifier.
        /// </summary>
        /// <param name="walletadjustmentId">The Wallet Adjustment identifier.</param>
        /// <returns></returns>
        public async Task<Walletadjustment> GetWalletAdjustmentById(int walletadjustmentId)
        {
            var getWalletAdjustmentParams = new object[]
            {
                 new MySqlParameter("@p_Value", walletadjustmentId),
                 new MySqlParameter("@p_AdjustmentType", 0),
                 new MySqlParameter("@p_IsForVendor", false)
            };

            var walletAdjustment = await FindAll("CALL SpSelectActiveWalletAdjustment(@p_Value,@p_AdjustmentType,@p_IsForVendor)", getWalletAdjustmentParams).ToListAsync();

            return walletAdjustment.FirstOrDefault();
        }

        public async Task<List<WalletAdjustmentResponse>> GetWalletAdjustmentsById(int walletadjustmentId)
        {
            var result = await FindByCondition(wa => wa.Id.Equals(walletadjustmentId)).OrderBy(x => x.VendorId)
                   .ProjectTo<WalletAdjustmentResponse>(mapper.ConfigurationProvider)
                   .ToListAsync();
            return result;
        }


        /// <summary>
        /// Creates the Wallet Adjustment.
        /// </summary>
        /// <param name="walletadjustment">The Wallet Adjustment.</param>
        public void CreateWalletAdjustment(Walletadjustment walletadjustment)
        {
            Create(walletadjustment);
        }

        /// <summary>
        /// Updates the wallet Adjustment.
        /// </summary>
        /// <param name="walletadjustment">The Wallet Adjustment.</param>
        public void UpdateWalletAdjustment(Walletadjustment walletadjustment)
        {
            Update(walletadjustment);
        }

        /// <summary>
        /// Deletes the Wallet Adjustment.
        /// </summary>
        /// <param name = "walletadjustment" > The Wallet Adjustment.</param>
        public void DeleteWalletAdjustment(Walletadjustment walletadjustment)
        {
            Delete(walletadjustment);
        }
    }
}
