using Happy.Weddings.Gateway.Core.Config.Vendor;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Vendor.Topup;
using Happy.Weddings.Gateway.Core.DTO.Vendor.TopupBenefit;
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
    public class TopupService : ITopupService
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
        /// Initializes a new instance of the <see cref="TopupService"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="servicesConfig">The services configuration.</param>
        /// <param name="logger">The logger.</param>
        public TopupService(
            IHttpClientFactory httpClientFactory,
            ServicesConfig servicesConfig,
            ILogger logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.servicesConfig = servicesConfig;
            this.logger = logger;
        }

        /// <summary>
        /// Creates the top up.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> CreateTopUp(CreateTopUpRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.Vendor +
                    VendorServiceOperation.CreateTopUp(), contentPost);
                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateTopUp()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Creates the top up benefit.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> CreateTopUpBenefit(CreateTopUpBenefitRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.Vendor +
                    VendorServiceOperation.CreateTopUpBenefit(), contentPost);
                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateTopUpBenefit()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Deletes the top up.
        /// </summary>
        /// <param name="topupId">The topup identifier.</param>
        /// <returns></returns>
        public async Task<APIResponse> DeleteTopUp(int topupId)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);
                var response = await client.DeleteAsync(servicesConfig.Identity +
                    VendorServiceOperation.DeleteTopUp(topupId));
                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteTopUp()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public Task<APIResponse> GetTopupBenefitById(int topupbenefitId)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> GetTopUpBenefits(TopUpBenefitParameter topupBenefitsParameters)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> GetTopUpById(int topupId)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> GetTopUps(TopUpParameter topupsParameters)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the top up.
        /// </summary>
        /// <param name="topupId">The topup identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateTopUp(int topupId, UpdateTopUpRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.Vendor +
                    VendorServiceOperation.UpdateTopUp(topupId), contentPost);
                if (response.StatusCode == HttpStatusCode.NoContent)
                {

                }

                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateTopUp()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Updates the top up benefit.
        /// </summary>
        /// <param name="topupId">The topup identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateTopUpBenefit(int topupId, UpdateTopUpBenefitRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.Vendor +
                    VendorServiceOperation.UpdateTopUpBenefit(topupId), contentPost);
                if (response.StatusCode == HttpStatusCode.NoContent)
                {

                }

                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateTopUpBenefit()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
