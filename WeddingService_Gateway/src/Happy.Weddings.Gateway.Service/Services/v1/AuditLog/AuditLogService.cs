using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.Config.AuditLog;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.AuditLog.AuditLog;
using Happy.Weddings.Gateway.Core.Infrastructure;
using Happy.Weddings.Gateway.Core.Services.v1.AuditLog;
using Happy.Weddings.Gateway.Service.Helpers;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Serilog;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Service.Services.v1.AuditLog
{
    /// <summary>
    /// Service implementation for post related operations
    /// </summary>
    public class AuditLogService : IAuditLogService
    {
        /// <summary>
        /// The HTTP client factory
        /// </summary>
        private readonly IHttpClientFactory httpClientFactory;

        /// <summary>
        /// The distributed cache
        /// </summary>
        private readonly IDistributedCache distributedCache;

        /// <summary>
        /// The services configuration
        /// </summary>
        private readonly ServicesConfig servicesConfig;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="WalletDeductionService" /> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="distributedCache">The distributed cache.</param>
        /// <param name="servicesConfig">The services configuration.</param>
        /// <param name="logger">The logger.</param>
        public AuditLogService(
            IHttpClientFactory httpClientFactory,
            IDistributedCache distributedCache,
            ServicesConfig servicesConfig,
            ILogger logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.distributedCache = distributedCache;
            this.servicesConfig = servicesConfig;
            this.logger = logger;
        }

        /// <summary>
        /// Gets the AuditLog.
        /// </summary>
        /// <param name="auditLogParameters">The AuditLog parameter request.</param>
        /// <returns></returns>
        public async Task<APIResponse> GetAllAuditLogs(AuditLogParameters auditLogParameters)
        {
            try
            {
                var client = httpClientFactory.CreateClient(AuditLogServiceOperation.serviceName);

                UriBuilder url = new UriBuilder(servicesConfig.AuditLog + AuditLogServiceOperation.GetAllAuditLogs());
                url.Query = QueryStringHelper.ConvertToQueryString(auditLogParameters);
                var response = await client.GetAsync(url.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var auditLog = JsonConvert.DeserializeObject<List<AuditLogResponse>>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(auditLog, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetAllAuditLogs()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Gets the AuditLog.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        public async Task<APIResponse> GetAuditLog(AuditLogIdDetails details)
        {
            try
            {
                var client = httpClientFactory.CreateClient(AuditLogServiceOperation.serviceName);

                var response = await client.GetAsync(servicesConfig.AuditLog + AuditLogServiceOperation.GetAuditLog(details.Id));

                if (response.IsSuccessStatusCode)
                {
                    var auditLog = JsonConvert.DeserializeObject<AuditLogResponseDetails>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(auditLog, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetAuditLog()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Creates the AuditLog.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> CreateAuditLog(CreateAuditLogRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(AuditLogServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.AuditLog + AuditLogServiceOperation.CreateAuditLog(), contentPost);
                if (response.IsSuccessStatusCode)
                {
                    var auditLog = JsonConvert.DeserializeObject<AuditLogResponse>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(auditLog, HttpStatusCode.Created);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateAuditLog()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Updates the AuditLog.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateAuditLog(AuditLogIdDetails details, UpdateAuditLogRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(AuditLogServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.AuditLog + AuditLogServiceOperation.UpdateAuditLog(details.Id), contentPost);
                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateAuditLog()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Deletes the AuditLog.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        public async Task<APIResponse> DeleteAuditLog(AuditLogIdDetails details)
        {
            try
            {
                var client = httpClientFactory.CreateClient(AuditLogServiceOperation.serviceName);

                var response = await client.DeleteAsync(servicesConfig.AuditLog + AuditLogServiceOperation.DeleteAuditLog(details.Id));
                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteAuditLog()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
