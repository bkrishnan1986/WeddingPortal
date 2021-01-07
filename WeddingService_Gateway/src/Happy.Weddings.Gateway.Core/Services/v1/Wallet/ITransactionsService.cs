using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Wallet.Transactions;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Wallet
{
    /// <summary>
    /// Service interface for post related operations
    /// </summary>
    public interface ITransactionsService
    {
        /// <summary>
        /// Gets the Transactions.
        /// </summary>
        /// <param name="transactionsParameter">The Transactions parameters.</param>
        /// <returns></returns>
        Task<APIResponse> GetAllTransactions(TransactionsParameter transactionsParameter);

        /// <summary>
        /// Gets the Transactions.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> GetTransactionsDetails(TransactionsIdDetails details);
    }
}
