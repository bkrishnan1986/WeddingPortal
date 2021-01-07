using AutoMapper;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using Happy.Weddings.Wallet.Core.DTO.Responses.MultiCode;
using Happy.Weddings.Wallet.Core.DTO.Responses.MultiDetail;
using Happy.Weddings.Wallet.Core.DTO.Responses.Wallet;
using Happy.Weddings.Wallet.Core.DTO.Responses.WalletRule;
using Happy.Weddings.Wallet.Core.DTO.Responses.WalletStatus;
using Happy.Weddings.Wallet.Core.DTO.Responses.WalletAdjustment;
using Happy.Weddings.Wallet.Core.DTO.Responses.WalletDeduction;
using Happy.Weddings.Wallet.Core.DTO.Responses.PaymentBook;
using Happy.Weddings.Wallet.Core.DTO.Responses.Transactions;
using Happy.Weddings.Wallet.Core.Helpers;
using Happy.Weddings.Wallet.Core.Infrastructure;
using Happy.Weddings.Wallet.Core.Repository;
using Happy.Weddings.Wallet.Data.DatabaseContext;
using Happy.Weddings.Wallet.Data.Repository;
using Happy.Weddings.Wallet.Infrastructure;
using Happy.Weddings.Wallet.Service.Commands.v1.MultiCode;
using Happy.Weddings.Wallet.Service.Commands.v1.MultiDetail;
using Happy.Weddings.Wallet.Service.Commands.v1.Wallet;
using Happy.Weddings.Wallet.Service.Commands.v1.WalletRule;
using Happy.Weddings.Wallet.Service.Commands.v1.WalletStatus;
using Happy.Weddings.Wallet.Service.Commands.v1.WalletAdjustment;
using Happy.Weddings.Wallet.Service.Commands.v1.WalletDeduction;
using Happy.Weddings.Wallet.Service.Commands.v1.PaymentBook;
using Happy.Weddings.Wallet.Service.Handlers.v1.MultiCode;
using Happy.Weddings.Wallet.Service.Handlers.v1.MultiDetail;
using Happy.Weddings.Wallet.Service.Handlers.v1.Wallet;
using Happy.Weddings.Wallet.Service.Handlers.v1.WalletRule;
using Happy.Weddings.Wallet.Service.Handlers.v1.WalletStatus;
using Happy.Weddings.Wallet.Service.Handlers.v1.WalletAdjustment;
using Happy.Weddings.Wallet.Service.Handlers.v1.WalletDeduction;
using Happy.Weddings.Wallet.Service.Handlers.v1.PaymentBook;
using Happy.Weddings.Wallet.Service.Handlers.v1.Transactions;
using Happy.Weddings.Wallet.Service.Helpers;
using Happy.Weddings.Wallet.Service.Queries.v1.MultiCode;
using Happy.Weddings.Wallet.Service.Queries.v1.MultiDetail;
using Happy.Weddings.Wallet.Service.Queries.v1.Wallet;
using Happy.Weddings.Wallet.Service.Queries.v1.WalletRule;
using Happy.Weddings.Wallet.Service.Queries.v1.WalletStatus;
using Happy.Weddings.Wallet.Service.Queries.v1.WalletAdjustment;
using Happy.Weddings.Wallet.Service.Queries.v1.WalletDeduction;
using Happy.Weddings.Wallet.Service.Queries.v1.PaymentBook;
using Happy.Weddings.Wallet.Service.Queries.v1.Transactions;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using Happy.Weddings.Wallet.Core.DTO.Responses.Refund;
using Happy.Weddings.Wallet.Service.Queries.v1.Refund;
using Happy.Weddings.Wallet.Service.Handlers.v1.Refund;
using Happy.Weddings.Wallet.Service.Commands.v1.Refund;
using Happy.Weddings.Wallet.Service.Commands.v1.Transactions;

