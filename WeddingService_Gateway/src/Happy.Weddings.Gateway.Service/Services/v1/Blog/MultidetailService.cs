﻿using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.Config.Blog;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Blog.Multidetail;
using Happy.Weddings.Gateway.Core.Infrastructure;
using Happy.Weddings.Gateway.Core.Services.v1.Blog;
using Happy.Weddings.Gateway.Service.Helpers;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Serilog;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Service.Services.v1.Blog
{
    /// <summary>
    /// Service implementation for post related operations
    /// </summary>
    public class MultidetailService : IMultidetailService
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
        /// Initializes a new instance of the <see cref="MultidetailService" /> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="distributedCache">The distributed cache.</param>
        /// <param name="servicesConfig">The services configuration.</param>
        /// <param name="logger">The logger.</param>
        public MultidetailService(
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
        /// Gets the Multidetail.
        /// </summary>
        /// <param name="multidetailParameter">The Multidetail parameter request.</param>
        /// <returns></returns>
        public async Task<APIResponse> GetAllMultiDetails(MultidetailParameter multidetailParameter)
        {
            try
            {
                var client = httpClientFactory.CreateClient(BlogServiceOperation.serviceName);

                UriBuilder url = new UriBuilder(servicesConfig.Blog + BlogServiceOperation.GetAllMultiDetails());
                url.Query = QueryStringHelper.ConvertToQueryString(multidetailParameter);
                var response = await client.GetAsync(url.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var multidetail = JsonConvert.DeserializeObject<List<MultidetailResponse>>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(multidetail, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetAllMultiDetails()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Gets the Multidetail.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        public async Task<APIResponse> GetMultiDetailsById(MulticodeIdDetails details)
        {
            try
            {
                var client = httpClientFactory.CreateClient(BlogServiceOperation.serviceName);

                var response = await client.GetAsync(servicesConfig.Blog + BlogServiceOperation.GetMultiDetailsById(details.MulticodeId));

                if (response.IsSuccessStatusCode)
                {
                    //var multidetail = JsonConvert.DeserializeObject<List<MultidetailResponse>>(await response.Content.ReadAsStringAsync());
                    var multidetail = JsonConvert.DeserializeObject<List<MultidetailResponseDetails>>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(multidetail, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetMultiDetailsById()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Creates the Multidetail.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> CreateMultiDetails(CreateMultidetailBlogRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(BlogServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.Blog + BlogServiceOperation.CreateMultiDetails(), contentPost);

                if (response.IsSuccessStatusCode)
                {
                    var multidetail = JsonConvert.DeserializeObject<MultidetailResponse>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(multidetail, HttpStatusCode.Created);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateMultiDetails()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Updates the Multidetail.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateMultiDetails(MultidetailIdDetails details, UpdateMultidetailBlogRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(BlogServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.Blog + BlogServiceOperation.UpdateMultiDetails(details.MultidetailId), contentPost);
                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateMultiDetails()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Deletes the Multidetail.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        public async Task<APIResponse> DeleteMultiDetails(MultidetailIdDetails details)
        {
            try
            {
                var client = httpClientFactory.CreateClient(BlogServiceOperation.serviceName);

                var response = await client.DeleteAsync(servicesConfig.Blog + BlogServiceOperation.DeleteMultiDetails(details.MultidetailId));
                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteMultiDetails()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
