﻿using Happy.Weddings.Gateway.Core.Config.ECommerce;
using Happy.Weddings.Gateway.Core.Config.EventAssistant;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.EventAssistant.Budgeter;
using Happy.Weddings.Gateway.Core.Infrastructure;
using Happy.Weddings.Gateway.Core.Services.v1.EventAssistant;
using Happy.Weddings.Gateway.Service.Helpers;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Service.Services.v1.EventAssistant
{
    public class BudgeterService : IBudgeterService
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
        /// Initializes a new instance of the <see cref="CartService"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="servicesConfig">The services configuration.</param>
        /// <param name="logger">The logger.</param>
        public BudgeterService(
            IHttpClientFactory httpClientFactory,
            ServicesConfig servicesConfig,
            ILogger logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.servicesConfig = servicesConfig;
            this.logger = logger;
        }

        /// <summary>
        /// Creates the budgeters.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> CreateBudgeters(CreateBudgeterRequest request)
        {


            try
            {
                var client = httpClientFactory.CreateClient(EventAssistantServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.EventAssistant + EventAssistantServiceOperation.CreateBugeters(), contentPost);
                if (response.IsSuccessStatusCode)
                {
                    var multicode = JsonConvert.DeserializeObject<BudgeterResponse>(await response.Content.ReadAsStringAsync());
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
        /// Deletes the budgeters.
        /// </summary>
        /// <param name="budgeterId">The budgeter identifier.</param>
        /// <returns></returns>
        public async Task<APIResponse> DeleteBudgeters(int budgeterId)
        {
            try
            {
                var client = httpClientFactory.CreateClient(EventAssistantServiceOperation.serviceName);
                var response = await client.DeleteAsync(servicesConfig.EventAssistant + EventAssistantServiceOperation.DeleteBudgeters(budgeterId));
                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteBranch()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Gets the budgeters.
        /// </summary>
        /// <param name="orderParameters">The order parameters.</param>
        /// <returns></returns>
        public async Task<APIResponse> GetBudgeters(BudgeterParameters orderParameters)
        {
            try
            {
                var client = httpClientFactory.CreateClient(EventAssistantServiceOperation.serviceName);

                UriBuilder url = new UriBuilder(servicesConfig.EventAssistant + EventAssistantServiceOperation.GetBudgeters());
                url.Query = QueryStringHelper.ConvertToQueryString(orderParameters);

                var response = await client.GetAsync(url.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var multicode = JsonConvert.DeserializeObject<List<BudgeterResponse>>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(multicode, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetMultiDetails()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Gets the budgeter by identifier.
        /// </summary>
        /// <param name="budgeterId">The budgeter identifier.</param>
        /// <returns></returns>
        public async Task<APIResponse> GetBudgeterById(int budgeterId)
        {
            try
            {
                var client = httpClientFactory.CreateClient(ECommerceServiceOperation.serviceName);
                var response = await client.GetAsync(servicesConfig.EventAssistant + EventAssistantServiceOperation.GetBudgeterById(budgeterId));
                if (response.IsSuccessStatusCode)
                {
                    var multicode = JsonConvert.DeserializeObject<BudgeterResponse>(await response.Content.ReadAsStringAsync());
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
        /// Updates the budgeters.
        /// </summary>
        /// <param name="budgeterId">The budgeter identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateBudgeters(int budgeterId, UpdateBudgeterRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(ECommerceServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.EventAssistant + EventAssistantServiceOperation.UpdateBudgeters(budgeterId), contentPost);
                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateBranch()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

    }
}
