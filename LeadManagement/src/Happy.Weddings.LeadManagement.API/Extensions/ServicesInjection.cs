using AutoMapper;
using Happy.Weddings.LeadManagement.Data.DatabaseContext;
using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using Happy.Weddings.LeadManagement.Core.Infrastructure;
using Happy.Weddings.LeadManagement.Core.Repository;
using Happy.Weddings.LeadManagement.Data.Repository;
using Happy.Weddings.LeadManagement.Infrastructure;
using Happy.Weddings.LeadManagement.Service.Commands.v1.Lead;
using Happy.Weddings.LeadManagement.Service.Handlers.v1.Lead;
using Happy.Weddings.LeadManagement.Service.Handlers.v1.Story;
using Happy.Weddings.LeadManagement.Service.Queries.v1.Lead;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using Happy.Weddings.LeadManagement.Core.Helpers;
using Happy.Weddings.LeadManagement.Service.Helpers;
using Happy.Weddings.LeadManagement.Core.DTO.Responses.MultiCode;
using Happy.Weddings.LeadManagement.Service.Queries.v1.MultiCode;
using Happy.Weddings.LeadManagement.Service.Handlers.v1.MultiCode;
using Happy.Weddings.LeadManagement.Service.Commands.v1.MultiCode;
using Happy.Weddings.LeadManagement.Core.DTO.Responses.MultiDetail;
using Happy.Weddings.LeadManagement.Service.Queries.v1.MultiDetail;
using Happy.Weddings.LeadManagement.Service.Commands.v1.MultiDetail;
using Happy.Weddings.LeadManagement.Service.Handlers.v1.MultiDetail;

