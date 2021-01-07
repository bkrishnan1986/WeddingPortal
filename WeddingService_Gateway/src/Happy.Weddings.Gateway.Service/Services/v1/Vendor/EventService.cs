using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.Config.Vendor;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Responses.Event;
using Happy.Weddings.Gateway.Core.DTO.Vendor.Event;
using Happy.Weddings.Gateway.Core.Infrastructure;
using Happy.Weddings.Gateway.Core.Services.v1.Vendor;
using Happy.Weddings.Gateway.Service.Helpers;
using Newtonsoft.Json;
using Serilog;

namespace Happy.Weddings.Gateway.Service.Services.v1.Vendor
{
    public class EventService : IEventService
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
        public EventService(
            IHttpClientFactory httpClientFactory,
            ServicesConfig servicesConfig,
            ILogger logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.servicesConfig = servicesConfig;
            this.logger = logger;
        }

        /// <summary>
        /// Creates the event.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> CreateEvent(CreateEventRequest request)
        {
            {
                try
                {
                    string filename = "";
                    var folderName = Path.Combine("Events");
                    var pathToSave = Path.Combine("D:", "HappyWedding", folderName);

                    if (request.CoverPhotos.Length > 0)
                    {
                        string format = System.IO.Path.GetExtension(request.CoverPhotos.FileName);
                        filename = request.VendorId + "_Event_" + DateTime.Now + format;
                        string filenme = filename.Replace(":", ".");
                        var filePath = Path.Combine(pathToSave, filenme);
                        using var fileStream = new FileStream(filePath, FileMode.Create);
                        request.CoverPhotos.CopyTo(fileStream);
                        request.CoverPhoto = filePath;
                        request.CoverPhoto = null;
                    }

                    var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                    var param = JsonConvert.SerializeObject(request);
                    HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(servicesConfig.Vendor + VendorServiceOperation.CreateEvent(), contentPost);
                    var userprofile = JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(userprofile, HttpStatusCode.Created);
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Exception in method 'CreateUser()'");
                    var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
                }
            }
        }


            /// <summary>
            /// Deletes the event.
            /// </summary>
            /// <param name="eventId">The event identifier.</param>
            /// <returns></returns>
            public async Task<APIResponse> DeleteEvent(int eventId)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);
                var response = await client.DeleteAsync(servicesConfig.Identity + VendorServiceOperation.DeleteEvent(eventId));
                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteEvent()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<APIResponse> GetEventsByCondition(EventParameters eventParameters)
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

                UriBuilder url = new UriBuilder(servicesConfig.Vendor + VendorServiceOperation.GetEventsByCondition());
                url.Query = QueryStringHelper.ConvertToQueryString(eventParameters);

                var response = await client.GetAsync(url.ToString());
                var eventResponse = JsonConvert.DeserializeObject<List<EventResponse>>(await response.Content.ReadAsStringAsync());
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
                logger.Error(ex, "Exception in method 'GetEventDetailsById()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<APIResponse> GetEventById(int eventId)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);
                var response = await client.GetAsync(servicesConfig.Vendor + VendorServiceOperation.GetEventById(eventId));

                if (response.IsSuccessStatusCode)
                {
                    var events = JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(events, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetEventById()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<APIResponse> GetEventDetailsById(EventVendorParameters eventVendorParameters)
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

                UriBuilder url = new UriBuilder(servicesConfig.Blog + VendorServiceOperation.GetEventDetailsById());
                url.Query = QueryStringHelper.ConvertToQueryString(eventVendorParameters);

                var response = await client.GetAsync(url.ToString());
                var eventResponse = JsonConvert.DeserializeObject<EventResponse>(await response.Content.ReadAsStringAsync());

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
                logger.Error(ex, "Exception in method 'GetEventDetailsById()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Updates the event.
        /// </summary>
        /// <param name="eventId">The event identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateEvent(int eventId, UpdateEventRequest request)
        {
            try
            {
                string filename = "";
                var folderName = Path.Combine("Events");
                var pathToSave = Path.Combine("D:", "HappyWedding", folderName);

                if (request.CoverPhotos.Length > 0)
                {
                    string format = System.IO.Path.GetExtension(request.CoverPhotos.FileName);
                    filename = request.VendorId + "_Event_" + DateTime.Now + format;
                    string filenme = filename.Replace(":", ".");
                    var filePath = Path.Combine(pathToSave, filenme);
                    using var fileStream = new FileStream(filePath, FileMode.Create);
                    request.CoverPhotos.CopyTo(fileStream);
                    request.CoverPhoto = filePath;
                    request.CoverPhoto = null;
                }

                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.Vendor +
                    VendorServiceOperation.UpdateEvent(eventId), contentPost);
                if (response.StatusCode == HttpStatusCode.NoContent)
                {

                }

                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateEvent()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
