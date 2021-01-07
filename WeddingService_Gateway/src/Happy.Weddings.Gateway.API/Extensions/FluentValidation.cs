using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Identity;
using Happy.Weddings.Gateway.Core.DTO.Identity.Profile;
using Happy.Weddings.Gateway.Core.DTO.Blog.Story;
using Happy.Weddings.Gateway.Core.DTO.Blog.Review;
using Happy.Weddings.Gateway.Core.DTO.Blog.CommentReply;
using Happy.Weddings.Gateway.Core.DTO.Wallet.Wallet;
using Happy.Weddings.Gateway.Core.DTO.Wallet.WalletStatus;
using Happy.Weddings.Gateway.Core.DTO.Wallet.WalletRule;
using Happy.Weddings.Gateway.Core.DTO.Wallet.WalletAdjustment;
using Happy.Weddings.Gateway.Core.DTO.Wallet.WalletDeduction;
using Happy.Weddings.Gateway.Core.DTO.Wallet.PaymentBook;
using Happy.Weddings.Gateway.Core.DTO.Wallet.Refund;
using Happy.Weddings.Gateway.Core.DTO.Wallet.Transactions;
using Happy.Weddings.Gateway.Service.Validators.v1.Identity.User;
using Happy.Weddings.Gateway.Service.Validators.v1.Blog.Story;
using Happy.Weddings.Gateway.Service.Validators.v1.Blog.Review;
using Happy.Weddings.Gateway.Service.Validators.v1.Blog.CommentReply;
using Happy.Weddings.Gateway.Service.Validators.v1.Wallet.Wallet;
using Happy.Weddings.Gateway.Service.Validators.v1.Wallet.WalletStatus;
using Happy.Weddings.Gateway.Service.Validators.v1.Wallet.WalletRule;
using Happy.Weddings.Gateway.Service.Validators.v1.Wallet.WalletAdjustment;
using Happy.Weddings.Gateway.Service.Validators.v1.Wallet.WalletDeduction;
using Happy.Weddings.Gateway.Service.Validators.v1.Wallet.PaymentBook;
using Happy.Weddings.Gateway.Service.Validators.v1.Wallet.Refund;
using Happy.Weddings.Gateway.Service.Validators.v1.Wallet.Transactions;
using Microsoft.Extensions.DependencyInjection;
using Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead;
using Happy.Weddings.Gateway.Service.Validators.v1.LeadManagement.Lead;
using Happy.Weddings.Gateway.Core.DTO.LeadManagement;
using Happy.Weddings.Gateway.Core.DTO.AuditLog.AuditLog;
using Happy.Weddings.Gateway.Service.Validators.v1.AuditLog.AuditLog;

