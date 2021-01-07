#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | IPaymentBookRepository --Interface
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.Domain;
using Happy.Weddings.Wallet.Core.DTO.Requests.PaymentBook;
using Happy.Weddings.Wallet.Core.Entity;
using System.Threading.Tasks;
using Happy.Weddings.Wallet.Core.DTO.Responses.PaymentBook;

namespace Happy.Weddings.Wallet.Core.Repository
{
    /// <summary>
    /// This class is used to implement CRUD for the PaymentBook.
    /// </summary>
    public interface IPaymentBookRepository : IRepositoryBase<Paymentbook>
    {
        /// <summary>
        /// Gets all PaymentBook
        /// </summary>
        /// <param name="paymentBookParameter">The PaymentBook parameters.</param>
        /// <returns></returns>
        Task<List<PaymentBookResponse>> GetAllPaymentBook(PaymentBookSearchParameter paymentBookSearchParameter);

        /// <summary>
        /// Gets the PaymentBook by identifier.
        /// </summary>
        /// <param name="Id">The PaymentBook identifier.</param>
        /// <returns></returns>
        Task<Paymentbook> GetPaymentBookById(int Id);

        /// <summary>
        /// Gets the payment books by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        Task<List<PaymentBookResponse>> GetPaymentBooksById(int Id);

        /// <summary>
        /// Creates the PaymentBook
        /// </summary>
        /// <param name="paymentbook">The PaymentBook.</param>
        void CreatePaymentBook(Paymentbook paymentbook);

        /// <summary>
        /// Updates the PaymentBook.
        /// </summary>
        /// <param name="paymentbook">The PaymentBook.</param>
        void UpdatePaymentBook(Paymentbook paymentbook);

    }
}
