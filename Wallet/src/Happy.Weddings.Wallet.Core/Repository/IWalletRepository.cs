#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | IWalletRepository --Interface
//----------------------------------------------------------------------------------------------

#endregion

using Happy.Weddings.Wallet.Core.Domain;
using Happy.Weddings.Wallet.Core.DTO.Requests.Wallet;
using Happy.Weddings.Wallet.Core.DTO.Responses.Wallet;
using Happy.Weddings.Wallet.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// This class is used to implement CRUD for the Wallet.
/// </summary>
namespace Happy.Weddings.Wallet.Core.Repository
{
    public interface IWalletRepository : IRepositoryBase<Wallets>
    {
        /// <summary>
        /// Gets all Wallet
        /// </summary>
        /// <param name="walletsParameter">The Wallet parameters.</param>
        /// <returns></returns>
        Task<List<Wallets>> GetAllWallets(WalletsParameter walletsParameter);

        /// <summary>
        /// Gets all wallets.
        /// </summary>
        /// <param name="walletsParameter">The wallets parameter.</param>
        /// <returns></returns>
        Task<List<WalletResponse>> GetAllWallet(WalletsParameter walletsParameter);

        /// <summary>
        /// Gets the Wallet  by identifier.
        /// </summary>
        /// <param name="walletId">The Wallet identifier.</param>
        /// <returns></returns>
        Task<Wallets> GetWalletById(int walletId);

        /// <summary>
        /// Gets the wallets by identifier.
        /// </summary>
        /// <param name="WalletId">The wallet identifier.</param>
        /// <returns></returns>
        Task<List<WalletResponse>> GetWalletsById(int WalletId);

        /// <summary>
        /// Creates the wallet
        /// </summary>
        /// <param name="wallet">The Wallets.</param>
        void CreateWallet(Wallets wallet);

        /// <summary>
        /// Updates the Wallet.
        /// </summary>
        /// <param name="wallet">The Wallets.</param>
        void UpdateWallet(Wallets wallet);

        /// <summary>
        /// Deletes the Wallet.
        /// </summary>
        /// <param name = "wallet" > The Wallet.</param>
        void DeleteWallet(Wallets wallet);
    }
}
