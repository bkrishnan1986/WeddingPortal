using Happy.Weddings.Gateway.Core.Config.Identity;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Identity.KYCData;
using Happy.Weddings.Gateway.Core.DTO.Identity.KYCDetail;
using Happy.Weddings.Gateway.Core.Infrastructure;
using Happy.Weddings.Gateway.Core.Services.v1.Identity;
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
    public class KYCDetailsService : IKYCDetailsService
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
        /// Initializes a new instance of the <see cref="KYCDetailsService"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="servicesConfig">The services configuration.</param>
        /// <param name="logger">The logger.</param>
        public KYCDetailsService(
            IHttpClientFactory httpClientFactory,
            ServicesConfig servicesConfig,
            ILogger logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.servicesConfig = servicesConfig;
            this.logger = logger;
        }

        /// <summary>
        /// Creates the kyc data.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> CreateKYCData(int profileId, CreateKYCDataRequest request)
        {
            try
            {
                string filename = "";
                var folderName = Path.Combine("KYCData");
                var pathToSave = Path.Combine("D:", "HappyWedding", folderName);

                foreach (var item in request.KYCData)
                {
                    if (item.Kycdoc != null)
                    {
                        item.KYCDetails = new List<Core.DTO.Identity.KYCData.KYCDetails>();
                        foreach (var kycPic in item.Kycdoc)
                        {
                            if (kycPic.Length > 0)
                            {
                                string format = System.IO.Path.GetExtension(kycPic.FileName);
                                filename = profileId + "_Kycdoc_" + DateTime.Now + format;
                                string filenme = filename.Replace(":", ".");
                                var filePath = Path.Combine(pathToSave, filenme);
                                using var fileStream = new FileStream(filePath, FileMode.Create);
                                kycPic.CopyTo(fileStream);
                                item.KYCDetails.Add(new Core.DTO.Identity.KYCData.KYCDetails { KycdocPath = filePath });
                            }
                        }
                        item.Kycdoc = null;
                    }
                    if (item.Proofdocument != null)
                    {
                        item.KYCDetails = new List<Core.DTO.Identity.KYCData.KYCDetails>();
                        foreach (var kycPic in item.Proofdocument)
                        {
                            if (kycPic.Length > 0)
                            {
                                string format = System.IO.Path.GetExtension(kycPic.FileName);
                                filename = profileId + "_Proofdocument_" + DateTime.Now + format;
                                string filenme = filename.Replace(":", ".");
                                var filePath = Path.Combine(pathToSave, filenme);
                                using var fileStream = new FileStream(filePath, FileMode.Create);
                                kycPic.CopyTo(fileStream);
                                item.KYCDetails.Add(new Core.DTO.Identity.KYCData.KYCDetails { KycdocPath = filePath });
                            }
                        }
                        item.Proofdocument = null;
                    }
                    if (item.Gstdocument != null)
                    {
                        item.GSTDetails = new List<Core.DTO.Identity.KYCData.GSTDetails>();

                        var gst = JsonConvert.DeserializeObject<Core.DTO.Identity.KYCData.GSTDetails>(item.GSTDetailString);
                        foreach (var kycPic in item.Gstdocument)
                        {
                            if (kycPic.Length > 0)
                            {

                                string format = System.IO.Path.GetExtension(kycPic.FileName);
                                filename = profileId + "_Gstdocument_" + DateTime.Now + format;
                                string filenme = filename.Replace(":", ".");
                                var filePath = Path.Combine(pathToSave, filenme);
                                using var fileStream = new FileStream(filePath, FileMode.Create);
                                kycPic.CopyTo(fileStream);
                                item.GSTDetails.Add(new Core.DTO.Identity.KYCData.GSTDetails
                                {
                                    Address = gst.Address,
                                    BusinessName = gst.BusinessName,
                                    Gstcity = gst.Gstcity,
                                    Gstnumber = gst.Gstnumber,
                                    Gststate = gst.Gststate,
                                    Gstdocument = filePath
                                });
                            }
                        }
                        item.Gstdocument = null;
                    }

                }
                var client = httpClientFactory.CreateClient(IdentityServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.Identity + IdentityServiceOperation.CreateKYCData(profileId), contentPost);
                var kycdetails = JsonConvert.DeserializeObject<KYCDetailResponse>(await response.Content.ReadAsStringAsync());
                return new APIResponse(kycdetails, HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateKYCData()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Gets the kyc datas.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns></returns>
        public async Task<APIResponse> GetKYCDatas(int profileId)
        {
            try
            {
                var client = httpClientFactory.CreateClient(IdentityServiceOperation.serviceName);
                var response = await client.GetAsync(servicesConfig.Identity + IdentityServiceOperation.GetKYCDatas(profileId));
                if (response.IsSuccessStatusCode)
                {
                    var kYCDetailResponses = JsonConvert.DeserializeObject<List<KYCDetailResponse>>(await response.Content.ReadAsStringAsync());

                    foreach (var item in kYCDetailResponses)
                    {
                        var kycDoc = item.Kycdetails;
                        foreach (var item1 in kycDoc)
                        {
                            byte[] b = System.IO.File.ReadAllBytes(item1.KycdocPath);
                            item1.KycdocPath = Convert.ToBase64String(b);
                        }
                    }
                    return new APIResponse(kYCDetailResponses, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetKYCDatas()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Updates the kyc data.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateKYCData(int profileId, UpdateKYCDataRequest request)
        {
            try
            {
                string filename = "";
                var folderName = Path.Combine("KYCData");
                var pathToSave = Path.Combine("D:", "HappyWedding", folderName);

                foreach (var item in request.UpdateData)
                {
                    if (item.Kycdoc != null)
                    {
                        item.KYCDetails = new List<Core.DTO.Identity.KYCData.UpdateKYCDetails>();
                        foreach (var kycPic in item.Kycdoc)
                        {
                            if (kycPic.Length > 0)
                            {
                                string format = System.IO.Path.GetExtension(kycPic.FileName);
                                filename = profileId + "_KYCDOC_" + DateTime.Now + format;
                                string filenme = filename.Replace(":", ".");
                                var filePath = Path.Combine(pathToSave, filenme);
                                using var fileStream = new FileStream(filePath, FileMode.Create);
                                kycPic.CopyTo(fileStream);
                              
                                item.KYCDetails.Add(new Core.DTO.Identity.KYCData.UpdateKYCDetails { Id = item.Id, KycdocPath = filePath });
                            }
                        }
                        item.Kycdoc = null;
                    }
                    if (item.Proofdocument != null)
                    {
                        item.KYCDetails = new List<Core.DTO.Identity.KYCData.UpdateKYCDetails>();
                        foreach (var kycPic in item.Proofdocument)
                        {
                            if (kycPic.Length > 0)
                            {
                                string format = System.IO.Path.GetExtension(kycPic.FileName);
                                filename = profileId + "_Proofdocument_" + DateTime.Now + format;
                                string filenme = filename.Replace(":", ".");
                                var filePath = Path.Combine(pathToSave, filenme);
                                using var fileStream = new FileStream(filePath, FileMode.Create);
                                kycPic.CopyTo(fileStream);
                                item.KYCDetails.Add(new Core.DTO.Identity.KYCData.UpdateKYCDetails { Id = item.Id, KycdocPath = filePath });
                            }
                        }
                        item.Proofdocument = null;
                    }
                    if (item.Gstdocument != null)
                    {
                        item.GSTDetails = new List<Core.DTO.Identity.KYCData.UpdateGSTDetails>();

                        var gst = JsonConvert.DeserializeObject<Core.DTO.Identity.KYCData.UpdateGSTDetails>(item.GSTDetailString);
                        foreach (var kycPic in item.Gstdocument)
                        {
                            if (kycPic.Length > 0)
                            {
                                string format = System.IO.Path.GetExtension(kycPic.FileName);
                                filename = profileId + "_Gstdocument_" + DateTime.Now + format;
                                string filenme = filename.Replace(":", ".");
                                var filePath = Path.Combine(pathToSave, filenme);
                                using var fileStream = new FileStream(filePath, FileMode.Create);
                                kycPic.CopyTo(fileStream);
                                item.GSTDetails.Add(new Core.DTO.Identity.KYCData.UpdateGSTDetails
                                {
                                    Id=gst.Id,
                                    Address = gst.Address,
                                    BusinessName = gst.BusinessName,
                                    Gstcity = gst.Gstcity,
                                    Gstnumber = gst.Gstnumber,
                                    Gststate = gst.Gststate,
                                    Gstdocument = filePath
                                });
                            }
                        }
                        item.Gstdocument = null;
                    }
                }

                var client = httpClientFactory.CreateClient(IdentityServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.Identity + IdentityServiceOperation.UpdateKYCData(profileId), contentPost);
                return new APIResponse(response.StatusCode);

            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateUser()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Updates the kyc portion.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateKYCPortion(int profileId, UpdateKYCPortionRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(IdentityServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.Identity + IdentityServiceOperation.UpdateKYCPortion(profileId), contentPost);
                if (response.StatusCode == HttpStatusCode.NoContent)
                {

                }

                return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateKYCPortion()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
