using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.Config.Vendor;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Responses.EventGallery;
using Happy.Weddings.Gateway.Core.DTO.Vendor.EventGallery;
using Happy.Weddings.Gateway.Core.Infrastructure;
using Happy.Weddings.Gateway.Core.Services.v1.Vendor;
using Happy.Weddings.Gateway.Service.Helpers;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Happy.Weddings.Gateway.Service.Services.v1.Vendor
{
    public class EventGalleryService : IEventGalleryService
    {
        /// <summary>
        /// The HTTP client factory
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
        /// Initializes a new instance of the <see cref="EventService"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="servicesConfig">The services configuration.</param>
        /// <param name="logger">The logger.</param>
        public EventGalleryService(
            IHttpClientFactory httpClientFactory,
            ServicesConfig servicesConfig,
            ILogger logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.servicesConfig = servicesConfig;
            this.logger = logger;
        }

        public async Task<APIResponse> GetEventGalleryByVendorId(EventGalleryParameters eventGalleryParameters)
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

                UriBuilder url = new UriBuilder(servicesConfig.Blog + VendorServiceOperation.GetEventsByCondition());
                url.Query = QueryStringHelper.ConvertToQueryString(eventGalleryParameters);

                var response = await client.GetAsync(url.ToString());
                var eventResponse = JsonConvert.DeserializeObject<List<EventGalleryResponse>>(await response.Content.ReadAsStringAsync());
                foreach (var item1 in eventResponse)
                {
                    byte[] b = System.IO.File.ReadAllBytes(item1.CoverPhoto);
                    item1.CoverPhoto = Convert.ToBase64String(b);
                }
                serializedStories = JsonConvert.SerializeObject(eventResponse);
                /* encodedStories = Encoding.UTF8.GetBytes(serializedStories);
                 var options = new DistributedCacheEntryOptions()
                                 .SetSlidingExpiration(TimeSpan.FromMinutes(1))
                                 .SetAbsoluteExpiration(DateTime.Now.AddHours(1));

                 await distributedCache.SetAsync(VendorServiceOperation.GetStoriesCacheName, encodedStories, options);
                }*/

                return new APIResponse(eventResponse, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
              //  logger.Error(ex, "Exception in method 'GetEventGalleryByVendorId()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
