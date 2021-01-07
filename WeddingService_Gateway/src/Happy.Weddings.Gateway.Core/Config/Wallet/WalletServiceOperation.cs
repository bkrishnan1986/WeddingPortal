using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.Config.Wallet
{
    public class WalletServiceOperation
    {
        #region Base

        /// <summary>
        /// The base URL
        /// </summary>
        const string baseUrl = "/api/v1/wallet";

        /// <summary>
        /// The service name
        /// </summary>
        public static string serviceName = "WalletService";

        /// <summary>
        /// The get Wallet cache name
        /// </summary>
        public static string GetWalletCacheName = "GetWalletCache()";

        /// <summary>
        /// Gets the health.
        /// </summary>
        /// <returns></returns>
        public static string GetHealth() => $"/hc";

        #endregion

        #region MultiCode

        /// <summary>
        /// Gets the Multicode.
        /// </summary>
        /// <returns></returns>
        public static string GetAllMultiCodes() => $"{baseUrl}/multicodes";

        /// <summary>
        /// Gets the Multicode.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public static string GetMultiCode(string code) => $"{baseUrl}/multicodes/{code}";

        /// <summary>
        /// Creates the Multicode.
        /// </summary>
        /// <returns></returns>
        public static string CreateMultiCode() => $"{baseUrl}/multicodes";

        /// <summary>
        /// Updates the Multicode.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public static string UpdateMultiCode(string code) => $"{baseUrl}/multicodes/{code}";

        /// <summary>
        /// Deletes the Multicode.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public static string DeleteMultiCode(string code) => $"{baseUrl}/multicodes/{code}";

        #endregion

        #region MultiDetail

        /// <summary>
        /// Gets the Multidetail.
        /// </summary>
        /// <returns></returns>
        public static string GetAllMultiDetails() => $"{baseUrl}/multidetails";

        /// <summary>
        /// Gets the Multidetail.
        /// </summary>
        /// <param name="multicodeId">The code.</param>
        /// <returns></returns>
        public static string GetMultiDetailsByCode(string code) => $"{baseUrl}/multidetails/{code}";

        /// <summary>
        /// Creates the Multidetail.
        /// </summary>
        /// <returns></returns>
        public static string CreateMultiDetails() => $"{baseUrl}/multidetails";

        /// <summary>
        /// Updates the Multidetail.
        /// </summary>
        /// <param name="multidetailId">The Multidetail identifier.</param>
        /// <returns></returns>
        public static string UpdateMultiDetails(int multidetailId) => $"{baseUrl}/multidetails/{multidetailId}";

        /// <summary>
        /// Deletes the Multidetail.
        /// </summary>
        /// <param name="multidetailId">The Multidetail identifier.</param>
        /// <returns></returns>
        public static string DeleteMultiDetails(int multidetailId) => $"{baseUrl}/multidetails/{multidetailId}";

        #endregion

        #region Wallet

        /// <summary>
        /// Gets the Wallet.
        /// </summary>
        /// <returns></returns>
        public static string GetAllWallets() => $"{baseUrl}/wallets";

        /// <summary>
        /// Gets the Wallet.
        /// </summary>
        /// <param name="walletId">The Wallet identifier.</param>
        /// <returns></returns>
        public static string GetWalletDetails(int walletId) => $"{baseUrl}/wallets/{walletId}";

        /// <summary>
        /// Creates the Wallet.
        /// </summary>
        /// <returns></returns>
        public static string CreateWallet() => $"{baseUrl}/wallets";

        /// <summary>
        /// Updates the Wallet.
        /// </summary>
        /// <param name="walletId">The Wallet identifier.</param>
        /// <param name="IsPaused">IsPaused Status.</param>
        /// <param name="IsReleased">IsReleased Status.</param>
        /// <param name="IsChurned">IsChurned Status.</param>
        /// <returns></returns>
        public static string UpdateWallet(int walletId, bool IsPaused, bool IsReleased, bool IsChurned) => $"{baseUrl}/wallets/{walletId}/{IsPaused}/{IsReleased}/{IsChurned}";

        /// <summary>
        /// Deletes the Wallet.
        /// </summary>
        /// <param name="walletId">The Wallet identifier.</param>
        /// <returns></returns>
        public static string DeleteWallet(int walletId) => $"{baseUrl}/wallets/{walletId}";

        #endregion

        #region WalletStatus

        /// <summary>
        /// Gets the WalletStatus.
        /// </summary>
        /// <returns></returns>
        public static string GetAllWalletStatus() => $"{baseUrl}/walletStatus";

        /// <summary>
        /// Gets the WalletStatus.
        /// </summary>
        /// <param name="walletStatusId">The WalletStatus identifier.</param>
        /// <returns></returns>
        public static string GetWalletStatusDetails(int walletStatusId) => $"{baseUrl}/walletStatus/{walletStatusId}";

        /// <summary>
        /// Creates the WalletStatus.
        /// </summary>
        /// <param name="IsPaused">IsPaused Status.</param>
        /// <param name="IsReleased">IsReleased Status.</param>
        /// <param name="IsChurned">IsChurned Status.</param>
        /// <returns></returns>
        public static string CreateWalletStatus(bool IsPaused, bool IsReleased, bool IsChurned) => $"{baseUrl}/walletStatus/{IsPaused}/{IsReleased}/{IsChurned}";

        /// <summary>
        /// Updates the WalletStatus.
        /// </summary>
        /// <param name="walletStatusId">The WalletStatus identifier.</param>
        /// <returns></returns>
        public static string UpdateWalletStatus(int walletStatusId) => $"{baseUrl}/walletStatus/{walletStatusId}";

        /// <summary>
        /// Deletes the WalletStatus.
        /// </summary>
        /// <param name="walletStatusId">The WalletStatus identifier.</param>
        /// <returns></returns>
        public static string DeleteWalletStatus(int walletStatusId) => $"{baseUrl}/walletStatus/{walletStatusId}";

        #endregion

        #region WalletRule

        /// <summary>
        /// Gets the WalletRule.
        /// </summary>
        /// <returns></returns>
        public static string GetAllWalletRules() => $"{baseUrl}/walletRule";

        /// <summary>
        /// Gets the WalletRule.
        /// </summary>
        /// <param name="walletRuleId">The WalletRule identifier.</param>
        /// <returns></returns>
        public static string GetWalletRuleDetails(int walletRuleId) => $"{baseUrl}/walletRule/{walletRuleId}";

        /// <summary>
        /// Creates the WalletRule.
        /// </summary>
        /// <returns></returns>
        public static string CreateWalletRule() => $"{baseUrl}/walletRule";

        /// <summary>
        /// Updates the WalletRule.
        /// </summary>
        /// <param name="walletRuleId">The WalletRule identifier.</param>
        /// <returns></returns>
        public static string UpdateWalletRule(int walletRuleId) => $"{baseUrl}/walletRule/{walletRuleId}";

        /// <summary>
        /// Deletes the WalletRule.
        /// </summary>
        /// <param name="walletRuleId">The WalletRule identifier.</param>
        /// <returns></returns>
        public static string DeleteWalletRule(int walletRuleId) => $"{baseUrl}/walletRule/{walletRuleId}";

        #endregion

        #region PaymentBook

        /// <summary>
        /// Gets the PaymentBook.
        /// </summary>
        /// <returns></returns>
        public static string GetAllPaymentBook() => $"{baseUrl}/paymentBook";

        /// <summary>
        /// Gets the PaymentBook.
        /// </summary>
        /// <param name="paymentBookId">The PaymentBook identifier.</param>
        /// <returns></returns>
        public static string GetPaymentBookDetails(int paymentBookId) => $"{baseUrl}/paymentBook/{paymentBookId}";

        /// <summary>
        /// Creates the PaymentBook.
        /// </summary>
        /// <returns></returns>
        public static string CreatePaymentBook() => $"{baseUrl}/paymentBook";

        /// <summary>
        /// Updates the PaymentBook.
        /// </summary>
        /// <param name="paymentBookId">The PaymentBook identifier.</param>
        /// <returns></returns>
        public static string UpdatePaymentBook(int paymentBookId) => $"{baseUrl}/paymentBook/{paymentBookId}";

        #endregion

        #region Refund

        /// <summary>
        /// Gets the Refund.
        /// </summary>
        /// <returns></returns>
        public static string GetAllRefund() => $"{baseUrl}/refund";

        /// <summary>
        /// Gets the Refund.
        /// </summary>
        /// <param name="refundId">The Refund identifier.</param>
        /// <returns></returns>
        public static string GetRefundDetails(int refundId) => $"{baseUrl}/refund/{refundId}";

        /// <summary>
        /// Creates the Refund.
        /// </summary>
        /// <returns></returns>
        public static string CreateRefund() => $"{baseUrl}/refund";

        /// <summary>
        /// Updates the Refund.
        /// </summary>
        /// <param name="refundId">The Refund identifier.</param>
        /// <param name="IsApproved">IsApproved status.</param>
        /// <param name="IsApproved">IsRejected status.</param>
        /// <returns></returns>
        public static string UpdateRefund(int refundId, bool IsApproved, bool IsRejected) => $"{baseUrl}/refund/{refundId}/{IsApproved}/{IsRejected}";

        #endregion

        #region Transactions

        /// <summary>
        /// Gets the Transactions.
        /// </summary>
        /// <returns></returns>
        public static string GetAllTransactions() => $"{baseUrl}/transactions";

        /// <summary>
        /// Gets the Transactions.
        /// </summary>
        /// <param name="transactionsId">The Transactions identifier.</param>
        /// <returns></returns>
        public static string GetTransactionsById(int transactionsId) => $"{baseUrl}/transactions/{transactionsId}";

        #endregion

        #region WalletDeduction

        /// <summary>
        /// Gets the WalletDeduction.
        /// </summary>
        /// <returns></returns>
        public static string GetAllWalletDeduction() => $"{baseUrl}/walletDeduction";

        /// <summary>
        /// Gets the WalletDeduction.
        /// </summary>
        /// <param name="walletDeductionId">The WalletDeduction identifier.</param>
        /// <returns></returns>
        public static string GetWalletDeductionDetails(int walletDeductionId) => $"{baseUrl}/walletDeduction/{walletDeductionId}";

        /// <summary>
        /// Creates the WalletDeduction.
        /// </summary>
        /// <returns></returns>
        public static string CreateWalletDeduction() => $"{baseUrl}/walletDeduction";

        /// <summary>
        /// Updates the WalletDeduction.
        /// </summary>
        /// <param name="walletDeductionId">The WalletDeduction identifier.</param>
        /// <returns></returns>
        public static string UpdateWalletDeduction(int walletDeductionId) => $"{baseUrl}/walletDeduction/{walletDeductionId}";

        /// <summary>
        /// Deletes the WalletDeduction.
        /// </summary>
        /// <param name="walletDeductionId">The WalletDeduction identifier.</param>
        /// <returns></returns>
        public static string DeleteWalletDeduction(int walletDeductionId) => $"{baseUrl}/walletDeduction/{walletDeductionId}";

        #endregion

        #region WalletAdjustment

        /// <summary>
        /// Gets the WalletAdjustment.
        /// </summary>
        /// <returns></returns>
        public static string GetAllWalletAdjustment() => $"{baseUrl}/walletAdjustment";

        /// <summary>
        /// Gets the WalletAdjustment.
        /// </summary>
        /// <param name="walletAdjustmentId">The WalletAdjustment identifier.</param>
        /// <returns></returns>
        public static string GetWalletAdjustmentDetails(int walletAdjustmentId) => $"{baseUrl}/walletAdjustment/{walletAdjustmentId}";

        /// <summary>
        /// Creates the WalletAdjustment.
        /// </summary>
        /// <returns></returns>
        public static string CreateWalletAdjustment() => $"{baseUrl}/walletAdjustment";

        /// <summary>
        /// Updates the WalletAdjustment.
        /// </summary>
        /// <param name="walletAdjustmentId">The WalletAdjustment identifier.</param>
        /// <returns></returns>
        public static string UpdateWalletAdjustment(int walletAdjustmentId) => $"{baseUrl}/walletAdjustment/{walletAdjustmentId}";

        /// <summary>
        /// Deletes the WalletAdjustment.
        /// </summary>
        /// <param name="walletAdjustmentId">The WalletAdjustment identifier.</param>
        /// <returns></returns>
        public static string DeleteWalletAdjustment(int walletAdjustmentId) => $"{baseUrl}/walletAdjustment/{walletAdjustmentId}";

        #endregion

    }
}
