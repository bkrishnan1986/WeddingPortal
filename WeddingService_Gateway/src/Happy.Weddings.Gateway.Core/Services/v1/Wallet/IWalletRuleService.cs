using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Wallet.WalletRule;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Wallet
{
    public interface IWalletRuleService
    {
        /// <summary>
        /// Gets the WalletRule.
        /// </summary>
        /// <param name="walletRuleParameter">The WalletRule parameters.</param>
        /// <returns></returns>
        Task<APIResponse> GetAllWalletRules(WalletRuleParameter walletRuleParameter);

        /// <summary>
        /// Gets the WalletRule.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> GetWalletRuleDetails(WalletRuleIdDetails details);

        /// <summary>
        /// Creates the WalletRule.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> CreateWalletRule(CreateWalletRuleRequest request);

        /// <summary>
        /// Updates the WalletRule.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> UpdateWalletRule(WalletRuleIdDetails details, UpdateWalletRuleRequest request);

        /// <summary>
        /// Deletes the WalletRule.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> DeleteWalletRule(WalletRuleIdDetails details);

    }
}
