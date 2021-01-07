using Happy.Weddings.Gateway.Core.Config.Vendor;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Vendor.ServiceBenefit;
using Happy.Weddings.Gateway.Core.Infrastructure;
using Happy.Weddings.Gateway.Core.Services.v1.Vendor;
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
    public class SubscriptionBenefitService : ISubscriptionBenefitService
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
        /// Initializes a new instance of the <see cref="SubscriptionBenefitService"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="servicesConfig">The services configuration.</param>
        /// <param name="logger">The logger.</param>
        public SubscriptionBenefitService(
            IHttpClientFactory httpClientFactory,
            ServicesConfig servicesConfig,
            ILogger logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.servicesConfig = servicesConfig;
            this.logger = logger;
        }

        /// <summary>
        /// Creates the subcription benefit.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> CreateSubcriptionBenefit(CreateSubscriptionBenefitRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.Vendor +
                    VendorServiceOperation.CreateServiceTopup(), contentPost);
                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateServiceTopup()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Deletes the subcription benefit.
        /// </summary>
        /// <param name="subcriptionbenefitId">The subcriptionbenefit identifier.</param>
        /// <returns></returns>
        public async Task<APIResponse> DeleteSubcriptionBenefit(int subcriptionbenefitId)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);
                var response = await client.DeleteAsync(servicesConfig.Identity +
                    VendorServiceOperation.DeleteSubcriptionBenefit(subcriptionbenefitId));
                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteSubcriptionBenefit()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public Task<APIResponse> GetSubcriptionPlan(int subcriptionBenefitId)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> GetSubcriptionPlans(SubscriptionBenefitsParameter subscriptionBenefitsParameters)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the subcription benefit.
        /// </summary>
        /// <param name="subcriptionbenefitId">The subcriptionbenefit identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateSubcriptionBenefit(int subcriptionbenefitId, UpdateSubscriptionBenefitRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.Vendor +
                    VendorServiceOperation.UpdateSubcriptionBenefit(subcriptionbenefitId), contentPost);
                if (response.StatusCode == HttpStatusCode.NoContent)
                {

                }

                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateSubcriptionBenefit()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