namespace Happy.Weddings.LeadManagement.API.Extensions
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
            services.AddDbContext<LeadContext>(options => options.UseMySQL(configuration.GetConnectionString("Database")));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(typeof(Startup));
            services.AddTransient<IConfigurationManager, ConfigurationManager>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            #region Multicode

            services.AddScoped<ISortHelper<MultiCodeResponse>, SortHelper<MultiCodeResponse>>();
            services.AddScoped<IDataShaper<MultiCodeResponse>, DataShaper<MultiCodeResponse>>();
            services.AddTransient<IRequestHandler<GetAllMultiCodesQuery, APIResponse>, GetAllMultiCodesHandler>();
            services.AddTransient<IRequestHandler<GetMultiCodeQuery, APIResponse>, GetMultiCodeHandler>();
            services.AddTransient<IRequestHandler<CreateMultiCodeCommand, APIResponse>, CreateMultiCodeHandler>();
            services.AddTransient<IRequestHandler<UpdateMultiCodeCommand, APIResponse>, UpdateMultiCodeHandler>();
            services.AddTransient<IRequestHandler<DeleteMultiCodeCommand, APIResponse>, DeleteMultiCodeHandler>();

            #endregion

            #region Multidetail

            services.AddScoped<ISortHelper<MultiDetailResponse>, SortHelper<MultiDetailResponse>>();
            services.AddScoped<IDataShaper<MultiDetailResponse>, DataShaper<MultiDetailResponse>>();
            services.AddTransient<IRequestHandler<GetAllMultiDetailsQuery, APIResponse>, GetAllMultiDetailsHandler>();
            services.AddTransient<IRequestHandler<GetMultiDetailsByIdQuery, APIResponse>, GetMultiDetailHandler>();
            services.AddTransient<IRequestHandler<CreateMultiDetailsCommand, APIResponse>, CreateMultiDetailHandler>();
            services.AddTransient<IRequestHandler<UpdateMultiDetailsCommand, APIResponse>, UpdateMultiDetailHandler>();
            services.AddTransient<IRequestHandler<DeleteMultiDetailsCommand, APIResponse>, DeleteMultiDetailHandler>();

            #endregion

            #region Lead

            services.AddScoped<ISortHelper<LeadDataCollectionResponse>, SortHelper<LeadDataCollectionResponse>>();
            services.AddScoped<IDataShaper<LeadDataCollectionResponse>, DataShaper<LeadDataCollectionResponse>>();
            services.AddTransient<IRequestHandler<GetAllLeadsQuery, APIResponse>, GetAllLeadsHandler>();
            services.AddTransient<IRequestHandler<GetLeadQuery, APIResponse>, GetLeadHandler>();
            services.AddTransient<IRequestHandler<GetLeadsByVendorQuery, APIResponse>, GetLeadsByVendorHandler>();
            services.AddTransient<IRequestHandler<CreateLeadCommand, APIResponse>, CreateLeadHandler>();
            services.AddTransient<IRequestHandler<UpdateLeadCommand, APIResponse>, UpdateLeadHandler>();
            services.AddTransient<IRequestHandler<UpdateLeadPortionCommand, APIResponse>, UpdateLeadPortionHandler>();
            services.AddTransient<IRequestHandler<DeleteLeadCommand, APIResponse>, DeleteLeadHandler>();
            services.AddTransient<IRequestHandler<DeleteLeadCommand, APIResponse>, DeleteLeadHandler>();

            #endregion

            #region Lead Assign

            services.AddScoped<ISortHelper<LeadAssignResponse>, SortHelper<LeadAssignResponse>>();
            services.AddScoped<IDataShaper<LeadAssignResponse>, DataShaper<LeadAssignResponse>>();
            services.AddTransient<IRequestHandler<GetAllLeadAssignQuery, APIResponse>, GetAllLeadAssignHandler>();
            services.AddTransient<IRequestHandler<GetLeadAssignQuery, APIResponse>, GetLeadAssignHandler>();
            services.AddTransient<IRequestHandler<CreateLeadAssignCommand, APIResponse>, CreateLeadAssignHandler>();
            services.AddTransient<IRequestHandler<UpdateLeadAssignCommand, APIResponse>, UpdateLeadAssignHandler>();
            services.AddTransient<IRequestHandler<DeleteLeadAssignCommand, APIResponse>, DeleteLeadAssignHandler>();

            #endregion

            #region Lead Validation

            services.AddScoped<ISortHelper<LeadValidationResponse>, SortHelper<LeadValidationResponse>>();
            services.AddScoped<IDataShaper<LeadValidationResponse>, DataShaper<LeadValidationResponse>>();
            services.AddTransient<IRequestHandler<GetAllLeadValidationQuery, APIResponse>, GetAllLeadValidationHandler>();
            services.AddTransient<IRequestHandler<GetLeadValidationQuery, APIResponse>, GetLeadValidationHandler>();
            services.AddTransient<IRequestHandler<CreateLeadValidationCommand, APIResponse>, CreateLeadValidationHandler>();
            services.AddTransient<IRequestHandler<UpdateLeadValidationCommand, APIResponse>, UpdateLeadValidationHandler>();
            services.AddTransient<IRequestHandler<DeleteLeadValidationCommand, APIResponse>, DeleteLeadValidationHandler>();

            #endregion

            #region Lead Quote

            services.AddScoped<ISortHelper<LeadQuoteResponse>, SortHelper<LeadQuoteResponse>>();
            services.AddScoped<IDataShaper<LeadQuoteResponse>, DataShaper<LeadQuoteResponse>>();
            services.AddTransient<IRequestHandler<GetAllLeadQuotesQuery, APIResponse>, GetAllLeadQuoteHandler>();
            services.AddTransient<IRequestHandler<GetLeadQuotesQuery, APIResponse>, GetLeadQuoteHandler>();
            services.AddTransient<IRequestHandler<CreateLeadQuoteCommand, APIResponse>, CreateLeadQuoteHandler>();
            services.AddTransient<IRequestHandler<UpdateLeadQuoteCommand, APIResponse>, UpdateLeadQuoteHandler>();
            services.AddTransient<IRequestHandler<DeleteLeadQuoteCommand, APIResponse>, DeleteLeadQuoteHandler>();

            #endregion

            #region Lead Status

            services.AddScoped<ISortHelper<LeadStatusResponse>, SortHelper<LeadStatusResponse>>();
            services.AddScoped<IDataShaper<LeadStatusResponse>, DataShaper<LeadStatusResponse>>();
            services.AddTransient<IRequestHandler<GetAllLeadStatusQuery, APIResponse>, GetAllLeadStatusHandler>();

            #endregion

            #region Lead Count

            services.AddTransient<IRequestHandler<GetAllLeadCountQuery, APIResponse>, GetAllLeadCountHandler>();

            #endregion

            #region Lead TotAmt

            services.AddTransient<IRequestHandler<GetAllLeadTotalAmountQuery, APIResponse>, GetAllLeadTotalAmtHandler>();

            #endregion

            #region LeadId

            services.AddTransient<IRequestHandler<GetLeadIdQuery, APIResponse>, GetLeadIdHandler>();

            #endregion

            return services;
        }
    }
}
