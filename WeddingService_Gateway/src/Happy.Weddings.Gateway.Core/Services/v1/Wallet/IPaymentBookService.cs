using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Wallet.PaymentBook;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Wallet
{
    /// <summary>
    /// Service interface for post related operations
    /// </summary>
    public interface IPaymentBookService
    {
        /// <summary>
        /// Gets the PaymentBook.
        /// </summary>
        /// <param name="paymentBookParameter">The PaymentBook parameters.</param>
        /// <returns></returns>
        Task<APIResponse> GetAllPaymentBook(PaymentBookParameter paymentBookParameter);

        /// <summary>
        /// Gets the PaymentBook.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> GetPaymentBookDetails(PaymentBookIdDetails details);

        /// <summary>
        /// Creates the PaymentBook.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> CreatePaymentBook(PaymentBookRequest request);

        /// <summary>
        /// Updates the PaymentBook.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> UpdatePaymentBook(PaymentBookIdDetails details, UpdatePaymentBookRequest request);
    }
}
