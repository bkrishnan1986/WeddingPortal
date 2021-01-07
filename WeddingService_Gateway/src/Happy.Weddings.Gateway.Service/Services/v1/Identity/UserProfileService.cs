using Happy.Weddings.Gateway.Core.Config.Identity;
using Happy.Weddings.Gateway.Core.Domain.Identity;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Identity;
using Happy.Weddings.Gateway.Core.DTO.Identity.Profile;
using Happy.Weddings.Gateway.Core.Infrastructure;
using Happy.Weddings.Gateway.Core.Messaging.Sender.v1.Identity;
using Happy.Weddings.Gateway.Core.Services.v1.Identity;
using Happy.Weddings.Gateway.Service.Helpers;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Service.Services.v1.Identity
{
    /// <summary>
    /// Service implementation for user related operations
    /// </summary>
    public class UserProfileService : IUserProfileService
    {
        /// <summary>
        /// The username update sender
        /// </summary>
        private readonly IUsernameUpdateSender usernameUpdateSender;

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
        /// Initializes a new instance of the <see cref="StoryService" /> class.
        /// </summary>
        /// <param name="usernameUpdateSender">The username update sender.</param>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="servicesConfig">The services configuration.</param>
        /// <param name="logger">The logger.</param>
        public UserProfileService(
            IUsernameUpdateSender usernameUpdateSender,
            IHttpClientFactory httpClientFactory,
            ServicesConfig servicesConfig,
            ILogger logger)
        {
            this.usernameUpdateSender = usernameUpdateSender;
            this.httpClientFactory = httpClientFactory;
            this.servicesConfig = servicesConfig;
            this.logger = logger;
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns></returns>
        public async Task<APIResponse> GetUserProfiles(UserProfileParameters profileParameters)
        {
            try
            {
                var client = httpClientFactory.CreateClient(IdentityServiceOperation.serviceName);

                UriBuilder url = new UriBuilder(servicesConfig.Vendor + IdentityServiceOperation.GetUsers());
                url.Query = QueryStringHelper.ConvertToQueryString(profileParameters);

                var response = await client.GetAsync(url.ToString());
                if (response.IsSuccessStatusCode)
                {
                    var profiles = JsonConvert.DeserializeObject<List<ProfileResponse>>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(profiles, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetUsers()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        public async Task<APIResponse> GetUserProfile(ProfileIdDetails details)
        {
            try
            {
                var client = httpClientFactory.CreateClient(IdentityServiceOperation.serviceName);
                var response = await client.GetAsync(servicesConfig.Identity + IdentityServiceOperation.GetUser(details.ProfileId));
                if (response.IsSuccessStatusCode)
                {
                    var userProfile = JsonConvert.DeserializeObject<ProfileResponse>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(userProfile, HttpStatusCode.OK);
                }
                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetUser()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> CreateUserProfile(CreateUserProfileRequest request)
        {
            try
            {
                string filename = "";
                var folderName = Path.Combine("UserProfiles");
                var pathToSave = Path.Combine("D:", "HappyWedding", folderName);

               if (request.ProfilePhoto.Length > 0)
               {
                    string format = System.IO.Path.GetExtension(request.ProfilePhoto.FileName);
                    filename = request.UserId + "_UserProfiles_" + DateTime.Now + format;
                    string filenme = filename.Replace(":", ".");
                    var filePath = Path.Combine(pathToSave, filenme);
                    using var fileStream = new FileStream(filePath, FileMode.Create);
                    request.ProfilePhoto.CopyTo(fileStream);
                    request.Photo = filePath;
                    request.ProfilePhoto = null;
                }

                var client = httpClientFactory.CreateClient(IdentityServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.Identity + IdentityServiceOperation.CreateUser(), contentPost);
                var userprofile = JsonConvert.DeserializeObject<UserIdDetails>(await response.Content.ReadAsStringAsync());
                return new APIResponse(userprofile, HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateUser()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateUserProfile(ProfileIdDetails details, UpdateUserProfileRequest request)
        {
            try
            {
                string filename = "";
                var folderName = Path.Combine("UserProfiles");
                var pathToSave = Path.Combine("D:", "HappyWedding", folderName);

                if (request.ProfilePhoto.Length > 0)
                {
                    string format = System.IO.Path.GetExtension(request.ProfilePhoto.FileName);
                    filename = request.UserId + "_UserProfiles_" + DateTime.Now + format;
                    string filenme = filename.Replace(":", ".");
                    var filePath = Path.Combine(pathToSave, filenme);
                    using var fileStream = new FileStream(filePath, FileMode.Create);
                    request.ProfilePhoto.CopyTo(fileStream);
                    request.Photo = filePath;
                    request.ProfilePhoto = null;
                }

                var client = httpClientFactory.CreateClient(IdentityServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.Identity + IdentityServiceOperation.UpdateUser(details.ProfileId), contentPost);
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    var user = new User { Id = details.ProfileId, FirstName = request.FirstName, LastName = request.LastName };
                    usernameUpdateSender.SendUserName(user);
                }

                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateUser()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        public async Task<APIResponse> DeleteUserProfile(ProfileIdDetails details)
        {
            try
            {
                var client = httpClientFactory.CreateClient(IdentityServiceOperation.serviceName);
                var response = await client.DeleteAsync(servicesConfig.Identity + IdentityServiceOperation.DeleteUser(details.ProfileId));
                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteUser()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<APIResponse> GetUserId(UserIdParameters idParameters)
        {
            try
            {
                var client = httpClientFactory.CreateClient(IdentityServiceOperation.serviceName);

                UriBuilder url = new UriBuilder(servicesConfig.Vendor + IdentityServiceOperation.GetUserId());
                url.Query = QueryStringHelper.ConvertToQueryString(idParameters);

                var response = await client.GetAsync(url.ToString());
                if (response.IsSuccessStatusCode)
                {
                    var id = JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(id, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetUsers()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Sends the otp.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> SendOtp(ProfileIdDetails details,SendOtpRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(IdentityServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.Identity + IdentityServiceOperation.SendOtp(details.ProfileId), contentPost);
                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'SendOtp()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Verifies the otp.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> VerifyOtp(ProfileIdDetails details,VerifyOtpRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(IdentityServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.Identity + IdentityServiceOperation.VerifyOtp(details.ProfileId), contentPost);
                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'VerifyOtp()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
