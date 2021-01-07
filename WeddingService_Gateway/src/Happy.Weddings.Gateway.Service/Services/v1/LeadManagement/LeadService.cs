using Happy.Weddings.Gateway.Core.Config.LeadManagement;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.LeadManagement;
using Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead;
using Happy.Weddings.Gateway.Core.Infrastructure;
using Happy.Weddings.Gateway.Core.Services.v1.LeadManagement;
using Happy.Weddings.Gateway.Service.Helpers;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Service.Services.v1.LeadManagement
{
    public class LeadService : ILeadService
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
        /// Initializes a new instance of the <see cref="LeadService"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="distributedCache">The distributed cache.</param>
        /// <param name="servicesConfig">The services configuration.</param>
        /// <param name="logger">The logger.</param>
        public LeadService(
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


        #region Lead

        /// <summary>
        /// Gets the leads.
        /// </summary>
        /// <param name="leadParameters">The lead parameters.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<APIResponse> GetLeads(LeadParameters leadParameters)
        {
            try
            {
                var client = httpClientFactory.CreateClient(LeadServiceOperation.serviceName);

                UriBuilder url = new UriBuilder(servicesConfig.Lead + LeadServiceOperation.GetLeads());

                url.Query = QueryStringHelper.ConvertToQueryString(leadParameters);

                var response = await client.GetAsync(url.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var leads = JsonConvert.DeserializeObject<List<LeadDataCollectionResponse>>(await response.Content.ReadAsStringAsync());

                    return new APIResponse(leads, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetLeads()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }

        }

        /// <summary>
        /// Gets the lead by Id.
        /// </summary>
        /// <param name="leadId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<APIResponse> GetLead(string leadId)
        {
            try
            {
                var client = httpClientFactory.CreateClient(LeadServiceOperation.serviceName);

                var response = await client.GetAsync(servicesConfig.Lead + LeadServiceOperation.GetLead(leadId));

                if (response.IsSuccessStatusCode)
                {
                    var lead = JsonConvert.DeserializeObject<LeadsResponseDetails>(await response.Content.ReadAsStringAsync());

                    return new APIResponse(lead, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetLead()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }

        }

        /// <summary>
        /// Gets the lead By Vendor.
        /// </summary>
        /// <param name="leadsByVendorParameters">The lead By Vendor parameters.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<APIResponse> GetLeadsByVendor(LeadsByVendorParameters leadsByVendorParameters)
        {
            try
            {
                var client = httpClientFactory.CreateClient(LeadServiceOperation.serviceName);

                UriBuilder url = new UriBuilder(servicesConfig.Lead + LeadServiceOperation.GetLeadsByVendor());

                url.Query = QueryStringHelper.ConvertToQueryString(leadsByVendorParameters);

                var response = await client.GetAsync(url.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var leads = JsonConvert.DeserializeObject<List<LeadAssignDetailResponse>>(await response.Content.ReadAsStringAsync());

                    return new APIResponse(leads, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetLeadsByVendor()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }

        }

        /// <summary>
        /// Creates the lead.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> CreateLead(CreateLeadDataCollectionRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(LeadServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);

                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.Lead + LeadServiceOperation.CreateLead(), contentPost);

                //return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());

                if (response.IsSuccessStatusCode)
                {
                    //var leadDataCollection = JsonConvert.DeserializeObject<LeadDataCollectionResponse>(await response.Content.ReadAsStringAsync());

                    //return new APIResponse(leadDataCollection, HttpStatusCode.Created);
                    var leadDataCollection = JsonConvert.DeserializeObject<LeadIdDetails>(await response.Content.ReadAsStringAsync());

                    return new APIResponse(leadDataCollection, HttpStatusCode.Created);
                }

                return new APIResponse(response.StatusCode);

            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateLead()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Update the lead.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateLead(int leadId, UpdateLeadRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(LeadServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);

                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.Lead + LeadServiceOperation.UpdateLead(leadId), contentPost);

                return new APIResponse(response.StatusCode);

            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateLead()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Updates the lead portion.
        /// </summary>
        /// <param name="leadDatacollectionId">The leadDatacollection identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateLeadPortion(int leadDatacollectionId, UpdateLeadPortionRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(LeadServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);

                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PatchAsync(servicesConfig.Lead + LeadServiceOperation.UpdateLeadPortion(leadDatacollectionId), contentPost);

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateLeadPortion()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Delete lead
        /// </summary>
        /// <param name="leadId"></param>
        /// <returns></returns>
        public async Task<APIResponse> DeleteLead(int leadId)
        {
            try
            {
                var client = httpClientFactory.CreateClient(LeadServiceOperation.serviceName);

                var response = await client.DeleteAsync(servicesConfig.Lead + LeadServiceOperation.DeleteLead(leadId));

                //return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteLead()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        #endregion

        #region FollowLead

        /// <summary>
        /// Creates the follow lead.
        /// </summary>
        /// <param name="leadId">The lead identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> CreateFollowLead(int leadId, CreateLeadValidationRequest request)
        {
            try
            {

                string filename = "";
                var folderName = Path.Combine("CallRecordings");
                var pathToSave = Path.Combine("D:", "HappyWedding", folderName);

                if (request.CallRecordingFile != null)
                {

                    if (request.CallRecordingFile.Length > 0)
                    {
                        string format = Path.GetExtension(request.CallRecordingFile.FileName);
                        filename = leadId + "_CallRecord_" + DateTime.Now + format;
                        string filenme = filename.Replace(":", ".");
                        var filePath = Path.Combine(pathToSave, filenme);
                        using var fileStream = new FileStream(filePath, FileMode.Create);
                        request.CallRecordingFile.CopyTo(fileStream);
                    }
                }
                request.CallRecordingFile = null;

                request.CallRecordings = filename;

                var client = httpClientFactory.CreateClient(LeadServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);

                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.Lead + LeadServiceOperation.CreateFollowLead(leadId), contentPost);

                //return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());

                if (response.IsSuccessStatusCode)
                {
                    var leadValidation = JsonConvert.DeserializeObject<LeadValidationResponse>(await response.Content.ReadAsStringAsync());

                    return new APIResponse(leadValidation, HttpStatusCode.Created);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateFollowLead()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Updates the follow lead.
        /// </summary>
        /// <param name="leadValidationId">The lead validation identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateFollowLead(int leadId, int leadValidationId, UpdateLeadValidationRequest request)
        {
            try
            {
                string filename = "";
                var folderName = Path.Combine("CallRecordings");
                var pathToSave = Path.Combine("D:", "HappyWedding", folderName);

                if (request.CallRecordingFile != null)
                {

                    if (request.CallRecordingFile.Length > 0)
                    {
                        string format = Path.GetExtension(request.CallRecordingFile.FileName);
                        filename = leadId + "_CallRecord_" + DateTime.Now + format;
                        string filenme = filename.Replace(":", ".");
                        var filePath = Path.Combine(pathToSave, filenme);
                        using var fileStream = new FileStream(filePath, FileMode.Create);
                        request.CallRecordingFile.CopyTo(fileStream);
                    }
                }
                request.CallRecordingFile = null;

                request.CallRecordings = filename;

                var client = httpClientFactory.CreateClient(LeadServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);

                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.Lead + LeadServiceOperation.UpdateFollowLead(leadId, leadValidationId), contentPost);

                return new APIResponse(response.StatusCode);

            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateFollowLead()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        #endregion

        #region AssignLead

        /// <summary>
        /// Creates the assign lead.
        /// </summary>
        /// <param name="leadId">The lead identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> CreateAssignLead(int leadId, CreateLeadAssignRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(LeadServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);

                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.Lead + LeadServiceOperation.CreateAssignLead(leadId), contentPost);

                //return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());

                if (response.IsSuccessStatusCode)
                {
                    var leadAssign = JsonConvert.DeserializeObject<LeadAssignResponse>(await response.Content.ReadAsStringAsync());

                    return new APIResponse(leadAssign, HttpStatusCode.Created);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateLead()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        #endregion

        #region LeadQuote

        public async Task<APIResponse> GetLeadQuotes(int leadId, LeadQuoteParameters quoteParameters)
        {
            try
            {
                var client = httpClientFactory.CreateClient(LeadServiceOperation.serviceName);

                UriBuilder url = new UriBuilder(servicesConfig.Lead + LeadServiceOperation.GetLeadQuotes(leadId));

                url.Query = QueryStringHelper.ConvertToQueryString(quoteParameters);

                var response = await client.GetAsync(url.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var leadQuote = JsonConvert.DeserializeObject<List<LeadQuoteResponse>>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(leadQuote, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetLeadQuotes()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Creates the lead quote.
        /// </summary>
        /// <param name="leadId">The lead identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> CreateLeadQuote(int leadId, CreateLeadQuoteRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(LeadServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);

                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(servicesConfig.Lead + LeadServiceOperation.CreateLeadQuote(leadId), contentPost);

                //return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());

                if (response.IsSuccessStatusCode)
                {
                    var leadQuote = JsonConvert.DeserializeObject<LeadQuoteResponse>(await response.Content.ReadAsStringAsync());

                    return new APIResponse(leadQuote, HttpStatusCode.Created);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateLeadQuote()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Updates the lead quote.
        /// </summary>
        /// <param name="quoteId">The quote identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public async Task<APIResponse> UpdateLeadQuote(int quoteId, UpdateLeadQuoteRequest request)
        {
            try
            {
                var client = httpClientFactory.CreateClient(LeadServiceOperation.serviceName);

                var param = JsonConvert.SerializeObject(request);

                HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(servicesConfig.Lead + LeadServiceOperation.UpdateLeadQuote(quoteId), contentPost);

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateLeadQuote()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Deletes the lead quote.
        /// </summary>
        /// <param name="quoteId">The quote identifier.</param>
        /// <returns></returns>
        public async Task<APIResponse> DeleteLeadQuote(int quoteId)
        {
            try
            {
                var client = httpClientFactory.CreateClient(LeadServiceOperation.serviceName);

                var response = await client.DeleteAsync(servicesConfig.Lead + LeadServiceOperation.DeleteLeadQuote(quoteId));

                //return JsonConvert.DeserializeObject<APIResponse>(await response.Content.ReadAsStringAsync());
                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteLeadQuote()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        #endregion

        #region LeadStatus

        public async Task<APIResponse> GetLeadStatus(int leadId, LeadStatusParameter leadStatusParameter)
        {
            try
            {
                var client = httpClientFactory.CreateClient(LeadServiceOperation.serviceName);

                UriBuilder url = new UriBuilder(servicesConfig.Lead + LeadServiceOperation.GetLeadStatus(leadId));

                url.Query = QueryStringHelper.ConvertToQueryString(leadStatusParameter);

                var response = await client.GetAsync(url.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var leadStatus = JsonConvert.DeserializeObject<List<LeadStatusResponse>>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(leadStatus, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetLeadStatus()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
        #endregion

        #region LeadCount

        public async Task<APIResponse> GetLeadCount(string vendorId, LeadCountTotAmtParameter leadCountTotAmt)
        {
            try
            {
                var client = httpClientFactory.CreateClient(LeadServiceOperation.serviceName);

                UriBuilder url = new UriBuilder(servicesConfig.Lead + LeadServiceOperation.GetLeadCount(vendorId));

                url.Query = QueryStringHelper.ConvertToQueryString(leadCountTotAmt);

                var response = await client.GetAsync(url.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var leadStatus = JsonConvert.DeserializeObject<LeadCountResponse>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(leadStatus, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetLeadCount()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
        #endregion

        #region LeadTotalAmount

        public async Task<APIResponse> GetLeadTotalAmount(string vendorId, LeadCountTotAmtParameter leadCountTotAmt)
        {
            try
            {
                var client = httpClientFactory.CreateClient(LeadServiceOperation.serviceName);

                UriBuilder url = new UriBuilder(servicesConfig.Lead + LeadServiceOperation.GetLeadTotalAmount(vendorId));

                url.Query = QueryStringHelper.ConvertToQueryString(leadCountTotAmt);

                var response = await client.GetAsync(url.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var leadStatus = JsonConvert.DeserializeObject<LeadTotalAmtResponse>(await response.Content.ReadAsStringAsync());
                    return new APIResponse(leadStatus, HttpStatusCode.OK);
                }

                return new APIResponse(response.StatusCode);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetLeadTotalAmount()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
        #endregion

        #region LeadId

        /// <summary>
        /// Gets the lead identifier.
        /// </summary>
        /// <param name="idParameters">The identifier parameters.</param>
        /// <returns></returns>
        public async Task<APIResponse> GetLeadId(LeadIdParameters idParameters)
        {
            try
            {
                var client = httpClientFactory.CreateClient(LeadServiceOperation.serviceName);

                UriBuilder url = new UriBuilder(servicesConfig.Vendor + LeadServiceOperation.GetLeadId());
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
                logger.Error(ex, "Exception in method 'GetLeadId()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        #endregion
    }
}
