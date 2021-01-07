using Happy.Weddings.Gateway.Core.Infrastructure;
using Happy.Weddings.Gateway.Core.Messaging.Sender.v1.Identity;
using Happy.Weddings.Gateway.Core.Services.v1.Identity;
using Happy.Weddings.Gateway.Core.Services.v1.Blog;
using Happy.Weddings.Gateway.Core.Services.v1.Wallet;
using Happy.Weddings.Gateway.Core.Services.v1.AuditLog;
using Happy.Weddings.Gateway.Infrastructure;
using Happy.Weddings.Gateway.Messaging.Sender.v1.Identity;
using Happy.Weddings.Gateway.Service.Services.v1.Blog;
using Happy.Weddings.Gateway.Service.Services.v1.Identity;
using Happy.Weddings.Gateway.Service.Services.v1.Wallet;
using Happy.Weddings.Gateway.Service.Services.v1.AuditLog;
using Serilog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Happy.Weddings.Gateway.Core.Services.v1.Vendor;
using Happy.Weddings.Gateway.Service.Services.v1.Vendor;
using Happy.Weddings.Gateway.Core.Services.v1.LeadManagement;
using Happy.Weddings.Gateway.Service.Services.v1.LeadManagement;

namespace Happy.Weddings.Gateway.API.Extensions
{
    /// <summary>
    /// Extension for adding object injection lifetime
    /// </summary>
    public static class ServicesInjection
    {
        /// <summary>
        /// Adds the services injection.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="HostingEnvironment">The hosting environment.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static IServiceCollection AddServicesInjection(this IServiceCollection services,
                                                                           IWebHostEnvironment HostingEnvironment,
                                                                           IConfiguration configuration)
        {
            //Configure logger
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            var rabbitMQConfig = configuration.GetSection("RabbitMqConfig").Get<RabbitMqConfig>();
            var servicesConfig = configuration.GetSection("ServicesConfig").Get<ServicesConfig>();
            var authorizationConfig = configuration.GetSection("AuthorizationConfig").Get<AuthorizationConfig>();

            services.AddSingleton(Log.Logger);
            services.AddSingleton(HostingEnvironment);
            services.AddSingleton(rabbitMQConfig);
            services.AddSingleton(servicesConfig);
            services.AddSingleton(authorizationConfig);
            
            services.AddTransient<IConfigurationManager, ConfigurationManager>();
            services.AddTransient<IUsernameUpdateSender, UsernameUpdateSender>();

            #region Identity

            services.AddTransient<IUserProfileService, UserProfileService>();
            services.AddTransient<IKYCDetailsService, KYCDetailsService>();
            services.AddTransient<Core.Services.v1.Identity.IMulticodeService,Service.Services.v1.Identity.MulticodeService>();
            services.AddTransient<Core.Services.v1.Identity.IMultidetailService,Service.Services.v1.Identity.MultidetailService>();

            #endregion

            #region Blog

            services.AddTransient<IStoryService, StoryService>();
            services.AddTransient<IReviewService, ReviewService>();
            services.AddTransient<ICommentReplyService, CommentReplyService>();
            services.AddTransient<Core.Services.v1.Blog.IMulticodeService, Service.Services.v1.Blog.MulticodeService>();
            services.AddTransient<Core.Services.v1.Blog.IMultidetailService, Service.Services.v1.Blog.MultidetailService>();

            #endregion

            #region Wallet

            services.AddTransient<Core.Services.v1.Wallet.IMulticodeService, Service.Services.v1.Wallet.MulticodeService>();
            services.AddTransient<Core.Services.v1.Wallet.IMultidetailService, Service.Services.v1.Wallet.MultidetailService>();
            services.AddTransient<IWalletService, WalletService>();
            services.AddTransient<IWalletStatusService, WalletStatusService>();
            services.AddTransient<IWalletRuleService, WalletRuleService>();
            services.AddTransient<IPaymentBookService, PaymentBookService>();
            services.AddTransient<IRefundService, RefundService>();
            services.AddTransient<ITransactionsService, TransactionsService>();
            services.AddTransient<IWalletDeductionService, WalletDeductionService>();
            services.AddTransient<IWalletAdjustmentService, WalletAdjustmentService>();

            #endregion

            #region Vendor

            services.AddTransient<IBranchService, BranchService>();
            services.AddTransient<IMultiCodeService, MultiCodeService>();
            services.AddTransient<IMultiDetailService, MultiDetailService>();
            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<IServiceQuestionService, ServiceQuestionService>();
            services.AddTransient<IServicesService, ServicesService>();
            services.AddTransient<IServiceSubscriptionService, ServiceSubscriptionService>();
            services.AddTransient<IServiceTopupService, ServiceTopupService>();
            services.AddTransient<IUtilityService, UtilityService>();
            services.AddTransient<IEventService, EventService>();
            #endregion

            #region LeadManagement

            services.AddTransient<ILeadService, LeadService>();
            services.AddTransient<Core.Services.v1.LeadManagement.IMulticodeService, Service.Services.v1.LeadManagement.MulticodeService>();
            services.AddTransient<Core.Services.v1.LeadManagement.IMultidetailService, Service.Services.v1.LeadManagement.MultidetailService>();

            #endregion

            #region AuditLog

            services.AddTransient<IAuditLogService, AuditLogService>();
            services.AddTransient<Core.Services.v1.AuditLog.IMulticodeService, Service.Services.v1.AuditLog.MulticodeService>();
            services.AddTransient<Core.Services.v1.AuditLog.IMultidetailService, Service.Services.v1.AuditLog.MultidetailService>();

            #endregion

            #region ECommerce

            // services.AddTransient<IBranchService, BranchService>();
            services.AddTransient<Core.Services.v1.ECommerce.IMulticodeService, Service.Services.v1.ECommerce.MulticodeService>();
            services.AddTransient<Core.Services.v1.ECommerce.IMultidetailService, Service.Services.v1.ECommerce.MultidetailService>();
            services.AddTransient<Core.Services.v1.ECommerce.ICartService, Service.Services.v1.ECommerce.CartService>();
            services.AddTransient<Core.Services.v1.ECommerce.IProductService, Service.Services.v1.ECommerce.ProductService>();
            services.AddTransient<Core.Services.v1.ECommerce.IProductquantityService, Service.Services.v1.ECommerce.ProductquantityService>();
            services.AddTransient<Core.Services.v1.ECommerce.IOrderService, Service.Services.v1.ECommerce.OrderService>();
            services.AddTransient<Core.Services.v1.ECommerce.IOrderlocationService, Service.Services.v1.ECommerce.OrderlocationService>();
            services.AddTransient<Core.Services.v1.ECommerce.IOrderreturnService, Service.Services.v1.ECommerce.OrderreturnService>();
            services.AddTransient<Core.Services.v1.ECommerce.IRegistryService, Service.Services.v1.ECommerce.RegistryService>();
            //services.AddTransient<IProfileService, ProfileService>();
            //services.AddTransient<IServiceQuestionService, ServiceQuestionService>();

            #endregion

            #region EventAssistant

            // services.AddTransient<IBranchService, BranchService>();
            services.AddTransient<Core.Services.v1.EventAssistant.IMulticodeService, Service.Services.v1.EventAssistant.MulticodeService>();
            services.AddTransient<Core.Services.v1.EventAssistant.IMultidetailService, Service.Services.v1.EventAssistant.MultidetailService>();
            services.AddTransient<Core.Services.v1.EventAssistant.IBudgeterService, Service.Services.v1.EventAssistant.BudgeterService>();
            services.AddTransient<Core.Services.v1.EventAssistant.IChecklistService, Service.Services.v1.EventAssistant.ChecklistService>();
            services.AddTransient<Core.Services.v1.EventAssistant.IInvitationService, Service.Services.v1.EventAssistant.InvitationService>();
            services.AddTransient<Core.Services.v1.EventAssistant.IUserinvitationService, Service.Services.v1.EventAssistant.UserInvitationService>();
            services.AddTransient<Core.Services.v1.EventAssistant.IGuestlistService, Service.Services.v1.EventAssistant.GuestlistService>();
            services.AddTransient<Core.Services.v1.EventAssistant.IGuesteventlistService, Service.Services.v1.EventAssistant.GuestEventlistService>();
            //services.AddTransient<IProfileService, ProfileService>();
            //services.AddTransient<IServiceQuestionService, ServiceQuestionService>();

            #endregion

            return services;
        }
    }
}
