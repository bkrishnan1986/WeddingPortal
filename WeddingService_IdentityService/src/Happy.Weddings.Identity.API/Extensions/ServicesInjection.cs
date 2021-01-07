using System;
using MediatR;
using Serilog;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Happy.Weddings.Identity.Core.Helpers;
using Happy.Weddings.Identity.Infrastructure;
using Happy.Weddings.Identity.Data.Repository;
using Happy.Weddings.Identity.Core.Repository;
using Happy.Weddings.Identity.Service.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Happy.Weddings.Identity.Core.DTO.Responses;
using Happy.Weddings.Identity.Core.Infrastructure;
using Happy.Weddings.Identity.Data.DatabaseContext;
using Happy.Weddings.Identity.Core.DTO.Responses.Role;
using Happy.Weddings.Identity.Core.DTO.Responses.Profile;
using Happy.Weddings.Identity.Service.Commands.v1.Profile;
using Happy.Weddings.Identity.Service.Handlers.v1.Profile;
using Happy.Weddings.Identity.Service.Queries.v1.Profile;
using Happy.Weddings.Identity.Service.Queries.v1.Account;
using Happy.Weddings.Identity.Service.Handlers.v1.Account;
using Happy.Weddings.Identity.Service.Commands.v1.Account;
using Happy.Weddings.Identity.Core.Infrastructure.Authorization;
using Happy.Weddings.Identity.Service.Queries.v1.MultiDetail;
using Happy.Weddings.Identity.Service.Handlers.v1.MultiDetail;
using Happy.Weddings.Identity.Service.Commands.v1.MultiDetail;
using Happy.Weddings.Identity.Service.Queries.v1.MultiCode;
using Happy.Weddings.Identity.Service.Handlers.v1.MultiCode;
using Happy.Weddings.Identity.Service.Commands.v1.MultiCode;
using Happy.Weddings.Identity.Core.DTO.Responses.MultiCode;
using Happy.Weddings.Identity.Core.DTO.Responses.MultiDetail;
using Happy.Weddings.Identity.Core.Services.Providers;
using Happy.Weddings.Identity.Service.Services.Providers;
using Happy.Weddings.Identity.Core.DTO.Responses.KYCDetail;
using Happy.Weddings.Identity.Service.Handlers.v1.KYCDetail;
using Happy.Weddings.Identity.Service.Commands.v1.KYCDetail;
using Happy.Weddings.Identity.Service.Queries.v1.KYCDetail;
using Happy.Weddings.Identity.Core.DTO.Responses.UserRole;
using System.ComponentModel.Design;
using Happy.Weddings.Identity.Service.Commands.v1.UserRole;
using Happy.Weddings.Identity.Service.Handlers.v1.UserRole;
using Happy.Weddings.Identity.Service.Queries.v1.UserRole;

