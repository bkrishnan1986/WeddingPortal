using Happy.Weddings.Gateway.Core.Config.Vendor;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Vendor.ProfilePicture;
using Happy.Weddings.Gateway.Core.Infrastructure;
using Happy.Weddings.Gateway.Core.Services.v1.Vendor;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Service.Services.v1.Vendor
{
    public class ProfileService : IProfileService
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
        public ProfileService(
            IHttpClientFactory httpClientFactory,
            ServicesConfig servicesConfig,
            ILogger logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.servicesConfig = servicesConfig;
            this.logger = logger;
        }

        public async Task<APIResponse> CreateCategoryDetails(CreateCategoryDetailsRequest request)
        {
            try
            {
                string filename = "";
                var folderName = Path.Combine("Profilepics");
                var pathToSave = Path.Combine("D:", "HappyWedding", folderName);

                if (request.UploadProfilePicture != null)
                {
                    foreach (var item in request.UploadProfilePicture)
                    {
                        request.ProfilePictures = new List<ProfilePictures>();
                        if (item.Length > 0)
                        {
                            string format = System.IO.Path.GetExtension(item.FileName);
                            filename = request.VendorId + "_ProfilePicture_" + DateTime.Now + format;
                            string filenme = filename.Replace(":", ".");
                            var filePath = Path.Combine(pathToSave, filenme);
                            using var fileStream = new FileStream(filePath, FileMode.Create);
                            item.CopyTo(fileStream);
                            request.ProfilePictures.Add(new ProfilePictures { ProfilePicturePath = filePath });
                        }
                    }
                    request.UploadProfilePicture = null;
                }

                if (request.ProfileImage != null)
                {
                    var profilePicture = request.ProfileImage;
                    if (profilePicture.Length > 0)
                    {
                        string format = System.IO.Path.GetExtension(profilePicture.FileName);
                        filename = request.VendorId + "_ProfilePicture_" + DateTime.Now + format;
                        string filenme = filename.Replace(":", ".");
                        var filePath = Path.Combine(pathToSave, filenme);
                        using var fileStream = new FileStream(filePath, FileMode.Create);
                        profilePicture.CopyTo(fileStream);
                        request.ProfilePicture = filePath;
                    }
                    request.ProfileImage = null;
                }

                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);
                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(servicesConfig.Vendor + VendorServiceOperation.CreateCategoryDetails(), contentPost);
                if(response.IsSuccessStatusCode)
                {

                    var profilecategory = JsonConvert.DeserializeObject<CategoryDetailsResponse>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(profilecategory, HttpStatusCode.Created);
                }
                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateCategoryDetails()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<APIResponse> UpdateCategoryDetails(int categoryId, UpdateCategoryDetailsRequest request)
        {
            try
            {
                string filename = "";
                var folderName = Path.Combine("Profilepics");
                var pathToSave = Path.Combine("D:", "HappyWedding", folderName);
         
                if (request.UploadProfilePicture != null)
                {
                    foreach (var item in request.UploadProfilePicture)
                    {
                        request.ProfilePictureS = new List<ProfilePictureS>();
                        if (item.Length > 0)
                        {
                            string format = System.IO.Path.GetExtension(item.FileName);
                            filename = request.VendorId + "_ProfilePicture_" + DateTime.Now + format;
                            string filenme = filename.Replace(":", ".");
                            var filePath = Path.Combine(pathToSave, filenme);
                            using var fileStream = new FileStream(filePath, FileMode.Create);
                            item.CopyTo(fileStream);
                            request.ProfilePictureS.Add(new ProfilePictureS { ProfilePicturePath = filePath });
                        }
                    }
                    request.UploadProfilePicture = null;
                }

                if (request.ProfileImage != null)
                {
                    var profilePicture = request.ProfileImage;
                    if (profilePicture.Length > 0)
                    {
                        string format = System.IO.Path.GetExtension(profilePicture.FileName);
                        filename = request.VendorId + "_ProfilePicture_" + DateTime.Now + format;
                        string filenme = filename.Replace(":", ".");
                        var filePath = Path.Combine(pathToSave, filenme);
                        using var fileStream = new FileStream(filePath, FileMode.Create);
                        profilePicture.CopyTo(fileStream);
                        request.ProfilePicture = filePath;
                    }
                    request.ProfileImage = null;
                }

                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.Vendor +
                    VendorServiceOperation.UpdateCategoryDetails(categoryId), contentPost);
                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateCategoryDetails()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<APIResponse> GetCategoryDetailsByVendorId(string vendorId)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);      
                var response = await client.GetAsync(servicesConfig.Vendor + VendorServiceOperation.GetCategoryDetailsByVendorId(vendorId));
                if (response.IsSuccessStatusCode)
                {   
                    var categoryResponses = JsonConvert.DeserializeObject<List<CategoryResponse>>(await response.Content.ReadAsStringAsync());
                   
                    foreach (var item in categoryResponses)
                    {
                        var categoryPicture = item.ProfileImage;
                        byte[] b = System.IO.File.ReadAllBytes(item.ProfilePicture);
                        item.ProfilePicture = Convert.ToBase64String(b);

                        var profilepicture = item.ProfilePictures;
                        foreach (var item1 in profilepicture)
                        {
                            byte[] b1 = System.IO.File.ReadAllBytes(item1.ProfilePicturePath);
                            item1.ProfilePicturePath = Convert.ToBase64String(b1);
                        }
                    }
                    return new APIResponse(categoryResponses, HttpStatusCode.OK);
                }
                return new APIResponse(response.StatusCode);

            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetCategoryDetailsByVendorId()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }                                                 
    }
}
