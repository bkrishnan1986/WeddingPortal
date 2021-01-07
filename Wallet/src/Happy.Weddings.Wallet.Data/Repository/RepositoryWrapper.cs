#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | RepositoryWrapper class.
//----------------------------------------------------------------------------------------------

#endregion

using AutoMapper;
using Happy.Weddings.Wallet.Core.DTO.Responses.MultiCode;
using Happy.Weddings.Wallet.Core.DTO.Responses.MultiDetail;
using Happy.Weddings.Wallet.Core.DTO.Responses.Wallet;
using Happy.Weddings.Wallet.Core.DTO.Responses.WalletRule;
using Happy.Weddings.Wallet.Core.DTO.Responses.WalletStatus;
using Happy.Weddings.Wallet.Core.DTO.Responses.WalletAdjustment;
using Happy.Weddings.Wallet.Core.DTO.Responses.WalletDeduction;
using Happy.Weddings.Wallet.Core.DTO.Responses.PaymentBook;
using Happy.Weddings.Wallet.Core.DTO.Responses.Refund;
using Happy.Weddings.Wallet.Core.DTO.Responses.Transactions;
using Happy.Weddings.Wallet.Core.Helpers;
using Happy.Weddings.Wallet.Core.Repository;
using Happy.Weddings.Wallet.Data.DatabaseContext;
using System.Threading.Tasks;

