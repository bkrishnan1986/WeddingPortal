#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS   | Created and implemented. 
//              |                         | PaymentBookRepository --class
//----------------------------------------------------------------------------------------------

#endregion

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.Wallet.Core.DTO.Requests.PaymentBook;
using Happy.Weddings.Wallet.Core.DTO.Responses.PaymentBook;
using Happy.Weddings.Wallet.Core.Entity;
using Happy.Weddings.Wallet.Core.Helpers;
using Happy.Weddings.Wallet.Core.Repository;
using Happy.Weddings.Wallet.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happy.Weddings.Wallet.Data.Repository
{
    /// <summary>
    /// PaymentBookRepository
    /// </summary>
    /// <seealso cref="Happy.Weddings.Wallet.Data.Repository.RepositoryBase{Happy.Weddings.Wallet.Core.Entity.Paymentbook}" />
    /// <seealso cref="Happy.Weddings.Wallet.Core.Repository.IPaymentBookRepository" />
    public class PaymentBookRepository : RepositoryBase<Paymentbook>, IPaymentBookRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<PaymentBookResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<PaymentBookResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentBookRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public PaymentBookRepository(
            WalletContext repositoryContext,
            IMapper mapper,
            ISortHelper<PaymentBookResponse> sortHelper,
            IDataShaper<PaymentBookResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Gets all PaymentBook.
        /// </summary>
        /// <param name="paymentBookSearchParameter">The PaymentBook Search parameters.</param>
        /// <returns></returns>
        //public async Task<List<Paymentbook>> GetAllPaymentBook(PaymentBookSearchParameter paymentBookSearchParameter)
        //{
        //    {
        //        var getPaymentBookSearchParams = new object[]
        //        {
        //            new MySqlParameter("@p_Limit", paymentBookSearchParameter.PageSize),
        //            new MySqlParameter("@p_Offset", (paymentBookSearchParameter.PageNumber - 1) * paymentBookSearchParameter.PageSize),
        //            new MySqlParameter("@p_VendorId", paymentBookSearchParameter.VendorId),
        //            new MySqlParameter("@p_PackageType", paymentBookSearchParameter.PackageType),
        //            new MySqlParameter("@p_PaymentType", paymentBookSearchParameter.PaymentType),
        //            new MySqlParameter("@p_PaymentStatus", paymentBookSearchParameter.PaymentStatus),
        //            new MySqlParameter("@p_PaymentMode", paymentBookSearchParameter.PaymentMode),
        //            new MySqlParameter("@p_VendorStatus", paymentBookSearchParameter.VendorStatus),
        //            new MySqlParameter("@p_FinanceApprovalStatus", paymentBookSearchParameter.FinanceApprovalStatus),
        //            new MySqlParameter("@p_BHStatus", paymentBookSearchParameter.BHStatus),
        //            new MySqlParameter("@p_FromDate", paymentBookSearchParameter.FromDate),
        //            new MySqlParameter("@p_ToDate", paymentBookSearchParameter.ToDate)
        //        };

        //        var paymentBook = await FindAll("CALL SpSearchPaymentBook(@p_Limit,@p_Offset,@p_VendorId,@p_PackageType,@p_PaymentType,@p_PaymentStatus,@p_PaymentMode,@p_VendorStatus,@p_FinanceApprovalStatus,@p_BHStatus,@p_FromDate,@p_ToDate)", getPaymentBookSearchParams).ToListAsync();

        //        return paymentBook;
        //    }
        //}

        public async Task<List<PaymentBookResponse>> GetAllPaymentBook(PaymentBookSearchParameter paymentBookSearchParameter)
        {
            var paymentbook = FindByCondition(x => x.Id > 0).ProjectTo<PaymentBookResponse>(mapper.ConfigurationProvider);
            SearchByWallet(ref paymentbook, paymentBookSearchParameter);
            FilterByDate(ref paymentbook, paymentBookSearchParameter.FromDate, paymentBookSearchParameter.ToDate);
            var sortedWallets = sortHelper.ApplySort(paymentbook, paymentBookSearchParameter.OrderBy);
            var pagedWallets = sortedWallets
                               .Skip((paymentBookSearchParameter.PageNumber - 1) * paymentBookSearchParameter.PageSize)
                               .Take(paymentBookSearchParameter.PageSize);
            return await pagedWallets.ToListAsync();
        }
        private void SearchByWallet(ref IQueryable<PaymentBookResponse> paymentbook, PaymentBookSearchParameter paymentBookSearchParameter)
        {
            if (paymentBookSearchParameter.VendorId > 0)
            {
                paymentbook = paymentbook.Where(x => x.VendorId.Equals(paymentBookSearchParameter.VendorId));
            }
            if (paymentBookSearchParameter.PackageType > 0)
            {
                paymentbook = paymentbook.Where(x => x.PackageType.Equals(paymentBookSearchParameter.PackageType));
            }
            if (paymentBookSearchParameter.PaymentType > 0)
            {
                paymentbook = paymentbook.Where(x => x.PaymentType.Equals(paymentBookSearchParameter.PaymentType));
            }
            if (paymentBookSearchParameter.PaymentStatus > 0)
            {
                paymentbook = paymentbook.Where(x => x.PaymentStatus.Equals(paymentBookSearchParameter.PaymentStatus));
            }
            if (paymentBookSearchParameter.PaymentMode > 0)
            {
                paymentbook = paymentbook.Where(x => x.PaymentMode.Equals(paymentBookSearchParameter.PaymentMode));
            }
            if (paymentBookSearchParameter.VendorStatus > 0)
            {
                paymentbook = paymentbook.Where(x => x.VendorStatus.Equals(paymentBookSearchParameter.VendorStatus));
            }
            if (paymentBookSearchParameter.FinanceApprovalStatus > 0)
            {
                paymentbook = paymentbook.Where(x => x.FinanceApprovalStatus.Equals(paymentBookSearchParameter.FinanceApprovalStatus));
            }
            if (paymentBookSearchParameter.BHStatus > 0)
            {
                paymentbook = paymentbook.Where(x => x.Bhstatus.Equals(paymentBookSearchParameter.BHStatus));
            }
        }
        private void FilterByDate(ref IQueryable<PaymentBookResponse> paymentbook, DateTime? fromDate, DateTime? toDate)
        {
            if (!paymentbook.Any())
                return;

            if (fromDate != null && toDate == null)
            {
                paymentbook = paymentbook.Where(s => s.PaymentDate >= fromDate);
            }
            else if (toDate != null && fromDate == null)
            {
                paymentbook = paymentbook.Where(s => s.PaymentDate <= toDate);
            }
            else if (fromDate != null && toDate != null)
            {
                paymentbook = paymentbook.Where(s => s.PaymentDate >= fromDate && s.PaymentDate <= toDate);
            }
        }

        /// <summary>
        /// Gets the PaymentBook by identifier.
        /// </summary>
        /// <param name="paymentBookId">The PaymentBook identifier.</param>
        /// <returns></returns>
        public async Task<Paymentbook> GetPaymentBookById(int Id)
        {
            var getPaymentBookParams = new object[] { new MySqlParameter("@p_Value", Id), new MySqlParameter("@p_IsForVendorId", false) };

            var paymentBook = await FindAll("CALL SpSelectActivePaymentBook(@p_Value,@p_IsForVendorId)", getPaymentBookParams).ToListAsync();

            return paymentBook.FirstOrDefault();
        }
        public async Task<List<PaymentBookResponse>> GetPaymentBooksById(int Id)
        {
            var result = await FindByCondition(wa => wa.Id.Equals(Id)).OrderBy(x => x.VendorId)
                  .ProjectTo<PaymentBookResponse>(mapper.ConfigurationProvider)
                  .ToListAsync();
            return result;
        }

        /// <summary>
        /// Creates the PaymentBook.
        /// </summary>
        /// <param name="paymentbook">The PaymentBook.</param>
        public void CreatePaymentBook(Paymentbook paymentbook)
        {
            Create(paymentbook);
        }

        /// <summary>
        /// Updates the PaymentBook.
        /// </summary>
        /// <param name="paymentbook">The PaymentBook.</param>
        public void UpdatePaymentBook(Paymentbook paymentbook)
        {
            Update(paymentbook);
        }
    }
}
