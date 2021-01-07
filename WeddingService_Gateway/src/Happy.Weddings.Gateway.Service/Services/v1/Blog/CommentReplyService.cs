﻿using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.Config.Blog;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Blog.CommentReply;
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
    public class CommentReplyService : ICommentReplyService
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
        /// Initializes a new instance of the <see cref="CommentReplyService" /> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="distributedCache">The distributed cache.</param>
        /// <param name="servicesConfig">The services configuration.</param>
        /// <param name="logger">The logger.</param>
        public CommentReplyService(
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
        /// Gets the CommentReply.
        /// </summary>
        /// <param name="commentReplyParametersRequest">The CommentReply parameters request.</param>
        /// <returns></returns>
        public async Task<APIResponse> GetCommentReplies(CommentReplyParametersRequest commentReplyParametersRequest)
        {
            try
            {
                var client = httpClientFactory.CreateClient(BlogServiceOperation.serviceName);

                UriBuilder url = new UriBuilder(servicesConfig.Blog + BlogServiceOperation.GetCommentReplies());
                url.Query = QueryStringHelper.ConvertToQueryString(commentReplyParametersRequest);

                var response = await client.GetAsync(url.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var commentReply = JsonConvert.DeserializeObject<List<CommentReplyResponse>>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(commentReply, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetCommentReplies()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Gets the CommentReply.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        public async Task<APIResponse> GetCommentReply(CommentReplyIdDetails details)
        {
            try
            {
                var client = httpClientFactory.CreateClient(BlogServiceOperation.serviceName);
                var response = await client.GetAsync(servicesConfig.Blog + BlogServiceOperation.GetCommentReply(details.CommentReplyId));

                if (response.IsSuccessStatusCode)
                {
                    //var review = JsonConvert.DeserializeObject<CommentReplyResponseDetails>(await response.Content.ReadAsStringAsync());
                    var review = JsonConvert.DeserializeObject<CommentReplyResponse>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(review, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetCommentReply()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Creates the CommentReply.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> CreateCommentReply(CreateCommentReplyBlogRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(BlogServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.Blog + BlogServiceOperation.CreateCommentReply(), contentPost);

                if (response.IsSuccessStatusCode)
                {
                    var commentReply = JsonConvert.DeserializeObject<CommentReplyResponse>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(commentReply, HttpStatusCode.Created);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateCommentReply()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Updates the CommentReply.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateCommentReply(CommentReplyIdDetails details, UpdateCommentReplyBlogRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(BlogServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.Blog + BlogServiceOperation.UpdateCommentReply(details.CommentReplyId), contentPost);
                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateCommentReply()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Deletes the CommentReply.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        public async Task<APIResponse> DeleteCommentReply(CommentReplyIdDetails details)
        {
            try
            {
                var client = httpClientFactory.CreateClient(BlogServiceOperation.serviceName);

                var response = await client.DeleteAsync(servicesConfig.Blog + BlogServiceOperation.DeleteCommentReply(details.CommentReplyId));
                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteCommentReply()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