namespace Happy.Weddings.Gateway.API.Extensions
{
    /// <summary>
    /// Extension for adding fluent validators
    /// </summary>
    public static class FluentValidation
    {
        /// <summary>
        /// Adds the fluent validators.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddFluentAbstractValidators(this IServiceCollection services)
        {
            #region Identity

            //UserProfile
            services.AddTransient<IValidator<ProfileIdDetails>, UserIdDetailsValidator>();
            services.AddTransient<IValidator<CreateUserProfileRequest>, CreateUserRequestValidator>();
            services.AddTransient<IValidator<UpdateUserProfileRequest>, UpdateUserRequestValidator>();

            #endregion

            #region Blog

            //Multicode
            services.AddTransient<IValidator<Core.DTO.Blog.Multicode.MulticodeIdDetails>, Service.Validators.v1.Blog.Multicode.MulticodeIdDetailsValidator>();
            services.AddTransient<IValidator<Core.DTO.Blog.Multicode.CreateMulticodeBlogRequest>, Service.Validators.v1.Blog.Multicode.CreateMulticodeRequestValidator>();
            services.AddTransient<IValidator<Core.DTO.Blog.Multicode.UpdateMulticodeBlogRequest>, Service.Validators.v1.Blog.Multicode.UpdateMulticodeRequestValidator>();


            //Multidetail
            services.AddTransient<IValidator<Core.DTO.Blog.Multidetail.MultidetailIdDetails>, Service.Validators.v1.Blog.Multidetail.MultidetailIdDetailsValidator>();
            services.AddTransient<IValidator<Core.DTO.Blog.Multidetail.MulticodeIdDetails>, Service.Validators.v1.Blog.Multidetail.MulticodeIdDetailsValidator>();
            services.AddTransient<IValidator<Core.DTO.Blog.Multidetail.CreateMultidetailBlogRequest>, Service.Validators.v1.Blog.Multidetail.CreateMultidetailRequestValidator>();
            services.AddTransient<IValidator<Core.DTO.Blog.Multidetail.UpdateMultidetailBlogRequest>, Service.Validators.v1.Blog.Multidetail.UpdateMultidetailRequestValidator>();


            //Story
            services.AddTransient<IValidator<StoryIdDetails>, StoryIdDetailsValidator>();
            services.AddTransient<IValidator<CreateStoryRequest>, CreateStoryRequestValidator>();
            services.AddTransient<IValidator<UpdateStoryRequest>, UpdateStoryRequestValidator>();

            //Review
            services.AddTransient<IValidator<ReviewIdDetails>, ReviewIdDetailsValidator>();
            services.AddTransient<IValidator<CreateReviewBlogRequest>, CreateReviewRequestValidator>();
            services.AddTransient<IValidator<UpdateReviewBlogRequest>, UpdateReviewRequestValidator>();

            //CommentReply
            services.AddTransient<IValidator<CommentReplyIdDetails>, CommentReplyIdDetailsValidator>();
            services.AddTransient<IValidator<CreateCommentReplyBlogRequest>, CreateCommentReplyRequestValidator>();
            services.AddTransient<IValidator<UpdateCommentReplyBlogRequest>, UpdateCommentReplyRequestValidator>();

            #endregion

            #region Wallet

            //Multicode
            services.AddTransient<IValidator<Core.DTO.Wallet.Multicode.MulticodeIdDetails>, Service.Validators.v1.Wallet.Multicode.MulticodeIdDetailsValidator>();
            services.AddTransient<IValidator<Core.DTO.Wallet.Multicode.CreateMulticodeWalletRequest>, Service.Validators.v1.Wallet.Multicode.CreateMulticodeRequestValidator>();
            services.AddTransient<IValidator<Core.DTO.Wallet.Multicode.UpdateMulticodeWalletRequest>, Service.Validators.v1.Wallet.Multicode.UpdateMulticodeRequestValidator>();

            //Multidetail
            services.AddTransient<IValidator<Core.DTO.Wallet.Multidetail.MultidetailIdDetails>, Service.Validators.v1.Wallet.Multidetail.MultidetailIdDetailsValidator>();
            services.AddTransient<IValidator<Core.DTO.Wallet.Multidetail.MulticodeIdDetails>, Service.Validators.v1.Wallet.Multidetail.MulticodeIdDetailsValidator>();
            services.AddTransient<IValidator<Core.DTO.Wallet.Multidetail.CreateMultidetailWalletRequest>, Service.Validators.v1.Wallet.Multidetail.CreateMultidetailRequestValidator>();
            services.AddTransient<IValidator<Core.DTO.Wallet.Multidetail.UpdateMultidetailWalletRequest>, Service.Validators.v1.Wallet.Multidetail.UpdateMultidetailRequestValidator>();

            //Wallet
            services.AddTransient<IValidator<WalletIdDetails>, WalletIdDetailsValidator>();
            services.AddTransient<IValidator<CreateWalletRequest>, CreateWalletRequestValidator>();
            services.AddTransient<IValidator<UpdateWalletRequest>, UpdateWalletRequestValidator>();

            //WalletStatus
            services.AddTransient<IValidator<WalletStatusIdDetails>, WalletStatusIdDetailsValidator>();
            services.AddTransient<IValidator<CreateWalletStatusRequest>, CreateWalletStatusRequestValidator>();
            services.AddTransient<IValidator<UpdateWalletStatusRequest>, UpdateWalletStatusRequestValidator>();

            //WalletRule
            services.AddTransient<IValidator<WalletRuleIdDetails>, WalletRuleIdDetailsValidator>();
            services.AddTransient<IValidator<CreateWalletRuleRequest>, CreateWalletRuleRequestValidator>();
            services.AddTransient<IValidator<UpdateWalletRuleRequest>, UpdateWalletRuleRequestValidator>();

            //PaymentBook
            services.AddTransient<IValidator<PaymentBookIdDetails>, PaymentBookIdDetailsValidator>();
            services.AddTransient<IValidator<CreatePaymentBookRequest>, CreatePaymentBookRequestValidator>();
            services.AddTransient<IValidator<UpdatePaymentBookRequest>, UpdatePaymentBookRequestValidator>();

            //Refund
            services.AddTransient<IValidator<RefundIdDetails>, RefundIdDetailsValidator>();
            services.AddTransient<IValidator<CreateRefundRequest>, CreateRefundRequestValidator>();
            services.AddTransient<IValidator<UpdateRefundRequest>, UpdateRefundRequestValidator>();

            //Transactions
            services.AddTransient<IValidator<TransactionsIdDetails>, TransactionsIdDetailsValidator>();

            //WalletDeduction
            services.AddTransient<IValidator<WalletDeductionIdDetails>, WalletDeductionIdDetailsValidator>();
            services.AddTransient<IValidator<CreateWalletDeductionRequest>, CreateWalletDeductionRequestValidator>();
            services.AddTransient<IValidator<UpdateWalletDeductionRequest>, UpdateWalletDeductionRequestValidator>();

            //WalletAdjustment
            services.AddTransient<IValidator<WalletAdjustmentIdDetails>, WalletAdjustmentIdDetailsValidator>();
            services.AddTransient<IValidator<CreateWalletAdjustmentRequest>, CreateWalletAdjustmentRequestValidator>();
            services.AddTransient<IValidator<UpdateWalletAdjustmentRequest>, UpdateWalletAdjustmentRequestValidator>();

            #endregion

            #region LeadManagement

            //Multicode
            services.AddTransient<IValidator<Core.DTO.LeadManagement.Multicode.MulticodeIdDetails>, Service.Validators.v1.LeadManagement.Multicode.MulticodeIdDetailsValidator>();
            services.AddTransient<IValidator<Core.DTO.LeadManagement.Multicode.CreateMulticodeLeadRequest>, Service.Validators.v1.LeadManagement.Multicode.CreateMulticodeRequestValidator>();
            services.AddTransient<IValidator<Core.DTO.LeadManagement.Multicode.UpdateMulticodeLeadRequest>, Service.Validators.v1.LeadManagement.Multicode.UpdateMulticodeRequestValidator>();

            //Multidetail
            services.AddTransient<IValidator<Core.DTO.LeadManagement.Multidetail.MultidetailIdDetails>, Service.Validators.v1.LeadManagement.Multidetail.MultidetailIdDetailsValidator>();
            services.AddTransient<IValidator<Core.DTO.LeadManagement.Multidetail.MulticodeIdDetails>, Service.Validators.v1.LeadManagement.Multidetail.MulticodeIdDetailsValidator>();
            services.AddTransient<IValidator<Core.DTO.LeadManagement.Multidetail.CreateMultidetailLeadRequest>, Service.Validators.v1.LeadManagement.Multidetail.CreateMultidetailRequestValidator>();
            services.AddTransient<IValidator<Core.DTO.LeadManagement.Multidetail.UpdateMultidetailLeadRequest>, Service.Validators.v1.LeadManagement.Multidetail.UpdateMultidetailRequestValidator>();

            //lead Datacollection
            services.AddTransient<IValidator<LeadDataCollectionIdDetails>, LeadDataCollectionIdDetailsValidator>();
            services.AddTransient<IValidator<CreateLeadDataCollectionRequest>, CreateLeadDataCollectionRequestValidator>();

            //Leads
            services.AddTransient<IValidator<LeadIdDetails>, LeadIdDetailsValidator>();
            services.AddTransient<IValidator<CreateLeadRequest>, CreateLeadRequestValidator>();
            services.AddTransient<IValidator<UpdateLeadRequest>, UpdateLeadRequestValidator>();

            //Lead Status
            services.AddTransient<IValidator<LeadStatusIdDetails>, LeadStatusIdDetailsValidator>();
            services.AddTransient<IValidator<CreateLeadStatusRequest>, CreateLeadStatusRequestValidator>();
            services.AddTransient<IValidator<UpdateLeadStatusRequest>, UpdateLeadStatusRequestValidator>();

            //Lead Assign
            services.AddTransient<IValidator<LeadAssignIdDetails>, LeadAssignIdDetailsValidator>();
            services.AddTransient<IValidator<CreateLeadAssignRequest>, CreateLeadAssignRequestValidator>();
            services.AddTransient<IValidator<UpdateLeadAssignRequest>, UpdateLeadAssignRequestValidator>();

            //Lead Validation
            services.AddTransient<IValidator<LeadValidationIdDetails>, LeadValidationIdDetailsValidator>();
            services.AddTransient<IValidator<CreateLeadValidationRequest>, CreateLeadValidationRequestValidator>();
            services.AddTransient<IValidator<UpdateLeadValidationRequest>, UpdateLeadValidationRequestValidator>();

            //Lead Quote
            services.AddTransient<IValidator<LeadQuoteIdDetails>, LeadQuoteIdDetailsValidator>();
            services.AddTransient<IValidator<LeadQuote>, CreateLeadQuoteRequestValidator>();
            services.AddTransient<IValidator<UpdateLeadQuoteRequest>, UpdateLeadQuoteRequestValidator>();


            #endregion

            #region AuditLog

            //Multicode
            services.AddTransient<IValidator<Core.DTO.AuditLog.MultiCode.MulticodeIdDetails>, Service.Validators.v1.AuditLog.MultiCode.MulticodeIdDetailsValidator>();
            services.AddTransient<IValidator<Core.DTO.AuditLog.MultiCode.CreateMulticodeAuditLogRequest>, Service.Validators.v1.AuditLog.MultiCode.CreateMulticodeRequestValidator>();
            services.AddTransient<IValidator<Core.DTO.AuditLog.MultiCode.UpdateMulticodeAuditLogRequest>, Service.Validators.v1.AuditLog.MultiCode.UpdateMulticodeRequestValidator>();

            //Multidetail
            services.AddTransient<IValidator<Core.DTO.AuditLog.MultiDetail.MultidetailIdDetails>, Service.Validators.v1.AuditLog.MultiDetail.MultidetailIdDetailsValidator>();
            services.AddTransient<IValidator<Core.DTO.AuditLog.MultiDetail.MulticodeIdDetails>, Service.Validators.v1.AuditLog.MultiDetail.MulticodeIdDetailsValidator>();
            services.AddTransient<IValidator<Core.DTO.AuditLog.MultiDetail.CreateMultidetailAuditLogRequest>, Service.Validators.v1.AuditLog.MultiDetail.CreateMultidetailRequestValidator>();
            services.AddTransient<IValidator<Core.DTO.AuditLog.MultiDetail.UpdateMultidetailAuditLogRequest>, Service.Validators.v1.AuditLog.MultiDetail.UpdateMultidetailRequestValidator>();

            //AuditLog
            services.AddTransient<IValidator<AuditLogIdDetails>, AuditLogIdDetailsValidator>();
            services.AddTransient<IValidator<CreateAuditLogRequest>, CreateAuditLogRequestValidator>();
            services.AddTransient<IValidator<UpdateAuditLogRequest>, UpdateAuditLogRequestValidator>();

            #endregion

            return services;
        }
    }
}
