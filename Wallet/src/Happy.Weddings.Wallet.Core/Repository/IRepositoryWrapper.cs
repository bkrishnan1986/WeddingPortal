#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | IRepositoryWrapper interface.
//----------------------------------------------------------------------------------------------

#endregion

using Happy.Weddings.Wallet.Core.Repository;
using System.Threading.Tasks;

namespace Happy.Weddings.Wallet.Core.Repository
{
    public interface IRepositoryWrapper
    {
        /// <summary>
        /// Gets the multicodes.
        /// </summary>
        IMultiCodeRepository MultiCodes { get; }

        /// <summary>
        /// Gets the multidetails.
        /// </summary>
        IMultiDetailRepository MultiDetails { get; }

        /// <summary>
        /// Gets the Wallets.
        /// </summary>
        IWalletRepository Wallets { get; }

        /// <summary>
        /// Gets the Wallet Status.
        /// </summary>
        IWalletStatusRepository WalletStatus { get; }

        /// <summary>
        /// Gets the Wallet Rules.
        /// </summary>
        IWalletRuleRepository WalletRule { get; }

        /// <summary>
        /// Gets the PaymentBook.
        /// </summary>
        IPaymentBookRepository PaymentBook { get; }

        /// <summary>
        /// Gets the Refund.
        /// </summary>
        IRefundRepository Refund { get; }

        /// <summary>
        /// Gets the Transactions.
        /// </summary>
        ITransactionsRepository Transactions { get; }

        /// <summary>
        /// Gets the Wallet Deduction.
        /// </summary>
        IWalletDeductionRepository WalletDeduction { get; }

        /// <summary>
        /// Gets the Wallet Adjustment.
        /// </summary>
        IWalletAdjustmentRepository WalletAdjustment { get; }

        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveAsync();
    }
}