namespace Happy.Weddings.Wallet.Data.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;
        /// <summary>
        /// Gets or sets the repository context.
        /// </summary>
        private WalletContext repositoryContext { get; set; }



        /// <summary>
        /// Gets the MultiCode.
        /// </summary>
        private IMultiCodeRepository multiCode { get; set; }
        /// <summary>
        /// Gets the MultiDetail.
        /// </summary>
        private IMultiDetailRepository multidetail { get; set; }
        /// <summary>
        /// Gets the Wallet.
        /// </summary>
        private IWalletRepository wallet { get; set; }
        /// <summary>
        /// Gets the WalletRule.
        /// </summary>
        private IWalletRuleRepository WalletRules { get; set; }
        /// <summary>
        /// Gets the WalletStatus.
        /// </summary>
        private IWalletStatusRepository WalletsStatus { get; set; }
        /// <summary>
        /// Gets the WalletAdjustment.
        /// </summary>
        private IWalletAdjustmentRepository WalletsAdjustment { get; set; }
        /// <summary>
        /// Gets the WalletDeduction.
        /// </summary>
        private IWalletDeductionRepository WalletsDeduction { get; set; }
        /// <summary>
        /// Gets the PaymentBook.
        /// </summary>
        private IPaymentBookRepository PaymentBooks { get; set; }
        /// <summary>
        /// Gets the Refund.
        /// </summary>
        private IRefundRepository Refunds { get; set; }
        /// <summary>
        /// Gets the Transactions.
        /// </summary>
        private ITransactionsRepository Transaction { get; set; }



        /// <summary>
        /// The multicode sort helper
        /// </summary>
        private ISortHelper<MultiCodeResponse> multicodeSortHelper;
        /// <summary>
        /// The multidetail sort helper
        /// </summary>
        private ISortHelper<MultiDetailResponse> multidetailSortHelper;
        /// <summary>
        /// The wallet sort helper
        /// </summary>
        private ISortHelper<WalletResponse> walletSortHelper;
        /// <summary>
        /// The walletRule sort helper
        /// </summary>
        private ISortHelper<WalletRuleResponse> walletRuleSortHelper;
        /// <summary>
        /// The walletStatus sort helper
        /// </summary>
        private ISortHelper<WalletStatusResponse> walletStatusSortHelper;
        /// <summary>
        /// The walletAdjustment sort helper
        /// </summary>
        private ISortHelper<WalletAdjustmentResponse> walletAdjustmentSortHelper;
        /// <summary>
        /// The walletDeduction sort helper
        /// </summary>
        private ISortHelper<WalletDeductionResponse> walletDeductionSortHelper;
        /// <summary>
        /// The PaymentBook sort helper
        /// </summary>
        private ISortHelper<PaymentBookResponse> paymentBookSortHelper;
        /// <summary>
        /// The Refund sort helper
        /// </summary>
        private ISortHelper<RefundResponse> refundSortHelper;
        /// <summary>
        /// The Transactions sort helper
        /// </summary>
        private ISortHelper<TransactionsResponse> transactionsSortHelper;



        /// <summary>
        /// The multidetail data shaper
        /// </summary>
        private IDataShaper<MultiDetailResponse> multidetailDataShaper;
        /// <summary>
        /// The stories data shaper
        /// </summary>
        private IDataShaper<MultiCodeResponse> multicodeDataShaper;
        /// <summary>
        /// The wallet data shaper
        /// </summary>
        private IDataShaper<WalletResponse> walletDataShaper;
        /// <summary>
        /// The walletRule data shaper
        /// </summary>
        private IDataShaper<WalletRuleResponse> walletRuleDataShaper;
        /// <summary>
        /// The walletStatus data shaper
        /// </summary>
        private IDataShaper<WalletStatusResponse> walletStatusDataShaper;
        /// <summary>
        /// The walletAdjustment data shaper
        /// </summary>
        private IDataShaper<WalletAdjustmentResponse> walletAdjustmentDataShaper;
        /// <summary>
        /// The walletDeduction data shaper
        /// </summary>
        private IDataShaper<WalletDeductionResponse> walletDeductionDataShaper;
        /// <summary>
        /// The PaymentBook data shaper
        /// </summary>
        private IDataShaper<PaymentBookResponse> paymentBookDataShaper;
        /// <summary>
        /// The Refund data shaper
        /// </summary>
        private IDataShaper<RefundResponse> refundDataShaper;
        /// <summary>
        /// The Transactions data shaper
        /// </summary>
        private IDataShaper<TransactionsResponse> transactionsDataShaper;



        /// <summary>
        /// Gets the multicode.
        /// </summary>
        public IMultiCodeRepository MultiCodes
        {
            get
            {
                if (multiCode == null)
                {
                    multiCode = new MultiCodeRepository(repositoryContext, mapper, multicodeSortHelper, multicodeDataShaper);
                }
                return multiCode;
            }
        }
        /// <summary>
        /// Gets the multidetail.
        /// </summary>
        public IMultiDetailRepository MultiDetails
        {
            get
            {
                if (multidetail == null)
                {
                    multidetail = new MultiDetailRepository(repositoryContext, mapper, multidetailSortHelper, multidetailDataShaper);
                }
                return multidetail;
            }
        }
        /// <summary>
        /// Gets the Wallet.
        /// </summary>
        public IWalletRepository Wallets
        {
            get
            {
                if (wallet == null)
                {
                    wallet = new WalletRepository(repositoryContext, mapper, walletSortHelper, walletDataShaper);
                }
                return wallet;
            }
        }
        /// <summary>
        /// Gets the WalletRules.
        /// </summary>
        public IWalletRuleRepository WalletRule
        {
            get
            {
                if (WalletRules == null)
                {
                    WalletRules = new WalletRuleRepository(repositoryContext, mapper, walletRuleSortHelper, walletRuleDataShaper);
                }
                return WalletRules;
            }
        }
        /// <summary>
        /// Gets the WalletStatus.
        /// </summary>
        public IWalletStatusRepository WalletStatus
        {
            get
            {
                if (WalletsStatus == null)
                {
                    WalletsStatus = new WalletStatusRepository(repositoryContext, mapper, walletStatusSortHelper, walletStatusDataShaper);
                }
                return WalletsStatus;
            }
        }
        /// <summary>
        /// Gets the WalletAdjustment.
        /// </summary>
        public IWalletAdjustmentRepository WalletAdjustment
        {
            get
            {
                if (WalletsAdjustment == null)
                {
                    WalletsAdjustment = new WalletAdjustmentRepository(repositoryContext, mapper, walletAdjustmentSortHelper, walletAdjustmentDataShaper);
                }
                return WalletsAdjustment;
            }
        }
        /// <summary>
        /// Gets the WalletDeduction.
        /// </summary>
        public IWalletDeductionRepository WalletDeduction
        {
            get
            {
                if (WalletsDeduction == null)
                {
                    WalletsDeduction = new WalletDeductionRepository(repositoryContext, mapper, walletDeductionSortHelper, walletDeductionDataShaper);
                }
                return WalletsDeduction;
            }
        }
        /// <summary>
        /// Gets the PaymentBook.
        /// </summary>
        public IPaymentBookRepository PaymentBook
        {
            get
            {
                if (PaymentBooks == null)
                {
                    PaymentBooks = new PaymentBookRepository(repositoryContext, mapper, paymentBookSortHelper, paymentBookDataShaper);
                }
                return PaymentBooks;
            }
        }
        /// <summary>
        /// Gets the Refund.
        /// </summary>
        public IRefundRepository Refund
        {
            get
            {
                if (Refunds == null)
                {
                    Refunds = new RefundRepository(repositoryContext, mapper, refundSortHelper, refundDataShaper);
                }
                return Refunds;
            }
        }
        /// <summary>
        /// Gets the Transactions.
        /// </summary>
        public ITransactionsRepository Transactions
        {
            get
            {
                if (Transaction == null)
                {
                    Transaction = new TransactionsRepository(repositoryContext, mapper, transactionsSortHelper, transactionsDataShaper);
                }
                return Transaction;
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryWrapper" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="multicodeSortHelper">The multicode sort helper.</param>
        /// <param name="multicodeDataShaper">The multicode data shaper.</param>
        /// <param name="multidetailSortHelper">The multidetail sort helper.</param>
        /// <param name="multidetailDataShaper">The mutlidetail data shaper.</param>
        /// <param name="eventsSortHelper">The event sort helper.</param>
        /// <param name="eventsDataShaper">The event data shaper.</param>
        /// <param name="eventgallerySortHelper">The event sort helper.</param>
        /// <param name="eventgalleryDataShaper">The event data shaper.</param>
        public RepositoryWrapper(
            WalletContext repositoryContext,
            IMapper mapper,
            ISortHelper<MultiCodeResponse> multicodeSortHelper,
            IDataShaper<MultiCodeResponse> multicodeDataShaper,
            ISortHelper<MultiDetailResponse> multidetailSortHelper,
            IDataShaper<MultiDetailResponse> multidetailDataShaper,
            ISortHelper<WalletResponse> walletSortHelper,
            IDataShaper<WalletResponse> walletDataShaper,
            ISortHelper<WalletRuleResponse> walletRuleSortHelper,
            IDataShaper<WalletRuleResponse> walletRuleDataShaper,
            ISortHelper<WalletStatusResponse> walletStatusSortHelper,
            IDataShaper<WalletStatusResponse> walletStatusDataShaper,
            ISortHelper<WalletAdjustmentResponse> walletAdjustmentSortHelper,
            IDataShaper<WalletAdjustmentResponse> walletAdjustmentDataShaper,
            ISortHelper<WalletDeductionResponse> walletDeductionSortHelper,
            IDataShaper<WalletDeductionResponse> walletDeductionDataShaper,
            ISortHelper<PaymentBookResponse> paymentBookSortHelper,
            IDataShaper<PaymentBookResponse> paymentBookDataShaper,
            ISortHelper<RefundResponse> refundSortHelper,
            IDataShaper<RefundResponse> refundDataShaper,
            ISortHelper<TransactionsResponse> transactionsSortHelper,
            IDataShaper<TransactionsResponse> transactionsDataShaper
           )
        {
            this.repositoryContext = repositoryContext;
            this.mapper = mapper;
            this.multicodeSortHelper = multicodeSortHelper;
            this.multicodeDataShaper = multicodeDataShaper;
            this.multidetailSortHelper = multidetailSortHelper;
            this.multidetailDataShaper = multidetailDataShaper;
            this.walletSortHelper = walletSortHelper;
            this.walletDataShaper = walletDataShaper;
            this.walletRuleSortHelper = walletRuleSortHelper;
            this.walletRuleDataShaper = walletRuleDataShaper;
            this.walletStatusSortHelper = walletStatusSortHelper;
            this.walletStatusDataShaper = walletStatusDataShaper;
            this.walletAdjustmentSortHelper = walletAdjustmentSortHelper;
            this.walletAdjustmentDataShaper = walletAdjustmentDataShaper;
            this.walletDeductionSortHelper = walletDeductionSortHelper;
            this.walletDeductionDataShaper = walletDeductionDataShaper;
            this.paymentBookSortHelper = paymentBookSortHelper;
            this.paymentBookDataShaper = paymentBookDataShaper;
            this.refundSortHelper = refundSortHelper;
            this.refundDataShaper = refundDataShaper;
            this.transactionsSortHelper = transactionsSortHelper;
            this.transactionsDataShaper = transactionsDataShaper;
        }


        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveAsync()
        {
            return await repositoryContext.SaveChangesAsync() >= 0;
        }

    }
}
