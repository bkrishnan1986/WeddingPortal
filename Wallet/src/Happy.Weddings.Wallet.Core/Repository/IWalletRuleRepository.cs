#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-ESP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | IWalletRuleRepository --Interface
//----------------------------------------------------------------------------------------------

#endregion

using Happy.Weddings.Wallet.Core.Domain;
using Happy.Weddings.Wallet.Core.DTO.Requests.WalletRule;
using Happy.Weddings.Wallet.Core.DTO.Responses.WalletRule;
using Happy.Weddings.Wallet.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// This class is used to implement CRUD for the Wallet Rule.
/// </summary>
namespace Happy.Weddings.Wallet.Core.Repository
{
    public interface IWalletRuleRepository : IRepositoryBase<Walletrule>
    {
        /// <summary>
        /// Gets all WalletRule
        /// </summary>
        /// <param name="walletRuleParameter">The WalletRule parameters.</param>
        /// <returns></returns>
        Task<List<WalletRuleResponse>> GetAllWalletRule(WalletRuleParameter walletRuleParameter);

        /// <summary>
        /// Gets the Wallet Rule  by identifier.
        /// </summary>
        /// <param name="walletruleId">The Wallet Rule identifier.</param>
        /// <returns></returns>
        Task<Walletrule> GetWalletRuleById(int walletruleId);

        /// <summary>
        /// Gets the wallet rules by identifier.
        /// </summary>
        /// <param name="walletruleId">The walletrule identifier.</param>
        /// <returns></returns>
        Task<WalletRuleResponse> GetWalletRulesById(int walletruleId);

        /// <summary>
        /// Creates the Wallet Rule
        /// </summary>
        /// <param name="walletrule">The Wallet Rule.</param>
        void CreateWalletRule(Walletrule walletrule);

        /// <summary>
        /// Updates the Wallet Rule.
        /// </summary>
        /// <param name="walletrule">The Wallet Rule.</param>
        void UpdateWalletRule(Walletrule walletrule);

        /// <summary>
        /// Deletes the Wallet Rule.
        /// </summary>
        /// <param name = "walletrule" > The Wallet Rule.</param>
        void DeleteWalletRule(Walletrule walletrule);
    }
}
