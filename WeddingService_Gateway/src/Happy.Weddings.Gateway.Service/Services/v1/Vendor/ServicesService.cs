using Happy.Weddings.Gateway.Core.Config.Vendor;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Vendor.Service;
using Happy.Weddings.Gateway.Core.Infrastructure;
using Happy.Weddings.Gateway.Core.Services.v1.Vendor;
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

namespace Happy.Weddings.Gateway.Service.Services.v1.Vendor
{
    public class ServicesService : IServicesService
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
        /// Initializes a new instance of the <see cref="ServicesService"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="servicesConfig">The services configuration.</param>
        /// <param name="logger">The logger.</param>
        public ServicesService(
            IHttpClientFactory httpClientFactory,
            ServicesConfig servicesConfig,
            ILogger logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.servicesConfig = servicesConfig;
            this.logger = logger;
        }

        /// <summary>
        /// Adds the service.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> AddService(AddServicesRequests request)
        {
            try
            {
                string filename = "";
                var folderName = Path.Combine("Service");
                var pathToSave = Path.Combine("D:", "HappyWedding", folderName);

                foreach(var item in request.AddServicesRequestList)
                {
                    if (item.Photo.Length > 0)
                    {
                        string format = System.IO.Path.GetExtension(item.Photo.FileName);
                        filename = item.VendorId + "_Service_" + DateTime.Now + format;
                        string filenme = filename.Replace(":", ".");
                        var filePath = Path.Combine(pathToSave, filenme);
                        using var fileStream = new FileStream(filePath, FileMode.Create);
                        item.Photo.CopyTo(fileStream);
                        item.PhotoPath = filePath;
                        item.PhotoPath = null;
                    }
                }

                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.Vendor + VendorServiceOperation.AddService(), contentPost);
                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'AddService()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Deletes the service.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns></returns>
        public async Task<APIResponse> DeleteService(int serviceId)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);
                var response = await client.DeleteAsync(servicesConfig.Identity + VendorServiceOperation.DeleteService(serviceId));
                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteService()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<APIResponse> GetAllServices(ServicesParameters serviceParameters)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                UriBuilder url = new UriBuilder(servicesConfig.Vendor + VendorServiceOperation.GetAllServices());
                url.Query = QueryStringHelper.ConvertToQueryString(serviceParameters);

                var response = await client.GetAsync(url.ToString());
                if (response.IsSuccessStatusCode)
                {
                    var branch = JsonConvert.DeserializeObject<List<ServiceDetailsResponse>>(await response.Content.ReadAsStringAsync());
                    foreach (var item1 in branch)
                    {
                        byte[] b = System.IO.File.ReadAllBytes(item1.PhotoPath);
                        item1.PhotoPath = Convert.ToBase64String(b);
                    }
                    
                    return new APIResponse(branch, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetAllBranches()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public Task<APIResponse> GetServiceOfferedByServiceId(int serviceId)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse> GetServicesofVendor(string vendorId)
        {
            try
            {
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);
                var response = await client.GetAsync(servicesConfig.Vendor + VendorServiceOperation.GetServicesofVendor(vendorId));
                if (response.IsSuccessStatusCode)
                {
                    var serviceQuestion = JsonConvert.DeserializeObject<List<ServiceDetailsResponse>>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(serviceQuestion, HttpStatusCode.OK);
                }
                return new APIResponse(response.StatusCode);

            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetServicesofVendor()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public Task<APIResponse> SearchServices(SearchParameters searchParameters)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the service.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateService(int serviceId, UpdateServiceRequest request)
        {
            try
            {
                string filename = "";
                var folderName = Path.Combine("Service");
                var pathToSave = Path.Combine("D:", "HappyWedding", folderName);          
                    if (request.Photo.Length > 0)
                    {
                        string format = System.IO.Path.GetExtension(request.Photo.FileName);
                        filename = request.VendorId + "_Service_" + DateTime.Now + format;
                        string filenme = filename.Replace(":", ".");
                        var filePath = Path.Combine(pathToSave, filenme);
                        using var fileStream = new FileStream(filePath, FileMode.Create);
                        request.Photo.CopyTo(fileStream);
                        request.PhotoPath = filePath;
                        request.PhotoPath = null;
                    }
                var client = httpClientFactory.CreateClient(VendorServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.Vendor +
                    VendorServiceOperation.UpdateService(serviceId), contentPost);
                if (response.StatusCode == HttpStatusCode.NoContent)
                {

                }

                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateService()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
