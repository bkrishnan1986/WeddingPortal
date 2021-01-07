using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.Config.Blog;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Blog.Review;
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
    public class ReviewService : IReviewService
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
        /// Initializes a new instance of the <see cref="ReviewService" /> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="distributedCache">The distributed cache.</param>
        /// <param name="servicesConfig">The services configuration.</param>
        /// <param name="logger">The logger.</param>
        public ReviewService(
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
        /// Gets the Review.
        /// </summary>
        /// <param name="reviewParametersRequest">The Review parameters request.</param>
        /// <returns></returns>
        public async Task<APIResponse> GetReviews(ReviewParametersRequest reviewParametersRequest)
        {
            try
            {
                var client = httpClientFactory.CreateClient(BlogServiceOperation.serviceName);

                UriBuilder url = new UriBuilder(servicesConfig.Blog + BlogServiceOperation.GetReviews());
                url.Query = QueryStringHelper.ConvertToQueryString(reviewParametersRequest);

                var response = await client.GetAsync(url.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var reviews = JsonConvert.DeserializeObject<List<ReviewResponse>>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(reviews, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetReviews()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Gets the Review.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        public async Task<APIResponse> GetReview(ReviewIdDetails details)
        {
            try
            {
                var client = httpClientFactory.CreateClient(BlogServiceOperation.serviceName);
                var response = await client.GetAsync(servicesConfig.Blog + BlogServiceOperation.GetReview(details.ReviewId));

                if (response.IsSuccessStatusCode)
                {
                    //var review = JsonConvert.DeserializeObject<ReviewResponseDetails>(await response.Content.ReadAsStringAsync());
                    var review = JsonConvert.DeserializeObject<ReviewResponse>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(review, HttpStatusCode.OK);
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

        /// <summary>
        /// Creates the Review.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> CreateReview(CreateReviewBlogRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(BlogServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.Blog + BlogServiceOperation.CreateReview(), contentPost);

                if (response.IsSuccessStatusCode)
                {
                    var story = JsonConvert.DeserializeObject<ReviewResponse>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(story, HttpStatusCode.Created);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateReview()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Updates the Review.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateReview(ReviewIdDetails details, UpdateReviewBlogRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(BlogServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.Blog + BlogServiceOperation.UpdateReview(details.ReviewId), contentPost);
                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateReview()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Deletes the Review.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        public async Task<APIResponse> DeleteReview(ReviewIdDetails details)
        {
            try
            {
                var client = httpClientFactory.CreateClient(BlogServiceOperation.serviceName);

                var response = await client.DeleteAsync(servicesConfig.Blog + BlogServiceOperation.DeleteReview(details.ReviewId));
                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteReview()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
