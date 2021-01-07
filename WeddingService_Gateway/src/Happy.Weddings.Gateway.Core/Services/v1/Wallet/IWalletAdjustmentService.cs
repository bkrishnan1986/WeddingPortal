using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Wallet.WalletAdjustment;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Wallet
{
    /// <summary>
    /// Service interface for post related operations
    /// </summary>
    public interface IWalletAdjustmentService
    {
        /// <summary>
        /// Gets the WalletAdjustment.
        /// </summary>
        /// <param name="walletAdjustmentParameter">The WalletAdjustment parameters.</param>
        /// <returns></returns>
        Task<APIResponse> GetAllWalletAdjustment(WalletAdjustmentParameter walletAdjustmentParameter);

        /// <summary>
        /// Gets the WalletAdjustment.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> GetWalletAdjustmentDetails(WalletAdjustmentIdDetails details);

        /// <summary>
        /// Creates the WalletAdjustment.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> CreateWalletAdjustment(CreateWalletAdjustmentRequest request);

        /// <summary>
        /// Updates the WalletAdjustment.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> UpdateWalletAdjustment(WalletAdjustmentIdDetails details, UpdateWalletAdjustmentRequest request);

        /// <summary>
        /// Deletes the WalletAdjustment.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> DeleteWalletAdjustment(WalletAdjustmentIdDetails details);
    }
}
