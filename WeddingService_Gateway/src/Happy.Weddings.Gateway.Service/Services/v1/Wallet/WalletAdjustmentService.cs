using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.Config.Wallet;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Wallet.WalletAdjustment;
using Happy.Weddings.Gateway.Core.Infrastructure;
using Happy.Weddings.Gateway.Core.Services.v1.Wallet;
using Happy.Weddings.Gateway.Service.Helpers;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Serilog;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Service.Services.v1.Wallet
{
    /// <summary>
    /// Service implementation for post related operations
    /// </summary>
    public class WalletAdjustmentService : IWalletAdjustmentService
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
        /// Initializes a new instance of the <see cref="WalletAdjustmentService" /> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="distributedCache">The distributed cache.</param>
        /// <param name="servicesConfig">The services configuration.</param>
        /// <param name="logger">The logger.</param>
        public WalletAdjustmentService(
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
        /// Gets the WalletAdjustment.
        /// </summary>
        /// <param name="walletAdjustmentParameter">The WalletAdjustment parameter request.</param>
        /// <returns></returns>
        //public async Task<APIResponse> GetAllWalletAdjustment(WalletAdjustmentParameter walletAdjustmentParameter)
        //{
        //    try
        //    {
        //        string serializedWalletAdjustment;

        //        List<WalletAdjustmentResponse> walletAdjustment;

        //        var encodedWalletAdjustment = await distributedCache.GetAsync(WalletServiceOperation.GetWalletCacheName);

        //        if (encodedWalletAdjustment != null)
        //        {
        //            serializedWalletAdjustment = Encoding.UTF8.GetString(encodedWalletAdjustment);
        //            walletAdjustment = JsonConvert.DeserializeObject<List<WalletAdjustmentResponse>>(serializedWalletAdjustment);
        //        }
        //        else
        //        {
        //            var client = httpClientFactory.CreateClient(WalletServiceOperation.serviceName);

        //            UriBuilder url = new UriBuilder(servicesConfig.Wallet + WalletServiceOperation.GetAllWalletAdjustment());
        //            url.Query = QueryStringHelper.ConvertToQueryString(walletAdjustmentParameter);

        //            var response = await client.GetAsync(url.ToString());
        //            walletAdjustment = JsonConvert.DeserializeObject<List<WalletAdjustmentResponse>>(await response.Content.ReadAsStringAsync());

        //            serializedWalletAdjustment = JsonConvert.SerializeObject(walletAdjustment);
        //            encodedWalletAdjustment = Encoding.UTF8.GetBytes(serializedWalletAdjustment);
        //            var options = new DistributedCacheEntryOptions()
        //                            .SetSlidingExpiration(TimeSpan.FromMinutes(1))
        //                            .SetAbsoluteExpiration(DateTime.Now.AddHours(1));

        //            await distributedCache.SetAsync(WalletServiceOperation.GetWalletCacheName, encodedWalletAdjustment, options);
        //        }

        //        return new APIResponse(walletAdjustment, HttpStatusCode.OK);
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex, "Exception in method 'GetAllWalletAdjustment()'");
        //        var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
        //        return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
        //    }
        //}
        public async Task<APIResponse> GetAllWalletAdjustment(WalletAdjustmentParameter walletAdjustmentParameter)
        {
            try
            {
                var client = httpClientFactory.CreateClient(WalletServiceOperation.serviceName);

                UriBuilder url = new UriBuilder(servicesConfig.Wallet + WalletServiceOperation.GetAllWalletAdjustment());
                url.Query = QueryStringHelper.ConvertToQueryString(walletAdjustmentParameter);
                var response = await client.GetAsync(url.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var walletAdjustment = JsonConvert.DeserializeObject<List<WalletAdjustmentResponse>>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(walletAdjustment, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetAllWalletAdjustment()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Gets the WalletAdjustment.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        public async Task<APIResponse> GetWalletAdjustmentDetails(WalletAdjustmentIdDetails details)
        {
            try
            {
                var client = httpClientFactory.CreateClient(WalletServiceOperation.serviceName);

                var response = await client.GetAsync(servicesConfig.Wallet + WalletServiceOperation.GetWalletAdjustmentDetails(details.WalletAdjustmentId));

                if (response.IsSuccessStatusCode)
                {
                    var walletAdjustment = JsonConvert.DeserializeObject<WalletAdjustmentResponseDetails>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(walletAdjustment, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetWalletAdjustmentDetails()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Creates the WalletAdjustment.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> CreateWalletAdjustment(CreateWalletAdjustmentRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(WalletServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.Wallet + WalletServiceOperation.CreateWalletAdjustment(), contentPost);
                if (response.IsSuccessStatusCode)
                {
                    var wallet = JsonConvert.DeserializeObject<WalletAdjustmentResponse>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(wallet, HttpStatusCode.Created);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateWalletAdjustment()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Updates the WalletAdjustment.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateWalletAdjustment(WalletAdjustmentIdDetails details, UpdateWalletAdjustmentRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(WalletServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.Wallet + WalletServiceOperation.UpdateWalletAdjustment(details.WalletAdjustmentId), contentPost);
                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateWalletAdjustment()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Deletes the WalletAdjustment.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        public async Task<APIResponse> DeleteWalletAdjustment(WalletAdjustmentIdDetails details)
        {
            try
            {
                var client = httpClientFactory.CreateClient(WalletServiceOperation.serviceName);

                var response = await client.DeleteAsync(servicesConfig.Wallet + WalletServiceOperation.DeleteWalletAdjustment(details.WalletAdjustmentId));
                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteWalletAdjustment()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
