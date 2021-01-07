using Happy.Weddings.Gateway.Core.Config.ECommerce;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.ECommerce.Product;
using Happy.Weddings.Gateway.Core.Infrastructure;
using Happy.Weddings.Gateway.Core.Services.v1.ECommerce;
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

namespace Happy.Weddings.Gateway.Service.Services.v1.ECommerce
{
    public class ProductService : IProductService
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
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="servicesConfig">The services configuration.</param>
        /// <param name="logger">The logger.</param>
        public ProductService(
            IHttpClientFactory httpClientFactory,
            ServicesConfig servicesConfig,
            ILogger logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.servicesConfig = servicesConfig;
            this.logger = logger;
        }

        public async Task<APIResponse> CreateProducts(CreateProductsRequest request)
        {


            try
            {
                string filename = "";
                var folderName = Path.Combine("Products");
                var pathToSave = Path.Combine("D:", "HappyWedding", folderName);

                if (request.ProductImage.Length > 0)
                {
                    string format = System.IO.Path.GetExtension(request.ProductImage.FileName);
                    filename = request.CategoryId + "_Products_" + DateTime.Now + format;
                    string filenme = filename.Replace(":", ".");
                    var filePath = Path.Combine(pathToSave, filenme);
                    using var fileStream = new FileStream(filePath, FileMode.Create);
                    request.ProductImage.CopyTo(fileStream);
                    request.Image = filePath;
                    request.Image = null;
                }
                var client = httpClientFactory.CreateClient(ECommerceServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.ECommerce + ECommerceServiceOperation.CreateProduct(), contentPost);
                if (response.IsSuccessStatusCode)
                {
                    var multicode = JsonConvert.DeserializeObject<ProductResponse>(await response.Content.ReadAsStringAsync());
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

        public async Task<APIResponse> DeleteProducts(int productId)
        {
            try
            {
                var client = httpClientFactory.CreateClient(ECommerceServiceOperation.serviceName);
                var response = await client.DeleteAsync(servicesConfig.ECommerce + ECommerceServiceOperation.DeleteProduct(productId));
                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteBranch()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<APIResponse> GetProducts(ProductParameters cartParameters)
        {
            try
            {
                var client = httpClientFactory.CreateClient(ECommerceServiceOperation.serviceName);

                UriBuilder url = new UriBuilder(servicesConfig.ECommerce + ECommerceServiceOperation.GetProducts());
                url.Query = QueryStringHelper.ConvertToQueryString(cartParameters);

                var response = await client.GetAsync(url.ToString());


                if (response.IsSuccessStatusCode)
                {
                    var products = JsonConvert.DeserializeObject<List<ProductResponse>>(await response.Content.ReadAsStringAsync());
                    foreach (var item1 in products)
                    {
                        byte[] b = System.IO.File.ReadAllBytes(item1.Image);
                        item1.Image = Convert.ToBase64String(b);
                    }
                    return new APIResponse(products, HttpStatusCode.OK);
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
        /// Gets the multi details by identifier.
        /// </summary>
        /// <param name="multicodeId">The multicode identifier.</param>
        /// <returns></returns>
        public async Task<APIResponse> GetProductById(int productId)
        {
            try
            {
                var client = httpClientFactory.CreateClient(ECommerceServiceOperation.serviceName);
                var response = await client.GetAsync(servicesConfig.ECommerce + ECommerceServiceOperation.GetProductById(productId));
                if (response.IsSuccessStatusCode)
                {
                    var multicode = JsonConvert.DeserializeObject<ProductResponse>(await response.Content.ReadAsStringAsync());
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
        /// Updates the multi details.
        /// </summary>
        /// <param name="productId">The multidetail identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateProducts(int productId, UpdateProductRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(ECommerceServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.ECommerce + ECommerceServiceOperation.UpdateProduct(productId), contentPost);
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
