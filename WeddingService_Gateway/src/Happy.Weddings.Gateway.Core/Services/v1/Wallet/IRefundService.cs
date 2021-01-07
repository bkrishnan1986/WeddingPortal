using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Wallet.Refund;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Wallet
{
    /// <summary>
    /// Service interface for post related operations
    /// </summary>
    public interface IRefundService
    {
        /// <summary>
        /// Gets the Refund.
        /// </summary>
        /// <param name="refundParameter">The Refund parameters.</param>
        /// <returns></returns>
        Task<APIResponse> GetAllRefund(RefundParameter refundParameter);

        /// <summary>
        /// Gets the Refund.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> GetRefundDetails(RefundIdDetails details);

        /// <summary>
        /// Creates the Refund.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> CreateRefund(CreateRefundRequest request);

        /// <summary>
        /// Updates the Refund.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> UpdateRefund(RefundIdDetails details, UpdateRefundRequest request);
    }
}
