using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Wallet.Wallet;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Wallet
{
    /// <summary>
    /// Service interface for post related operations
    /// </summary>
    public interface IWalletService
    {
        /// <summary>
        /// Gets the Wallet.
        /// </summary>
        /// <param name="walletParameter">The Wallet parameters.</param>
        /// <returns></returns>
        Task<APIResponse> GetAllWallets(WalletParameter walletParameter);

        /// <summary>
        /// Gets the Wallet.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> GetWalletDetails(WalletIdDetails details);

        /// <summary>
        /// Creates the Wallet.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> CreateWallet(CreateWalletRequest request);

        /// <summary>
        /// Updates the Wallet.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> UpdateWallet(WalletIdDetails details, UpdateWalletRequest request);

        /// <summary>
        /// Deletes the Wallet.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> DeleteWallet(WalletIdDetails details);
    }
}
