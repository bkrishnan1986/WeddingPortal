using Happy.Weddings.Gateway.Core.Config.ECommerce;
using Happy.Weddings.Gateway.Core.Config.EventAssistant;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.EventAssistant.Userinvitation;
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
    public class UserInvitationService : IUserinvitationService
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
        public UserInvitationService(
            IHttpClientFactory httpClientFactory,
            ServicesConfig servicesConfig,
            ILogger logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.servicesConfig = servicesConfig;
            this.logger = logger;
        }

        /// <summary>
        /// Creates the userinvitations.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> CreateUserinvitations(CreateUserInvitationListRequest request)
        {


            try
            {
                var client = httpClientFactory.CreateClient(EventAssistantServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.EventAssistant + EventAssistantServiceOperation.CreateUserInvitations(), contentPost);
                if (response.IsSuccessStatusCode)
                {
                    var multicode = JsonConvert.DeserializeObject<UserinvitationResponse>(await response.Content.ReadAsStringAsync());
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
        /// Deletes the userinvitations.
        /// </summary>
        /// <param name="userinvitationId">The userinvitation identifier.</param>
        /// <returns></returns>
        public async Task<APIResponse> DeleteUserinvitations(int userinvitationId)
        {
            try
            {
                var client = httpClientFactory.CreateClient(EventAssistantServiceOperation.serviceName);
                var response = await client.DeleteAsync(servicesConfig.EventAssistant + EventAssistantServiceOperation.DeleteUserInvitations(userinvitationId));
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
        /// Gets the userinvitations.
        /// </summary>
        /// <param name="userinvitationParameters">The userinvitation parameters.</param>
        /// <returns></returns>
        public async Task<APIResponse> GetUserinvitations(UserinvitationParameters userinvitationParameters)
        {
            try
            {
                var client = httpClientFactory.CreateClient(EventAssistantServiceOperation.serviceName);

                UriBuilder url = new UriBuilder(servicesConfig.EventAssistant + EventAssistantServiceOperation.GetUserInvitations());
                url.Query = QueryStringHelper.ConvertToQueryString(userinvitationParameters);

                var response = await client.GetAsync(url.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var multicode = JsonConvert.DeserializeObject<List<UserinvitationResponse>>(await response.Content.ReadAsStringAsync());
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
        /// Gets the userinvitation by identifier.
        /// </summary>
        /// <param name="userinvitationId">The userinvitation identifier.</param>
        /// <returns></returns>
        public async Task<APIResponse> GetUserinvitationById(int userinvitationId)
        {
            try
            {
                var client = httpClientFactory.CreateClient(ECommerceServiceOperation.serviceName);
                var response = await client.GetAsync(servicesConfig.EventAssistant + EventAssistantServiceOperation.GetUserInvitationById(userinvitationId));
                if (response.IsSuccessStatusCode)
                {
                    var multicode = JsonConvert.DeserializeObject<UserinvitationResponse>(await response.Content.ReadAsStringAsync());
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
        /// Updates the userinvitations.
        /// </summary>
        /// <param name="userinvitationId">The userinvitation identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateUserinvitations(int userinvitationId, UpdateUserinvitationRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(EventAssistantServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.EventAssistant + EventAssistantServiceOperation.UpdateUserInvitations(userinvitationId), contentPost);
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
