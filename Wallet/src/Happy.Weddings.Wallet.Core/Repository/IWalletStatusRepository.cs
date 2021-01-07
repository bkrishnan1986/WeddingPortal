#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | IWalletStatusRepository --Interface
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.Domain;
using Happy.Weddings.Wallet.Core.DTO.Requests.WalletStatus;
using Happy.Weddings.Wallet.Core.Entity;
using System.Threading.Tasks;
using Happy.Weddings.Wallet.Core.DTO.Responses.WalletStatus;

/// <summary>
/// This class is used to implement CRUD for the WalletStatus.
/// </summary>
namespace Happy.Weddings.Wallet.Core.Repository
{
    public interface IWalletStatusRepository : IRepositoryBase<Walletstatus>
    {
        /// <summary>
        /// Gets all Wallet Status
        /// </summary>
        /// <param name="walletsStatusParameter">The Wallet Status parameters.</param>
        /// <returns></returns>
        Task<List<WalletStatusResponse>> GetAllWalletStatus(WalletStatusParameter walletsStatusParameter);

        /// <summary>
        /// Gets the Wallet by identifier.
        /// </summary>
        /// <param name="walletStatusId">The Wallet identifier.</param>
        /// <returns></returns>
        Task<Walletstatus> GetWalletStatusById(int walletStatusId);

        /// <summary>
        /// Gets the wallets status by identifier.
        /// </summary>
        /// <param name="walletStatusId">The wallet status identifier.</param>
        /// <returns></returns>
        Task<List<WalletStatusResponse>> GetWalletsStatusById(int walletStatusId);

        /// <summary>
        /// Creates the wallet Status
        /// </summary>
        /// <param name="walletstatus">The Wallets Status.</param>
        void CreateWalletStatus(Walletstatus walletstatus);

        /// <summary>
        /// Updates the Wallet Status.
        /// </summary>
        /// <param name="walletstatus">The Wallets Status.</param>
        void UpdateWalletStatus(Walletstatus walletstatus);

        /// <summary>
        /// Deletes the Wallet Status.
        /// </summary>
        /// <param name = "walletstatus" > The Wallet Status.</param>
        void DeleteWalletStatus(Walletstatus walletstatus);
    }
}
