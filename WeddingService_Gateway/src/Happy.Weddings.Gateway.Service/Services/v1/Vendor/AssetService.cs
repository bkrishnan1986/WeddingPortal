using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.Config.Vendor;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Responses.Asset;
using Happy.Weddings.Gateway.Core.DTO.Vendor.Asset;
using Happy.Weddings.Gateway.Core.Infrastructure;
using Happy.Weddings.Gateway.Core.Services.v1.Vendor;
using Happy.Weddings.Gateway.Service.Helpers;
using Newtonsoft.Json;
using Serilog;

namespace Happy.Weddings.Gateway.Service.Services.v1.Vendor
{
    public class AssetService : IAssetService
    {
        /// <summary>
        /// The HTTP client factory/
        /// </summary>
        private readonly IHttpClientFactory httpClientFactory;

        /// <summary>
        /// The services configuration
        /// </summary>
        private readonly ServicesConfig servicesConfig;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetService"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="servicesConfig">The services configuration.</param>
        /// <param name="logger">The logger.</param>
        public AssetService(
            IHttpClientFactory httpClientFactory,
            ServicesConfig servicesConfig,
            ILogger logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.servicesConfig = servicesConfig;
            this.logger = logger;
        }

        /// <summary>
        /// Adds the assets.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> AddAssets(AddAssetRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.Vendor + VendorServiceOperation.AddAssets(), contentPost);
                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'AddAssets()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Deletes the asset.
        /// </summary>
        /// <param name="assetId">The asset identifier.</param>
        /// <returns></returns>
        public async Task<APIResponse> DeleteAsset(int assetId)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);
                var response = await client.DeleteAsync(servicesConfig.Identity + VendorServiceOperation.DeleteAsset(assetId));
                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteAsset()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<APIResponse> GetAllAssets(AssetParameters assetParameters)
        {
            try
            {
                string serializedStories;
               // List<AssetResponse> stories;

               /* var encodedStories = await distributedCache.GetAsync(BlogServiceOperation.GetStoriesCacheName);

                if (encodedStories != null)
                {
                    serializedStories = Encoding.UTF8.GetString(encodedStories);
                    stories = JsonConvert.DeserializeObject<List<StoryResponse>>(serializedStories);
                }
                else
                {*/
                    var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                    UriBuilder url = new UriBuilder(servicesConfig.Blog + VendorServiceOperation.GetAllAssets());
                    url.Query = QueryStringHelper.ConvertToQueryString(assetParameters);

                    var response = await client.GetAsync(url.ToString());
                    var assets = JsonConvert.DeserializeObject<AssetResponse>(await response.Content.ReadAsStringAsync());

                    serializedStories = JsonConvert.SerializeObject(assets);
                   /* encodedStories = Encoding.UTF8.GetBytes(serializedStories);
                    var options = new DistributedCacheEntryOptions()
                                    .SetSlidingExpiration(TimeSpan.FromMinutes(1))
                                    .SetAbsoluteExpiration(DateTime.Now.AddHours(1));

                    await distributedCache.SetAsync(VendorServiceOperation.GetStoriesCacheName, encodedStories, options);*/
              //  }

                return new APIResponse(assets, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetAllAssets()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<APIResponse> GetAssetById(int assetId)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);
                var response = await client.GetAsync(servicesConfig.Vendor + VendorServiceOperation.GetAssetById(assetId));

                if (response.IsSuccessStatusCode)
                {
                    var asset = JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(asset, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetAssetById()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Updates the asset.
        /// </summary>
        /// <param name="assetId">The asset identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateAsset(int assetId, UpdateAssetRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.Vendor + 
                    VendorServiceOperation.UpdateAsset(assetId), contentPost);
                if (response.StatusCode == HttpStatusCode.NoContent)
                {

                }

                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateAsset()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
