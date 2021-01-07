using Happy.Weddings.Gateway.Core.Config.Vendor;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Vendor.ReviewComments;
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
    public class ReviewCommentService : IReviewCommentService
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
        /// Initializes a new instance of the <see cref="ReviewCommentService"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="servicesConfig">The services configuration.</param>
        /// <param name="logger">The logger.</param>
        public ReviewCommentService(
            IHttpClientFactory httpClientFactory,
            ServicesConfig servicesConfig,
            ILogger logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.servicesConfig = servicesConfig;
            this.logger = logger;
        }

        /// <summary>
        /// Creates the comment reply.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> CreateCommentReply(CreateCommentReplyRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.Identity + VendorServiceOperation.CreateCommentReply(), contentPost);
                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateCommentReply()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Creates the review.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> CreateReview(CreateReviewRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.Vendor + VendorServiceOperation.CreateReview(), contentPost);
                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateReview()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Deletes the comment reply.
        /// </summary>
        /// <param name="commentReplyId">The comment reply identifier.</param>
        /// <returns></returns>
        public async Task<APIResponse> DeleteCommentReply(int commentReplyId)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);
                var response = await client.DeleteAsync(servicesConfig.Identity + VendorServiceOperation.DeleteCommentReply(commentReplyId));
                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteCommentReply()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Deletes the review.
        /// </summary>
        /// <param name="reviewId">The review identifier.</param>
        /// <returns></returns>
        public async Task<APIResponse> DeleteReview(int reviewId)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);
                var response = await client.DeleteAsync(servicesConfig.Identity + VendorServiceOperation.DeleteReview(reviewId));
                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteReview()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<APIResponse> GetCommentReplies(CommentReplyParameter commentReplyParameter)
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

                UriBuilder url = new UriBuilder(servicesConfig.Blog + VendorServiceOperation.GetReviews());
                url.Query = QueryStringHelper.ConvertToQueryString(commentReplyParameter);

                var response = await client.GetAsync(url.ToString());
                var reviewResponse = JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());

                serializedStories = JsonConvert.SerializeObject(reviewResponse);
                /* encodedStories = Encoding.UTF8.GetBytes(serializedStories);
                 var options = new DistributedCacheEntryOptions()
                                 .SetSlidingExpiration(TimeSpan.FromMinutes(1))
                                 .SetAbsoluteExpiration(DateTime.Now.AddHours(1));

                 await distributedCache.SetAsync(VendorServiceOperation.GetStoriesCacheName, encodedStories, options);
                }*/

                return new APIResponse(reviewResponse, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetReviews()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<APIResponse> GetCommentReply(int commentreplyId, ReplyCountParameter replyCountParameter)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);
                var response = await client.GetAsync(servicesConfig.Vendor + VendorServiceOperation.GetCommentReply(commentreplyId));

                if (response.IsSuccessStatusCode)
                {
                    var reviews = JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(reviews, HttpStatusCode.OK);
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

        public async Task<APIResponse> GetReview(int reviewId)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);
                var response = await client.GetAsync(servicesConfig.Vendor + VendorServiceOperation.GetReview(reviewId));

                if (response.IsSuccessStatusCode)
                {
                    var reviews = JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(reviews, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetReview()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<APIResponse> GetReviews(ReviewsParameter reviewsParameter)
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

                UriBuilder url = new UriBuilder(servicesConfig.Blog + VendorServiceOperation.GetReviews());
                url.Query = QueryStringHelper.ConvertToQueryString(reviewsParameter);

                var response = await client.GetAsync(url.ToString());
                var reviewResponse = JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());

                serializedStories = JsonConvert.SerializeObject(reviewResponse);
                /* encodedStories = Encoding.UTF8.GetBytes(serializedStories);
                 var options = new DistributedCacheEntryOptions()
                                 .SetSlidingExpiration(TimeSpan.FromMinutes(1))
                                 .SetAbsoluteExpiration(DateTime.Now.AddHours(1));

                 await distributedCache.SetAsync(VendorServiceOperation.GetStoriesCacheName, encodedStories, options);
                }*/

                return new APIResponse(reviewResponse, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetReviews()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Updates the comment reply.
        /// </summary>
        /// <param name="commentreplyId">The commentreply identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateCommentReply(int commentreplyId, UpdateCommentReplyRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.Vendor +
                    VendorServiceOperation.UpdateCommentReply(commentreplyId), contentPost);
                if (response.StatusCode == HttpStatusCode.NoContent)
                {

                }

                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateCommentReply()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Updates the review.
        /// </summary>
        /// <param name="reviewId">The review identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateReview(int reviewId, UpdateReviewRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.Vendor +
                    VendorServiceOperation.UpdateReview(reviewId), contentPost);
                if (response.StatusCode == HttpStatusCode.NoContent)
                {

                }

                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateReview()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
