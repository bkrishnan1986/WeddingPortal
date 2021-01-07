using Happy.Weddings.Gateway.Core.Config.Vendor;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Responses.Offers;
using Happy.Weddings.Gateway.Core.DTO.Vendor.Offers;
using Happy.Weddings.Gateway.Core.DTO.Vendor.SubscriptionOffers;
using Happy.Weddings.Gateway.Core.Infrastructure;
using Happy.Weddings.Gateway.Core.Services.v1.Vendor;
using Happy.Weddings.Gateway.Service.Helpers;
using Happy.Weddings.Vendor.Core.DTO.Responses.SubscriptionOffers;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Service.Services.v1.Vendor
{
    public class OfferService : IOfferService
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
        /// Initializes a new instance of the <see cref="OfferService"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="servicesConfig">The services configuration.</param>
        /// <param name="logger">The logger.</param>
        public OfferService(
            IHttpClientFactory httpClientFactory,
            ServicesConfig servicesConfig,
            ILogger logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.servicesConfig = servicesConfig;
            this.logger = logger;
        }
        public async Task<APIResponse> CreateOffer(CreateOfferRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.Vendor + VendorServiceOperation.CreateOffer(), contentPost);
                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateOffer()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Creates the subcription offers.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> CreateSubcriptionOffers(CreateSubscriptionOfferRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.Vendor + 
                    VendorServiceOperation.CreateSubcriptionOffers(), contentPost);
                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateSubcriptionOffers()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Deletes the offer.
        /// </summary>
        /// <param name="offerId">The offer identifier.</param>
        /// <returns></returns>
        public async Task<APIResponse> DeleteOffer(int offerId)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);
                var response = await client.DeleteAsync(servicesConfig.Identity + VendorServiceOperation.DeleteOffer(offerId));
                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteOffer()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public Task<APIResponse> DeleteSubcriptionOffers(int subscriptionOffersId)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse> GetOffer(int offerId)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);
                var response = await client.GetAsync(servicesConfig.Vendor + VendorServiceOperation.GetOffer(offerId));

                if (response.IsSuccessStatusCode)
                {
                    var offers = JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(offers, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetOffer()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<APIResponse> GetOffers(OffersParameter offersParameters)
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

                UriBuilder url = new UriBuilder(servicesConfig.Blog + VendorServiceOperation.GetOffers());
                url.Query = QueryStringHelper.ConvertToQueryString(offersParameters);

                var response = await client.GetAsync(url.ToString());
                var offerResponse = JsonConvert.DeserializeObject<OffersResponse>(await response.Content.ReadAsStringAsync());

                serializedStories = JsonConvert.SerializeObject(offerResponse);
                /* encodedStories = Encoding.UTF8.GetBytes(serializedStories);
                 var options = new DistributedCacheEntryOptions()
                                 .SetSlidingExpiration(TimeSpan.FromMinutes(1))
                                 .SetAbsoluteExpiration(DateTime.Now.AddHours(1));

                 await distributedCache.SetAsync(VendorServiceOperation.GetStoriesCacheName, encodedStories, options);
                }*/

                return new APIResponse(offerResponse, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetOffers()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<APIResponse> GetSubcriptionOffer(int subscriptionOffersId)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);
                var response = await client.GetAsync(servicesConfig.Vendor + VendorServiceOperation.GetSubcriptionOffer(subscriptionOffersId));

                if (response.IsSuccessStatusCode)
                {
                    var offers = JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(offers, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetSubcriptionOffer()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<APIResponse> GetSubcriptionOffers(SubscriptionOffersParameter subscriptionOffersParameters)
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

                UriBuilder url = new UriBuilder(servicesConfig.Blog + VendorServiceOperation.GetSubcriptionOffers());
                url.Query = QueryStringHelper.ConvertToQueryString(subscriptionOffersParameters);

                var response = await client.GetAsync(url.ToString());
                var subscriptionOfferResponse = JsonConvert.DeserializeObject<SubscriptionOfferResponse>(await response.Content.ReadAsStringAsync());

                serializedStories = JsonConvert.SerializeObject(subscriptionOfferResponse);
                /* encodedStories = Encoding.UTF8.GetBytes(serializedStories);
                 var options = new DistributedCacheEntryOptions()
                                 .SetSlidingExpiration(TimeSpan.FromMinutes(1))
                                 .SetAbsoluteExpiration(DateTime.Now.AddHours(1));

                 await distributedCache.SetAsync(VendorServiceOperation.GetStoriesCacheName, encodedStories, options);
                }*/

                return new APIResponse(subscriptionOfferResponse, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetSubcriptionOffers()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Updates the offer.
        /// </summary>
        /// <param name="offerId">The offer identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateOffer(int offerId, UpdateOfferRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.Vendor +
                    VendorServiceOperation.UpdateOffer(offerId), contentPost);
                if (response.StatusCode == HttpStatusCode.NoContent)
                {

                }

                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateOffer()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Updates the subcription offers.
        /// </summary>
        /// <param name="subscriptionOffersId">The subscription offers identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateSubcriptionOffers(int subscriptionOffersId, UpdateSubscriptionOfferRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.Vendor +
                    VendorServiceOperation.UpdateSubcriptionOffers(subscriptionOffersId), contentPost);
                if (response.StatusCode == HttpStatusCode.NoContent)
                {

                }

                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateSubcriptionOffers()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
