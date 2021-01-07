using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Wallet.WalletStatus;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Wallet
{
    /// <summary>
    /// Service interface for post related operations
    /// </summary>
    public interface IWalletStatusService
    {
        /// <summary>
        /// Gets the Wallet Status.
        /// </summary>
        /// <param name="walletStatusParameter">The WalletStatus parameters.</param>
        /// <returns></returns>
        Task<APIResponse> GetAllWalletStatus(WalletStatusParameter walletStatusParameter);

        /// <summary>
        /// Gets the Wallet Status.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> GetWalletStatusDetails(WalletStatusIdDetails details);

        /// <summary>
        /// Creates the Wallet Status.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> CreateWalletStatus(bool isPaused, bool isReleased, bool isChurned, CreateWalletStatusRequest request);

        /// <summary>
        /// Updates the Wallet Status.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> UpdateWalletStatus(WalletStatusIdDetails details, UpdateWalletStatusRequest request);

        /// <summary>
        /// Deletes the Wallet Status.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> DeleteWalletStatus(WalletStatusIdDetails details);
    }
}
