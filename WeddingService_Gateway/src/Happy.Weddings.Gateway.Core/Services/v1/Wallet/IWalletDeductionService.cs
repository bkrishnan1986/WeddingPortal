using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Wallet.WalletDeduction;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Wallet
{
    public interface IWalletDeductionService
    {
        /// <summary>
        /// Gets the WalletDeduction.
        /// </summary>
        /// <param name="walletDeductionParameter">The WalletDeduction parameters.</param>
        /// <returns></returns>
        Task<APIResponse> GetAllWalletDeduction(WalletDeductionParameter walletDeductionParameter);

        /// <summary>
        /// Gets the WalletDeduction.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> GetWalletDeductionDetails(WalletDeductionIdDetails details);

        /// <summary>
        /// Creates the WalletDeduction.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> CreateWalletDeduction(CreateWalletDeductionRequest request);

        /// <summary>
        /// Updates the WalletDeduction.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> UpdateWalletDeduction(WalletDeductionIdDetails details, UpdateWalletDeductionRequest request);

        /// <summary>
        /// Deletes the WalletDeduction.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> DeleteWalletDeduction(WalletDeductionIdDetails details);
    }
}
