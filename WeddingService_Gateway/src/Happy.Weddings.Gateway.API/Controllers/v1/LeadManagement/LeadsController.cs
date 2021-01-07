using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.LeadManagement;
using Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead;
using Happy.Weddings.Gateway.Core.Services.v1.LeadManagement;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Gateway.API.Controllers.v1.LeadManagement
{
    /// <summary>
    /// LeadsController
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v1/lead-management/leads")]
    [ApiController]
    public class LeadsController : Controller
    {
        /// <summary>
        /// The lead service
        /// </summary>
        private readonly ILeadService leadService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LeadsController"/> class.
        /// </summary>
        /// <param name="leadService">The lead service.</param>
        public LeadsController(
            ILeadService leadService)
        {
            this.leadService = leadService;
        }

        #region Lead

        /// <summary>
        /// Gets the leads.
        /// </summary>
        /// <param name="leadParameters">The lead parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetLeads([FromQuery] LeadParameters leadParameters)
        {
            var result = await leadService.GetLeads(leadParameters);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the lead.
        /// </summary>
        /// <param name="leadId">The lead identifier.</param>
        /// <returns></returns>
        [Route("{leadId}")]
        [HttpGet]
        public async Task<IActionResult> GetLead(string leadId)
        {
            var result = await leadService.GetLead(leadId);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the leads By Vendor.
        /// </summary>
        /// <param name="leadsByVendorParameters">The lead By Vendor parameters.</param>
        /// <returns></returns>
        [Route("GetLeadsByVendor")]
        [HttpGet]
        public async Task<IActionResult> GetLeadsByVendor([FromQuery] LeadsByVendorParameters leadsByVendorParameters)
        {
            var result = await leadService.GetLeadsByVendor(leadsByVendorParameters);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the lead.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateLead([FromBody] CreateLeadDataCollectionRequest request)
        {
            var result = await leadService.CreateLead(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Update the lead.
        /// </summary>
        /// <param name="leadId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("{leadId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateLead(int leadId, [FromBody] UpdateLeadRequest request)
        {
            var result = await leadService.UpdateLead(leadId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates lead portion..
        /// </summary>
        /// <param name="leadDatacollectionId">The leadDatacollection identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{leadDatacollectionId}")]
        [HttpPatch]
        public async Task<IActionResult> UpdateLeadPortion(int leadDatacollectionId, [FromBody] UpdateLeadPortionRequest request)
        {
            var result = await leadService.UpdateLeadPortion(leadDatacollectionId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the lead.
        /// </summary>
        /// <param name="leadId">The lead identifier.</param>
        /// <returns></returns>
        [Route("{leadId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteLead(int leadId)
        {
            var result = await leadService.DeleteLead(leadId);
            return StatusCode((int)result.Code, result.Value);
        }

        #endregion

        #region FollowLead

        /// <summary>
        /// Creates the follow lead.
        /// </summary>
        /// <param name="leadId">The lead identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{leadId}/followlead")]
        public async Task<IActionResult> CreateFollowLead(int leadId, [FromBody] CreateLeadValidationRequest request)
        {
            var result = await leadService.CreateFollowLead(leadId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the follow lead.
        /// </summary>
        /// <param name="leadId">The lead identifier.</param>
        /// <param name="leadValidationId">The lead validation identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{leadId}/followlead/{leadValidationId}")]
        public async Task<IActionResult> UpdateFollowLead(int leadId,int leadValidationId, [FromBody] UpdateLeadValidationRequest request)
        {
            var result = await leadService.UpdateFollowLead(leadId,leadValidationId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        #endregion

        #region AssignLead

        /// <summary>
        /// Creates the assign lead.
        /// </summary>
        /// <param name="leadId">The lead identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{leadId}/assignlead")]
        public async Task<IActionResult> CreateAssignLead(int leadId, [FromBody] CreateLeadAssignRequest request)
        {
            var result = await leadService.CreateAssignLead(leadId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        #endregion

        #region LeadQuote

        /// <summary>
        /// Get lead quotes.
        /// </summary>
        /// <param name="leadId"></param>
        /// <param name="quoteParameters"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{leadId}/quote")]
        public async Task<IActionResult> GetLeadQuotes(int leadId, [FromQuery] LeadQuoteParameters quoteParameters)
        {
            var result = await leadService.GetLeadQuotes(leadId, quoteParameters);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates lead quote
        /// </summary>
        /// <param name="leadId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{leadId}/quote")]
        public async Task<IActionResult> CreateLeadQuote(int leadId, [FromBody] CreateLeadQuoteRequest request)
        {
            var result = await leadService.CreateLeadQuote(leadId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates lead quote.
        /// </summary>
        /// <param name="quoteId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{quoteId}/quote")]
        public async Task<IActionResult> UpdateLeadQuote(int quoteId, [FromBody] UpdateLeadQuoteRequest request)
        {
            var result = await leadService.UpdateLeadQuote(quoteId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Delete lead quote.
        /// </summary>
        /// <param name="quoteId"></param>
        /// <returns></returns>
        [Route("{quoteId}/quote")]
        [HttpDelete]
        public async Task<IActionResult> DeleteLeadQuote(int quoteId)
        {
            var result = await leadService.DeleteLeadQuote(quoteId);
            return StatusCode((int)result.Code, result.Value);
        }

        #endregion

        #region LeadStatus
        /// <summary>
        /// Gets the lead status.
        /// </summary>
        /// <param name="leadId">The lead identifier.</param>
        /// <param name="leadStatusParameters">The lead status parameters.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{leadId}/status")]
        public async Task<IActionResult> GetLeadStatus(int leadId, [FromQuery] LeadStatusParameter leadStatusParameters)
        {
            var result = await leadService.GetLeadStatus(leadId, leadStatusParameters);
            return StatusCode((int)result.Code, result.Value);
        }
        #endregion

        #region LeadCount
        /// <summary>
        /// GetLeadCount
        /// </summary>
        /// <param name="vendorId"></param>
        /// <param name="leadCountTotAmt"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{vendorId}/GetLeadCount")]
        public async Task<IActionResult> GetLeadCount(string vendorId, [FromQuery] LeadCountTotAmtParameter leadCountTotAmt)
        {
            var result = await leadService.GetLeadCount(vendorId, leadCountTotAmt);
            return StatusCode((int)result.Code, result.Value);
        }
        #endregion

        #region LeadTotalAmount
        /// <summary>
        /// GetLeadTotalAmount
        /// </summary>
        /// <param name="vendorId"></param>
        /// <param name="leadCountTotAmt"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{vendorId}/GetLeadTotalAmount")]
        public async Task<IActionResult> GetLeadTotalAmount(string vendorId, [FromQuery] LeadCountTotAmtParameter leadCountTotAmt)
        {
            var result = await leadService.GetLeadTotalAmount(vendorId, leadCountTotAmt);
            return StatusCode((int)result.Code, result.Value);
        }
        #endregion

        #region LeadId

        /// <summary>
        /// Gets the lead identifier.
        /// </summary>
        /// <param name="idParameters">The identifier parameters.</param>
        /// <returns></returns>
        [Route("leadId")]
        [HttpGet]
        public async Task<IActionResult> GetLeadId([FromQuery] LeadIdParameters idParameters)
        {
            var result = await leadService.GetLeadId(idParameters);
            return StatusCode((int)result.Code, result.Value);
        }

        #endregion
    }
}
