using Happy.Weddings.Identity.Core.Infrastructure.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Happy.Weddings.Identity.API.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class Authorization
    {
        private static IWebHostEnvironment environment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="hostingEnvironment"></param>
        /// <returns></returns>
        public static IServiceCollection CreateAuthorization(this IServiceCollection services, IConfiguration configuration,
            IWebHostEnvironment hostingEnvironment)
        {
            environment = hostingEnvironment;

            var authConfig = configuration.GetSection("AuthorizationConfig").Get<AuthorizationConfig>();
            authConfig.SetKeyFilePassword(configuration.GetSection("AuthorizationConfig")["KeyFilePassword"]);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                            .AddJwtBearer(options =>
                            {
                                options.TokenValidationParameters = new TokenValidationParameters
                                {
                                    ValidateIssuer = true,
                                    ValidateAudience = true,
                                    ValidateLifetime = true,
                                    ValidateIssuerSigningKey = true,
                                    ValidIssuer = authConfig.Issuer,
                                    ValidAudience = authConfig.Audience,
                                    IssuerSigningKey = GetKey(authConfig.CertificatePath),
                                    ClockSkew = TimeSpan.Zero
                                };
                            });
            return services;
        }
        private static X509SecurityKey GetKey(string keyFilePath)
        {
            X509Certificate2 certificate;
            var certificatePath = environment.WebRootPath + keyFilePath;
            certificate = new X509Certificate2(certificatePath);
            return new X509SecurityKey(certificate);
        }
    }
}
