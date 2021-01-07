using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.Config.Wallet;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Wallet.WalletDeduction;
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
    public class WalletDeductionService : IWalletDeductionService
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
        public WalletDeductionService(
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
        /// Gets the WalletDeduction.
        /// </summary>
        /// <param name="walletDeductionParameter">The WalletDeduction parameter request.</param>
        /// <returns></returns>
        //public async Task<APIResponse> GetAllWalletDeduction(WalletDeductionParameter walletDeductionParameter)
        //{
        //    try
        //    {
        //        string serializedWalletDeduction;

        //        List<WalletDeductionResponse> walletDeduction;

        //        var encodedWalletDeduction = await distributedCache.GetAsync(WalletServiceOperation.GetWalletCacheName);

        //        if (encodedWalletDeduction != null)
        //        {
        //            serializedWalletDeduction = Encoding.UTF8.GetString(encodedWalletDeduction);
        //            walletDeduction = JsonConvert.DeserializeObject<List<WalletDeductionResponse>>(serializedWalletDeduction);
        //        }
        //        else
        //        {
        //            var client = httpClientFactory.CreateClient(WalletServiceOperation.serviceName);

        //            UriBuilder url = new UriBuilder(servicesConfig.Wallet + WalletServiceOperation.GetAllWalletDeduction());
        //            url.Query = QueryStringHelper.ConvertToQueryString(walletDeductionParameter);

        //            var response = await client.GetAsync(url.ToString());
        //            walletDeduction = JsonConvert.DeserializeObject<List<WalletDeductionResponse>>(await response.Content.ReadAsStringAsync());

        //            serializedWalletDeduction = JsonConvert.SerializeObject(walletDeduction);
        //            encodedWalletDeduction = Encoding.UTF8.GetBytes(serializedWalletDeduction);
        //            var options = new DistributedCacheEntryOptions()
        //                            .SetSlidingExpiration(TimeSpan.FromMinutes(1))
        //                            .SetAbsoluteExpiration(DateTime.Now.AddHours(1));

        //            await distributedCache.SetAsync(WalletServiceOperation.GetWalletCacheName, encodedWalletDeduction, options);
        //        }

        //        return new APIResponse(walletDeduction, HttpStatusCode.OK);
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex, "Exception in method 'GetAllWalletDeduction()'");
        //        var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
        //        return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
        //    }
        //}
        public async Task<APIResponse> GetAllWalletDeduction(WalletDeductionParameter walletDeductionParameter)
        {
            try
            {
                var client = httpClientFactory.CreateClient(WalletServiceOperation.serviceName);

                UriBuilder url = new UriBuilder(servicesConfig.Wallet + WalletServiceOperation.GetAllWalletDeduction());
                url.Query = QueryStringHelper.ConvertToQueryString(walletDeductionParameter);
                var response = await client.GetAsync(url.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var walletDeduction = JsonConvert.DeserializeObject<List<WalletDeductionResponse>>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(walletDeduction, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetAllWalletDeduction()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Gets the WalletDeduction.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        public async Task<APIResponse> GetWalletDeductionDetails(WalletDeductionIdDetails details)
        {
            try
            {
                var client = httpClientFactory.CreateClient(WalletServiceOperation.serviceName);

                var response = await client.GetAsync(servicesConfig.Wallet + WalletServiceOperation.GetWalletDeductionDetails(details.WalletDeductionId));

                if (response.IsSuccessStatusCode)
                {
                    var walletDeduction = JsonConvert.DeserializeObject<WalletDeductionResponseDetails>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(walletDeduction, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetWalletDeductionDetails()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Creates the WalletDeduction.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> CreateWalletDeduction(CreateWalletDeductionRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(WalletServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.Wallet + WalletServiceOperation.CreateWalletDeduction(), contentPost);
                if (response.IsSuccessStatusCode)
                {
                    var walletDeduction = JsonConvert.DeserializeObject<WalletDeductionResponse>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(walletDeduction, HttpStatusCode.Created);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateWalletDeduction()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Updates the WalletDeduction.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateWalletDeduction(WalletDeductionIdDetails details, UpdateWalletDeductionRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(WalletServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.Wallet + WalletServiceOperation.UpdateWalletDeduction(details.WalletDeductionId), contentPost);
                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateWalletDeduction()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Deletes the WalletDeduction.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        public async Task<APIResponse> DeleteWalletDeduction(WalletDeductionIdDetails details)
        {
            try
            {
                var client = httpClientFactory.CreateClient(WalletServiceOperation.serviceName);

                var response = await client.DeleteAsync(servicesConfig.Wallet + WalletServiceOperation.DeleteWalletDeduction(details.WalletDeductionId));
                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteWalletDeduction()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
