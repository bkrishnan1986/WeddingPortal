#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | IWalletAdjustmentRepository --Interface
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.Domain;
using Happy.Weddings.Wallet.Core.DTO.Requests.WalletAdjustment;
using Happy.Weddings.Wallet.Core.Entity;
using System.Threading.Tasks;
using Happy.Weddings.Wallet.Core.DTO.Responses.WalletAdjustment;

namespace Happy.Weddings.Wallet.Core.Repository
{
    /// <summary>
    /// This class is used to implement CRUD for the Wallet Adjustment.
    /// </summary>
    public interface IWalletAdjustmentRepository : IRepositoryBase<Walletadjustment>
    {
        /// <summary>
        /// Gets all Wallet Adjustment
        /// </summary>
        /// <param name="walletAdjustmentParameter">The Wallet Adjustment parameters.</param>
        /// <returns></returns>
        Task<List<WalletAdjustmentResponse>> GetAllWalletAdjustment(WalletAdjustmentParameter walletAdjustmentParameter);

        /// <summary>
        /// Gets the Wallet Adjustment by identifier.
        /// </summary>
        /// <param name="walletadjustmentId">The Wallet Adjustment identifier.</param>
        /// <returns></returns>
        Task<Walletadjustment> GetWalletAdjustmentById(int walletadjustmentId);

        /// <summary>
        /// Gets the wallet adjustments by identifier.
        /// </summary>
        /// <param name="walletadjustmentId">The walletadjustment identifier.</param>
        /// <returns></returns>
        Task<List<WalletAdjustmentResponse>> GetWalletAdjustmentsById(int walletadjustmentId);

        /// <summary>
        /// Creates the wallet Adjustment
        /// </summary>
        /// <param name="walletadjustment">The Wallets Adjustment.</param>
        void CreateWalletAdjustment(Walletadjustment walletadjustment);

        /// <summary>
        /// Updates the Wallet Adjustment.
        /// </summary>
        /// <param name="walletadjustment">The Wallets Adjustment.</param>
        void UpdateWalletAdjustment(Walletadjustment walletadjustment);

        /// <summary>
        /// Deletes the Wallet Adjustment.
        /// </summary>
        /// <param name = "walletadjustment" > The Wallet Adjustment.</param>
        void DeleteWalletAdjustment(Walletadjustment walletadjustment);
    }
}