namespace Happy.Weddings.Wallet.API.Extensions
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

            services.AddSingleton(Log.Logger);
            services.AddSingleton(HostingEnvironment);
            services.AddSingleton(rabbitMQConfig);

            services.AddDbContext<WalletContext>(options => options.UseMySQL(configuration.GetConnectionString("Database")));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddMediatR(typeof(Startup));

            services.AddTransient<IConfigurationManager, ConfigurationManager>();

            //Multi Code
            services.AddScoped<ISortHelper<MultiCodeResponse>, SortHelper<MultiCodeResponse>>();
            services.AddScoped<IDataShaper<MultiCodeResponse>, DataShaper<MultiCodeResponse>>();
            services.AddTransient<IRequestHandler<GetAllMultiCodesQuery, APIResponse>, GetAllMultiCodesHandler>();
            services.AddTransient<IRequestHandler<GetMultiCodeQuery, APIResponse>, GetMultiCodeHandler>();
            services.AddTransient<IRequestHandler<CreateMultiCodeCommand, APIResponse>, CreateMultiCodeHandler>();
            services.AddTransient<IRequestHandler<UpdateMultiCodeCommand, APIResponse>, UpdateMultiCodeHandler>();
            services.AddTransient<IRequestHandler<DeleteMultiCodeCommand, APIResponse>, DeleteMultiCodeHandler>();

            //Multi Detail
            services.AddScoped<ISortHelper<MultiDetailResponse>, SortHelper<MultiDetailResponse>>();
            services.AddScoped<IDataShaper<MultiDetailResponse>, DataShaper<MultiDetailResponse>>();
            services.AddTransient<IRequestHandler<GetAllMultiDetailsQuery, APIResponse>, GetAllMultiDetailsHandler>();
            services.AddTransient<IRequestHandler<GetMultiDetailsByIdQuery, APIResponse>, GetMultiDetailHandler>();
            services.AddTransient<IRequestHandler<CreateMultiDetailsCommand, APIResponse>, CreateMultiDetailHandler>();
            services.AddTransient<IRequestHandler<UpdateMultiDetailsCommand, APIResponse>, UpdateMultiDetailHandler>();
            services.AddTransient<IRequestHandler<DeleteMultiDetailsCommand, APIResponse>, DeleteMultiDetailHandler>();

            //Wallet
            services.AddScoped<ISortHelper<WalletResponse>, SortHelper<WalletResponse>>();
            services.AddScoped<IDataShaper<WalletResponse>, DataShaper<WalletResponse>>();
            services.AddTransient<IRequestHandler<GetAllWalletsQuery, APIResponse>, GetAllWalletsHandler>();
            services.AddTransient<IRequestHandler<GetWalletQuery, APIResponse>, GetWalletHandler>();
            services.AddTransient<IRequestHandler<CreateWalletCommand, APIResponse>, CreateWalletHandler>();
            services.AddTransient<IRequestHandler<UpdateWalletCommand, APIResponse>, UpdateWalletHandler>();
            services.AddTransient<IRequestHandler<DeleteWalletCommand, APIResponse>, DeleteWalletHandler>();

            //Wallet Status
            services.AddScoped<ISortHelper<WalletStatusResponse>, SortHelper<WalletStatusResponse>>();
            services.AddScoped<IDataShaper<WalletStatusResponse>, DataShaper<WalletStatusResponse>>();
            services.AddTransient<IRequestHandler<GetAllWalletStatusQuery, APIResponse>, GetAllWalletStatusHandler>();
            services.AddTransient<IRequestHandler<GetWalletStatusQuery, APIResponse>, GetWalletStatusHandler>();
            services.AddTransient<IRequestHandler<CreateWalletStatusCommand, APIResponse>, CreateWalletStatusHandler>();
            services.AddTransient<IRequestHandler<UpdateWalletStatusCommand, APIResponse>, UpdateWalletStatusHandler>();
            services.AddTransient<IRequestHandler<DeleteWalletStatusCommand, APIResponse>, DeleteWalletStatusHandler>();

            //Wallet Rule
            services.AddScoped<ISortHelper<WalletRuleResponse>, SortHelper<WalletRuleResponse>>();
            services.AddScoped<IDataShaper<WalletRuleResponse>, DataShaper<WalletRuleResponse>>();
            services.AddTransient<IRequestHandler<GetAllWalletRuleQuery, APIResponse>, GetAllWalletRuleHandler>();
            services.AddTransient<IRequestHandler<GetWalletRuleQuery, APIResponse>, GetWalletRuleHandler>();
            services.AddTransient<IRequestHandler<CreateWalletRuleCommand, APIResponse>, CreateWalletRuleHandler>();
            services.AddTransient<IRequestHandler<UpdateWalletRuleCommand, APIResponse>, UpdateWalletRuleHandler>();
            services.AddTransient<IRequestHandler<DeleteWalletRuleCommand, APIResponse>, DeleteWalletRuleHandler>();

            //PaymentBook
            services.AddScoped<ISortHelper<PaymentBookResponse>, SortHelper<PaymentBookResponse>>();
            services.AddScoped<IDataShaper<PaymentBookResponse>, DataShaper<PaymentBookResponse>>();
            services.AddTransient<IRequestHandler<GetAllPaymentBookQuery, APIResponse>, GetAllPaymentBookHandler>();
            services.AddTransient<IRequestHandler<GetPaymentBookQuery, APIResponse>, GetPaymentBookHandler>();
            services.AddTransient<IRequestHandler<CreatePaymentBookCommand, APIResponse>, CreatePaymentBookHandler>();
            services.AddTransient<IRequestHandler<UpdatePaymentBookCommand, APIResponse>, UpdatePaymentBookHandler>();

            //Refund
            services.AddScoped<ISortHelper<RefundResponse>, SortHelper<RefundResponse>>();
            services.AddScoped<IDataShaper<RefundResponse>, DataShaper<RefundResponse>>();
            services.AddTransient<IRequestHandler<GetAllRefundQuery, APIResponse>, GetAllRefundHandler>();
            services.AddTransient<IRequestHandler<GetRefundQuery, APIResponse>, GetRefundHandler>();
            services.AddTransient<IRequestHandler<CreateRefundCommand, APIResponse>, CreateRefundHandler>();
            services.AddTransient<IRequestHandler<UpdateRefundCommand, APIResponse>, UpdateRefundHandler>();

            //Transactions
            services.AddScoped<ISortHelper<TransactionsResponse>, SortHelper<TransactionsResponse>>();
            services.AddScoped<IDataShaper<TransactionsResponse>, DataShaper<TransactionsResponse>>();
            services.AddTransient<IRequestHandler<GetAllTransactionsQuery, APIResponse>, GetAllTransactionsHandler>();
            services.AddTransient<IRequestHandler<GetTransactionsQuery, APIResponse>, GetTransactionsHandler>();
            services.AddTransient<IRequestHandler<CreateTransactionsCommand, APIResponse>, CreateTransactionsHandler>();

            //WalletDeduction
            services.AddScoped<ISortHelper<WalletDeductionResponse>, SortHelper<WalletDeductionResponse>>();
            services.AddScoped<IDataShaper<WalletDeductionResponse>, DataShaper<WalletDeductionResponse>>();
            services.AddTransient<IRequestHandler<GetAllWalletDeductionQuery, APIResponse>, GetAllWalletDeductionHandler>();
            services.AddTransient<IRequestHandler<GetWalletDeductionQuery, APIResponse>, GetWalletDeductionHandler>();
            services.AddTransient<IRequestHandler<CreateWalletDeductionCommand, APIResponse>, CreateWalletDeductionHandler>();
            services.AddTransient<IRequestHandler<UpdateWalletDeductionCommand, APIResponse>, UpdateWalletDeductionHandler>();
            services.AddTransient<IRequestHandler<DeleteWalletDeductionCommand, APIResponse>, DeleteWalletDeductionHandler>();

            //Wallet Adjustment
            services.AddScoped<ISortHelper<WalletAdjustmentResponse>, SortHelper<WalletAdjustmentResponse>>();
            services.AddScoped<IDataShaper<WalletAdjustmentResponse>, DataShaper<WalletAdjustmentResponse>>();
            services.AddTransient<IRequestHandler<GetAllWalletAdjustmentQuery, APIResponse>, GetAllWalletAdjustmentHandler>();
            services.AddTransient<IRequestHandler<GetWalletAdjustmentQuery, APIResponse>, GetWalletAdjustmentHandler>();
            services.AddTransient<IRequestHandler<CreateWalletAdjustmentCommand, APIResponse>, CreateWalletAdjustmentHandler>();
            services.AddTransient<IRequestHandler<UpdateWalletAdjustmentCommand, APIResponse>, UpdateWalletAdjustmentHandler>();
            services.AddTransient<IRequestHandler<DeleteWalletAdjustmentCommand, APIResponse>, DeleteWalletAdjustmentHandler>();

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            return services;
        }
    }
}
