using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.Domain;
using Happy.Weddings.Wallet.Core.DTO.Requests.Transactions;
using Happy.Weddings.Wallet.Core.Entity;
using System.Threading.Tasks;
using Happy.Weddings.Wallet.Core.DTO.Responses.Transactions;

/// <summary>
/// This class is used to implement CRUD for the Transactions.
/// </summary>
namespace Happy.Weddings.Wallet.Core.Repository
{
    public interface ITransactionsRepository : IRepositoryBase<Transactions>
    {
        /// <summary>
        /// Gets all Transactions
        /// </summary>
        /// <param name="transactionsParameter">The Transactions parameters.</param>
        /// <returns></returns>
        //Task<List<Transactions>> GetAllTransactions(TransactionsParameter transactionsParameter);
        Task<List<TransactionsResponse>> GetAllTransactions(TransactionsParameter transactionsParameter);

        /// <summary>
        /// Gets the Transactions by identifier.
        /// </summary>
        /// <param name="Id">The Transactions identifier.</param>
        /// <returns></returns>
        Task<List<TransactionsResponse>> GetTransactionsById(int Id);

        /// <summary>
        /// Creates the Transactions
        /// </summary>
        /// <param name="transactions">The Transactions.</param>
        void CreateTransactions(Transactions transactions);

    }
}
