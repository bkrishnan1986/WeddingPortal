using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.Config.Wallet;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Wallet.Multicode;
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
    public class MulticodeService : IMulticodeService
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
        /// Initializes a new instance of the <see cref="MulticodeService" /> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="distributedCache">The distributed cache.</param>
        /// <param name="servicesConfig">The services configuration.</param>
        /// <param name="logger">The logger.</param>
        public MulticodeService(
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
        /// Gets the Multicode.
        /// </summary>
        /// <param name="multicodeParameter">The Multicode parameter request.</param>
        /// <returns></returns>
        //public async Task<APIResponse> GetAllMultiCodes(MulticodeParameter multicodeParameter)
        //{
        //    try
        //    {
        //        string serializedMulticode;

        //        List<MultiCodeResponse> multicode;

        //        var encodedMulticode = await distributedCache.GetAsync(WalletServiceOperation.GetWalletCacheName);

        //        if (encodedMulticode != null)
        //        {
        //            serializedMulticode = Encoding.UTF8.GetString(encodedMulticode);
        //            multicode = JsonConvert.DeserializeObject<List<MultiCodeResponse>>(serializedMulticode);
        //        }
        //        else
        //        {
        //            var client = httpClientFactory.CreateClient(WalletServiceOperation.serviceName);

        //            UriBuilder url = new UriBuilder(servicesConfig.Wallet + WalletServiceOperation.GetAllMultiCodes());
        //            url.Query = QueryStringHelper.ConvertToQueryString(multicodeParameter);

        //            var response = await client.GetAsync(url.ToString());
        //            multicode = JsonConvert.DeserializeObject<List<MultiCodeResponse>>(await response.Content.ReadAsStringAsync());

        //            serializedMulticode = JsonConvert.SerializeObject(multicode);
        //            encodedMulticode = Encoding.UTF8.GetBytes(serializedMulticode);
        //            var options = new DistributedCacheEntryOptions()
        //                            .SetSlidingExpiration(TimeSpan.FromMinutes(1))
        //                            .SetAbsoluteExpiration(DateTime.Now.AddHours(1));

        //            await distributedCache.SetAsync(WalletServiceOperation.GetWalletCacheName, encodedMulticode, options);
        //        }

        //        return new APIResponse(multicode, HttpStatusCode.OK);

        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex, "Exception in method 'GetAllMultiCodes()'");
        //        var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
        //        return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
        //    }
        //}
        public async Task<APIResponse> GetAllMultiCodes(MulticodeParameter multicodeParameter)
        {
            try
            {
                var client = httpClientFactory.CreateClient(WalletServiceOperation.serviceName);

                UriBuilder url = new UriBuilder(servicesConfig.Wallet + WalletServiceOperation.GetAllMultiCodes());
                url.Query = QueryStringHelper.ConvertToQueryString(multicodeParameter);
                var response = await client.GetAsync(url.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var multicode = JsonConvert.DeserializeObject<List<MultiCodeResponse>>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(multicode, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetAllMultiCodes()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Gets the Multicode.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        public async Task<APIResponse> GetMultiCode(MulticodeIdDetails details)
        {
            try
            {
                var client = httpClientFactory.CreateClient(WalletServiceOperation.serviceName);

                var response = await client.GetAsync(servicesConfig.Wallet + WalletServiceOperation.GetMultiCode(details.Code));

                if (response.IsSuccessStatusCode)
                {
                    var multicode = JsonConvert.DeserializeObject<MulticodeResponseDetails>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(multicode, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetMultiCodeById()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Creates the Multicode.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> CreateMultiCode(CreateMulticodeWalletRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(WalletServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.Wallet + WalletServiceOperation.CreateMultiCode(), contentPost);
                if (response.IsSuccessStatusCode)
                {
                    var multicode = JsonConvert.DeserializeObject<MultiCodeResponse>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(multicode, HttpStatusCode.Created);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateMultiCode()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Updates the Multicode.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateMultiCode(MulticodeIdDetails details, UpdateMulticodeWalletRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(WalletServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.Wallet + WalletServiceOperation.UpdateMultiCode(details.Code), contentPost);
                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateMultiCode()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Deletes the Multicode.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        public async Task<APIResponse> DeleteMultiCode(MulticodeIdDetails details)
        {
            try
            {
                var client = httpClientFactory.CreateClient(WalletServiceOperation.serviceName);

                var response = await client.DeleteAsync(servicesConfig.Wallet + WalletServiceOperation.DeleteMultiCode(details.Code));
                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteMultiCode()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
