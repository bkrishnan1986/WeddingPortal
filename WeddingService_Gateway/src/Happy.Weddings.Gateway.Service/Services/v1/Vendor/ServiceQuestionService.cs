using Happy.Weddings.Gateway.Core.Config.Vendor;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Vendor.ServiceAnswer;
using Happy.Weddings.Gateway.Core.DTO.Vendor.ServiceQuestion;
using Happy.Weddings.Gateway.Core.DTO.Vendor.Vendorquestionanswer;
using Happy.Weddings.Gateway.Core.DTO.Vendor.VendorQuestionAnswer;
using Happy.Weddings.Gateway.Core.DTO.Vendor.VendorQusetionAnswer;
using Happy.Weddings.Gateway.Core.Infrastructure;
using Happy.Weddings.Gateway.Core.Services.v1.Vendor;
using Happy.Weddings.Gateway.Service.Helpers;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Service.Services.v1.Vendor
{
    public class ServiceQuestionService : IServiceQuestionService
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
        public ServiceQuestionService(
            IHttpClientFactory httpClientFactory,
            ServicesConfig servicesConfig,
            ILogger logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.servicesConfig = servicesConfig;
            this.logger = logger;
        }

        public async Task<APIResponse> CreateServiceAnswer(ServiceAnswerRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(servicesConfig.Vendor + VendorServiceOperation.CreateServiceAnswer(), contentPost);
                if (response.IsSuccessStatusCode)
                {
                    var serviceQuestion = JsonConvert.DeserializeObject<List<ServiceAnswerResponse>>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(serviceQuestion, HttpStatusCode.OK);
                }
                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateServiceAnswer()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<APIResponse> CreateServiceQuestion(CreateServiceQuestionRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.Vendor + VendorServiceOperation.CreateServiceQuestion(), contentPost);
                if (response.IsSuccessStatusCode)
                {
                    var serviceQuestion = JsonConvert.DeserializeObject<ServiceQuestionResponse>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(serviceQuestion, HttpStatusCode.OK);
                }
                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateServiceQuestion()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<APIResponse> CreateVendorQuestionAnswer(CreateVendorQuestionAnswerRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);

                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.Vendor + VendorServiceOperation.CreateVendorQuestionAnswer(), contentPost);

                if (response.IsSuccessStatusCode)
                {
                    var vendorQuestionAnswer = JsonConvert.DeserializeObject<List<VendorQuestionAnswerResponse>>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(vendorQuestionAnswer, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateVendorQuestionAnswer()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<APIResponse> DeleteServiceAnswer(int questionId, ServiceAnswerDetails request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);
                var response = await client.DeleteAsync(servicesConfig.Identity + VendorServiceOperation.DeleteServiceAnswer(questionId));
                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteBranch()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<APIResponse> DeleteServiceQuestion(int questionId)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);
                var response = await client.DeleteAsync(servicesConfig.Vendor + VendorServiceOperation.DeleteServiceQuestion(questionId));
                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteBranch()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<APIResponse> GetAllServiceAnswerByServiceQuestion(int serviceQuestionId)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);
                var response = await client.GetAsync(servicesConfig.Vendor + VendorServiceOperation.GetAllServiceAnswerByServiceQuestion(serviceQuestionId));

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

        public async Task<APIResponse> GetAllServiceQuestionsByServiceType(ServiceQuestionParameters serviceQuestionParameters)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                UriBuilder url = new UriBuilder(servicesConfig.Vendor + VendorServiceOperation.GetAllServiceQuestionsByServiceType());
                url.Query = QueryStringHelper.ConvertToQueryString(serviceQuestionParameters);

                var response = await client.GetAsync(url.ToString());
                if (response.IsSuccessStatusCode)
                {
                    var serviceQuestion = JsonConvert.DeserializeObject<List<ServiceQuestionDetailsResponse>>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(serviceQuestion, HttpStatusCode.OK);
                }
                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetAllServiceQuestionsByServiceType()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<APIResponse> GetAllVendorQuestionAnswersById(string Id, bool IsForVendor)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                var response = await client.GetAsync(servicesConfig.Vendor + VendorServiceOperation.GetAllVendorQuestionAnswersById(Id, IsForVendor));

                if (response.IsSuccessStatusCode)
                {
                    var VendorQA = JsonConvert.DeserializeObject<List<VendorQuestionAnswerResponseDetails>>(await response.Content.ReadAsStringAsync());

                    return new APIResponse(VendorQA, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetAllVendorQuestionAnswersById()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<APIResponse> GetServiceAnswersById(int serviceQuestionId, string Id, int serviceAnswerId)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);
                var response = await client.GetAsync(servicesConfig.Vendor + VendorServiceOperation.GetServiceAnswersById(serviceQuestionId, Id, serviceAnswerId));

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

        public async Task<APIResponse> GetServiceQuestionsById(ServiceQuestionServiceTypeParameters serviceQuestionServiceTypeParameters)
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

                UriBuilder url = new UriBuilder(servicesConfig.Vendor + VendorServiceOperation.GetServiceQuestionsById());
                url.Query = QueryStringHelper.ConvertToQueryString(serviceQuestionServiceTypeParameters);

                var response = await client.GetAsync(url.ToString());
                var assets = JsonConvert.DeserializeObject<ServiceQuestionResponse>(await response.Content.ReadAsStringAsync());

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
                logger.Error(ex, "Exception in method 'GetAllBranches()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<APIResponse> UpdateServiceAnswer(int questionId, ServiceAnswerDetails request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.Vendor +
                    VendorServiceOperation.UpdateServiceAnswer(questionId), contentPost);
                if (response.StatusCode == HttpStatusCode.NoContent)
                {

                }

                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateServiceAnswer()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<APIResponse> UpdateServiceQuestion(int questionId, UpdateServiceQuestionRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.Vendor +
                    VendorServiceOperation.UpdateServiceQuestion(questionId), contentPost);
                if (response.StatusCode == HttpStatusCode.NoContent)
                {

                }

                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateServiceQuestion()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<APIResponse> UpdateVendorQuestionAnswer(string vendorleadId, UpdateVendorQusetionAnswerDetailsRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);

                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.Vendor + VendorServiceOperation.UpdateVendorQuestionAnswer(vendorleadId), contentPost);

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateVendorQuestionAnswer()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