namespace Happy.Weddings.Identity.API.Extensions
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

            var authorizationConfig = configuration.GetSection("AuthorizationConfig").Get<AuthorizationConfig>();
            authorizationConfig.SetKeyFilePassword(configuration.GetSection("AuthorizationConfig")["KeyFilePassword"]);

            services.AddSingleton(Log.Logger);
            services.AddSingleton(HostingEnvironment);
            services.AddSingleton(rabbitMQConfig);

            services.AddSingleton(authorizationConfig);

            services.AddDbContext<IdentityContext>(options =>
                 options.UseMySQL(configuration.GetConnectionString("Database")));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddMediatR(typeof(Startup));
           
            services.AddTransient<IConfigurationManager, ConfigurationManager>();

            services.AddScoped<ISortHelper<ProfileResponse>, SortHelper<ProfileResponse>>();
            services.AddScoped<IDataShaper<ProfileResponse>, DataShaper<ProfileResponse>>();
            services.AddScoped<IDataShaper<Core.Entity.Profile>, DataShaper<Core.Entity.Profile>>();

            services.AddScoped<ISortHelper<RoleResponse>, SortHelper<RoleResponse>>();
            services.AddScoped<IDataShaper<RoleResponse>, DataShaper<RoleResponse>>();
            services.AddScoped<IDataShaper<Core.Entity.Profile>, DataShaper<Core.Entity.Profile>>();

            #region profile

            services.AddTransient<IConfigurationManager, ConfigurationManager>();
            services.AddTransient<IRequestHandler<CreateUserProfileCommand, APIResponse>, CreateUserProfileHandler>();
            services.AddTransient<IRequestHandler<UpdateUserProfileCommand, APIResponse>, UpdateUserProfileHandler>();
            services.AddTransient<IRequestHandler<DeleteUserProfileCommand, APIResponse>, DeleteUserProfileHandler>();
            services.AddTransient<IRequestHandler<GetAllUserProfilesQuery, APIResponse>, GetAllUserProfilesHandler>();
            services.AddTransient<IRequestHandler<GetUserProfileQuery, APIResponse>, GetUserProfileHandler>();
            services.AddTransient<IRequestHandler<UpdateUserProfilePortionCommand, APIResponse>, UpdateUserProfilePortionHandler>();

            #endregion

            #region Role

            #endregion

            #region Login

            services.AddTransient<IRequestHandler<GetAccountDetailsQuery, APIResponse>, GetAccountDetailsQueryHandler>();
            services.AddTransient<IRequestHandler<UpdateAccountPortionCommand, APIResponse>, UpdateAccountsPortionHandler>();

            #endregion

            #region Multicode

            services.AddScoped<ISortHelper<MultiCodeResponse>, SortHelper<MultiCodeResponse>> ();
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


            services.AddScoped<ISortHelper<KYCDataResponse>, SortHelper<KYCDataResponse>>();
            services.AddScoped<IDataShaper<KYCDataResponse>, DataShaper<KYCDataResponse>>();
            services.AddTransient<IRequestHandler<CreateKYCDataCommand, APIResponse>, CreateKYCDataHandler>();
            services.AddScoped<ISortHelper<KYCDetailResponse>, SortHelper<KYCDetailResponse>>();
            services.AddScoped<IDataShaper<KYCDetailResponse>, DataShaper<KYCDetailResponse>>();
            services.AddTransient<IRequestHandler<UpdateKYCDataCommand, APIResponse>, UpdateKYCDetailHandler>();
            services.AddTransient<IRequestHandler<GetKYCDataQuery, APIResponse>, GetKYCDataHandler>();
            services.AddTransient<IRequestHandler<UpdateKYCPortionCommand, APIResponse>, UpdateKYCPortionHandler>();

            services.AddScoped<ISortHelper<UserRoleResponse>, SortHelper<UserRoleResponse>>();
            services.AddScoped<IDataShaper<UserRoleResponse>, DataShaper<UserRoleResponse>>();
            services.AddTransient<IRequestHandler<CreateUserRoleCommand, APIResponse>, CreateUserRoleHandler>();
            services.AddTransient<IRequestHandler<UpdateUserRoleCommand, APIResponse>, UpdateUserRoleHandler>();
            services.AddTransient<IRequestHandler<DeleteUserRoleCommand, APIResponse>, DeleteUserRoleHandler>();
            services.AddTransient<IRequestHandler<GetAllUserRolesQuery, APIResponse>, GetAllUserRolesHandler>();
            services.AddTransient<IRequestHandler<GetUserRoleQuery, APIResponse>, GetUserRoleHandler>();
            services.AddTransient<IRequestHandler<GetUserIdQuery, APIResponse>, GetUserIdHandler>();

            services.AddTransient<IRequestHandler<SendOtpCommand, APIResponse>, SendOtpHandler>();
            services.AddTransient<IRequestHandler<VerifyOtpCommand, APIResponse>, VerifyOtpHandler>();

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            services.AddScoped<ITokenProvider, TokenProvider>();

            return services;
        }
    }
}
