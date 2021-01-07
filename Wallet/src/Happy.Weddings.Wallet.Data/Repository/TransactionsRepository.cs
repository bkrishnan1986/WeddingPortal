using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.Wallet.Core.Domain;
using Happy.Weddings.Wallet.Core.Entity;
using Happy.Weddings.Wallet.Core.Helpers;
using Happy.Weddings.Wallet.Core.Repository;
using Happy.Weddings.Wallet.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Happy.Weddings.Wallet.Core.DTO.Requests.Transactions;
using Happy.Weddings.Wallet.Core.DTO.Responses.Transactions;

namespace Happy.Weddings.Wallet.Data.Repository
{
    /// <summary>
    /// TransactionsRepository
    /// </summary>
    /// <seealso cref="Happy.Weddings.Wallet.Data.Repository.RepositoryBase{Happy.Weddings.Wallet.Core.Entity.Transactions}" />
    /// <seealso cref="Happy.Weddings.Wallet.Core.Repository.ITransactionsRepository" />
    public class TransactionsRepository : RepositoryBase<Transactions>, ITransactionsRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<TransactionsResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<TransactionsResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionsRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public TransactionsRepository(
            WalletContext repositoryContext,
            IMapper mapper,
            ISortHelper<TransactionsResponse> sortHelper,
            IDataShaper<TransactionsResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Gets all Transactions.
        /// </summary>
        /// <param name="transactionsParameter">The Transactions parameters.</param>
        /// <returns></returns>
        //public async Task<List<Transactions>> GetAllTransactions(TransactionsParameter transactionsParameter)
        //{
        //    {
        //        if (transactionsParameter.IsForVendor)
        //        {
        //            var getTransactionsParams = new object[] { new MySqlParameter("@p_VendorId", transactionsParameter.Value) };

        //            var transactions = await FindAll("CALL SpSelectActiveTransactionsByVendor(@p_VendorId)", getTransactionsParams).ToListAsync();

        //            return transactions;
        //        }
        //        else
        //        {
        //            DateTime? dt;

        //            if (transactionsParameter.TransactionDate == DateTime.MinValue) dt = null; else dt = transactionsParameter.TransactionDate;

        //            var getTransactionsParams = new object[]
        //            {
        //            new MySqlParameter("@p_Value", transactionsParameter.Value),
        //            new MySqlParameter("@p_IsForWallet", transactionsParameter.IsForWallet),
        //            new MySqlParameter("@p_ReferenceNo", transactionsParameter.ReferenceNo),
        //            new MySqlParameter("@p_TransactionType", transactionsParameter.TransactionType),
        //            new MySqlParameter("@p_TransactionDate", dt )
        //            };

        //            var transactions = await FindAll("CALL SpSelectActiveTransactions(@p_Value,@p_IsForWallet,@p_ReferenceNo,@p_TransactionType,@p_TransactionDate)", getTransactionsParams).ToListAsync();

        //            return transactions;
        //        }
        //    }
        //}
        public async Task<List<TransactionsResponse>> GetAllTransactions(TransactionsParameter transactionsParameter)
        {
            {
                var TransactionResult = FindByCondition(ta => ta.Id > 0).OrderByDescending(ta => ta.Id).ProjectTo<TransactionsResponse>(mapper.ConfigurationProvider);
                SearchTransactions(ref TransactionResult, transactionsParameter);
                var result = await TransactionResult.ToListAsync();

                return result;
            }
        }

        private void SearchTransactions(ref IQueryable<TransactionsResponse> transactions, TransactionsParameter transactionsParameter)
        {
            if (transactionsParameter.Value > 0)
            {
                if (transactionsParameter.IsForWallet || transactionsParameter.IsForVendor) transactions = transactions.Where(x => x.WalletId.Equals(transactionsParameter.Value));
                else transactions = transactions.Where(x => x.Id.Equals(transactionsParameter.Value));
            }

            if (transactionsParameter.ReferenceNo != null && transactionsParameter.ReferenceNo != string.Empty) transactions = transactions.Where(x => x.ReferenceNo.Equals(transactionsParameter.ReferenceNo));
            if (transactionsParameter.TransactionType > 0) transactions = transactions.Where(x => x.TransactionType.Equals(transactionsParameter.TransactionType));
            if (transactionsParameter.TransactionDate != null && transactionsParameter.TransactionDate != DateTime.MinValue) transactions.Where(x => x.TransactionDate.Equals(transactionsParameter.TransactionDate));

        }

        /// <summary>
        /// Gets the Transactions by identifier.
        /// </summary>
        /// <param name="Id">The Transactions identifier.</param>
        /// <returns></returns>
        //public async Task<Transactions> GetTransactionsById(int Id)
        //{
        //    var getTransactionsParams = new object[]
        //       {
        //            new MySqlParameter("@p_Value", Id),
        //            new MySqlParameter("@p_IsForWallet", false),
        //            new MySqlParameter("@p_ReferenceNo", string.Empty),
        //            new MySqlParameter("@p_TransactionType", 0),
        //            new MySqlParameter("@p_TransactionDate", null)
        //       };

        //    var transactions = await FindAll("CALL SpSelectActiveTransactions(@p_Value,@p_IsForWallet,@p_ReferenceNo,@p_TransactionType,@p_TransactionDate)", getTransactionsParams).ToListAsync();

        //    return transactions.FirstOrDefault();
        //}
        public async Task<List<TransactionsResponse>> GetTransactionsById(int Id)
        {
            var result = await FindByCondition(ta => ta.Id.Equals(Id) && ta.Id > 0).OrderByDescending(ta => ta.Id)
                  .ProjectTo<TransactionsResponse>(mapper.ConfigurationProvider)
                  .ToListAsync();
            return result;
        }

        /// <summary>
        /// Creates the Transactions.
        /// </summary>
        /// <param name="transactions">The Transactions.</param>
        public void CreateTransactions(Transactions transactions)
        {
            Create(transactions);
        }

    }
}
