#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | IWalletDeductionRepository --Interface
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.Domain;
using Happy.Weddings.Wallet.Core.DTO.Requests.WalletDeduction;
using Happy.Weddings.Wallet.Core.Entity;
using System.Threading.Tasks;
using Happy.Weddings.Wallet.Core.DTO.Responses.WalletDeduction;

/// <summary>
/// This class is used to implement CRUD for the Wallet Deduction.
/// </summary>
namespace Happy.Weddings.Wallet.Core.Repository
{
    public interface IWalletDeductionRepository : IRepositoryBase<Walletdeduction>
    {
        /// <summary>
        /// Gets all Wallet Deduction
        /// </summary>
        /// <param name="walletDeductionParameter">The Wallet Deduction parameters.</param>
        /// <returns></returns>
        Task<List<WalletDeductionResponse>> GetAllWalletDeduction(WalletDeductionParameter walletDeductionParameter);

        /// <summary>
        /// Gets the Wallet Deduction by identifier.
        /// </summary>
        /// <param name="walletDeductionId">The Wallet Deduction identifier.</param>
        /// <returns></returns>
        Task<Walletdeduction> GetWalletDeductionById(int walletDeductionId);

        /// <summary>
        /// Gets the wallet deductions by identifier.
        /// </summary>
        /// <param name="WalletDeductionId">The wallet deduction identifier.</param>
        /// <returns></returns>
        Task<List<WalletDeductionResponse>> GetWalletDeductionsById(int WalletDeductionId);

        /// <summary>
        /// Creates the wallet Deduction
        /// </summary>
        /// <param name="walletdeduction">The Wallet Deduction.</param>
        void CreateWalletDeduction(Walletdeduction walletdeduction);

        /// <summary>
        /// Updates the Wallet Deduction.
        /// </summary>
        /// <param name="walletdeduction">The Wallet Deduction.</param>
        void UpdateWalletDeduction(Walletdeduction walletdeduction);

        /// <summary>
        /// Deletes the Wallet Deduction.
        /// </summary>
        /// <param name = "walletdeduction" > The Wallet Deduction.</param>
        void DeleteWalletDeduction(Walletdeduction walletdeduction);
    }
}
