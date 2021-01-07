using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.Config.Wallet;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Wallet.Wallet;
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
    public class WalletService : IWalletService
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
        /// Initializes a new instance of the <see cref="WalletService" /> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="distributedCache">The distributed cache.</param>
        /// <param name="servicesConfig">The services configuration.</param>
        /// <param name="logger">The logger.</param>
        public WalletService(
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
        /// Gets the Wallet.
        /// </summary>
        /// <param name="walletParameter">The Wallet parameter request.</param>
        /// <returns></returns>
        //public async Task<APIResponse> GetAllWallets(WalletParameter walletParameter)
        //{
        //    try
        //    {
        //        string serializedWallet;

        //        List<WalletResponse> wallet;

        //        var encodedWallet = await distributedCache.GetAsync(WalletServiceOperation.GetWalletCacheName);

        //        if (encodedWallet != null)
        //        {
        //            serializedWallet = Encoding.UTF8.GetString(encodedWallet);
        //            wallet = JsonConvert.DeserializeObject<List<WalletResponse>>(serializedWallet);
        //        }
        //        else
        //        {
        //            var client = httpClientFactory.CreateClient(WalletServiceOperation.serviceName);

        //            UriBuilder url = new UriBuilder(servicesConfig.Wallet + WalletServiceOperation.GetAllWallets());
        //            url.Query = QueryStringHelper.ConvertToQueryString(walletParameter);

        //            var response = await client.GetAsync(url.ToString());
        //            wallet = JsonConvert.DeserializeObject<List<WalletResponse>>(await response.Content.ReadAsStringAsync());

        //            serializedWallet = JsonConvert.SerializeObject(wallet);
        //            encodedWallet = Encoding.UTF8.GetBytes(serializedWallet);
        //            var options = new DistributedCacheEntryOptions()
        //                            .SetSlidingExpiration(TimeSpan.FromMinutes(1))
        //                            .SetAbsoluteExpiration(DateTime.Now.AddHours(1));

        //            await distributedCache.SetAsync(WalletServiceOperation.GetWalletCacheName, encodedWallet, options);
        //        }

        //        return new APIResponse(wallet, HttpStatusCode.OK);

        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex, "Exception in method 'GetAllWallets()'");
        //        var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
        //        return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
        //    }
        //}
        public async Task<APIResponse> GetAllWallets(WalletParameter walletParameter)
        {
            try
            {
                var client = httpClientFactory.CreateClient(WalletServiceOperation.serviceName);

                UriBuilder url = new UriBuilder(servicesConfig.Wallet + WalletServiceOperation.GetAllWallets());
                url.Query = QueryStringHelper.ConvertToQueryString(walletParameter);
                var response = await client.GetAsync(url.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var wallet = JsonConvert.DeserializeObject<List<WalletResponse>>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(wallet, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetAllWallets()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Gets the Wallet.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        public async Task<APIResponse> GetWalletDetails(WalletIdDetails details)
        {
            try
            {
                var client = httpClientFactory.CreateClient(WalletServiceOperation.serviceName);

                var response = await client.GetAsync(servicesConfig.Wallet + WalletServiceOperation.GetWalletDetails(details.WalletId));

                if (response.IsSuccessStatusCode)
                {
                    var wallet = JsonConvert.DeserializeObject<WalletResponseDetails>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(wallet, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetWalletDetails()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Creates the Wallet.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> CreateWallet(CreateWalletRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(WalletServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.Wallet + WalletServiceOperation.CreateWallet(), contentPost);
                if (response.IsSuccessStatusCode)
                {
                    var wallet = JsonConvert.DeserializeObject<WalletResponse>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(wallet, HttpStatusCode.Created);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateWallet()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Updates the Wallet.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateWallet(WalletIdDetails details, UpdateWalletRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(WalletServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.Wallet + WalletServiceOperation.UpdateWallet(details.WalletId, details.IsPaused, details.IsReleased, details.IsChurned), contentPost);
                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateWallet()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Deletes the Wallet.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        public async Task<APIResponse> DeleteWallet(WalletIdDetails details)
        {
            try
            {
                var client = httpClientFactory.CreateClient(WalletServiceOperation.serviceName);

                var response = await client.DeleteAsync(servicesConfig.Wallet + WalletServiceOperation.DeleteWallet(details.WalletId));
                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteWallet()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
