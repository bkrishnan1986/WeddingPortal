using Happy.Weddings.Identity.Core.Infrastructure;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;

namespace Happy.Weddings.Identity.Infrastructure
{
    public class ConfigurationManager : IConfigurationManager
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationManager"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public ConfigurationManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Get Connection String
        /// </summary>
        public string ConnectionString => configuration.GetConnectionString("Database");

        /// <summary>
        /// Get Application Title
        /// </summary>
        public string Title => configuration["Title"];

        /// <summary>
        /// Get Applciation Version
        /// </summary>
        public string Version => configuration["Version"];

        /// <summary>
        /// Get Applciation URL
        /// </summary>
        public string ApplicationURL => configuration["Environment:ApplicationURL"];

        /// <summary>
        /// Gets the route prefix.
        /// </summary>
        public string RoutePrefix => configuration["Environment:RoutePrefix"];

        /// <summary>
        /// Get Route to Access Swagger
        /// </summary>
        public string SwaggerRoutePrefix => configuration["Environment:SwaggerRoutePrefix"];


        public string WebRootPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot");
    }
}
