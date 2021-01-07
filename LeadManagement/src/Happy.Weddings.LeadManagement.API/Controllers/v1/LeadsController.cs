#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | LeadController class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Happy.Weddings.LeadManagement.Core.Domain;
using Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead;
using Happy.Weddings.LeadManagement.Service.Commands.v1.Lead;
using Happy.Weddings.LeadManagement.Service.Queries.v1.Lead;
using Newtonsoft.Json;

#endregion

namespace Happy.Weddings.LeadManagement.API.Controllers.v1
{
    /// <summary>
    /// LeadsController
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("leads")]
    [ApiController]
    public class LeadsController : Controller
    {
        #region Variables

        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        #endregion

        #region Constructor Overloading

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator"></param>
        public LeadsController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        #endregion

        #region Lead

        /// <summary>
        /// Gets the leads.
        /// </summary>
        /// <param name="leadParameters">The lead parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetLeads([FromQuery] LeadParameters leadParameters)
        {
            var getAlllLeadsQuery = new GetAllLeadsQuery(leadParameters);
            var result = await mediator.Send(getAlllLeadsQuery);

            if (result.Code == HttpStatusCode.OK)
            {
                Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));
            }

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
            var getLeadQuery = new GetLeadQuery(leadId);
            var result = await mediator.Send(getLeadQuery);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the leads by Vendor.
        /// </summary>
        /// <param name="leadsByVendorParameters">The lead By Vendor parameters.</param>
        /// <returns></returns>
        [Route("GetLeadsByVendor")]
        [HttpGet]
        public async Task<IActionResult> GetLeadsByVendor([FromQuery] LeadsByVendorParameters leadsByVendorParameters)
        {
            var getLeadByVendorQuery = new GetLeadsByVendorQuery(leadsByVendorParameters);

            var result = await mediator.Send(getLeadByVendorQuery);

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the lead.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateLead([FromBody] CreateLeadCollectionRequest request)
        {
            var createLeadCommand = new CreateLeadCommand(request);
            var result = await mediator.Send(createLeadCommand);
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
            var updateLeadCommand = new UpdateLeadCommand(leadId, request);
            var result = await mediator.Send(updateLeadCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the lead portion.
        /// </summary>
        /// <param name="leadId">The lead identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{leadId}")]
        [HttpPatch]
        public async Task<IActionResult> UpdateLeadPortion(int leadId, [FromBody] UpdateLeadPortionRequest request)
        {
            var updateLeadPortionCommand = new UpdateLeadPortionCommand(leadId, request);
            var result = await mediator.Send(updateLeadPortionCommand);
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
            var deleteLeadCommand = new DeleteLeadCommand(leadId);
            var result = await mediator.Send(deleteLeadCommand);
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
            var createFollowLeadCommand = new CreateLeadValidationCommand(leadId, request);
            var result = await mediator.Send(createFollowLeadCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the follow lead.
        /// </summary>
        /// <param name="leadValidationId">The lead validation identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{leadId}/followlead/{leadValidationId}")]
        public async Task<IActionResult> UpdateFollowLead(int leadValidationId, [FromBody] UpdateLeadValidationRequest request)
        {
            var updateFollowLeadCommand = new UpdateLeadValidationCommand(leadValidationId, request);
            var result = await mediator.Send(updateFollowLeadCommand);
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
            var createAssignLeadCommand = new CreateLeadAssignCommand(leadId, request);
            var result = await mediator.Send(createAssignLeadCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        #endregion

        #region LeadQuote

        /// <summary>
        /// Get lead quotes.
        /// </summary>
        /// <param name="leadId"></param>
        /// <param name="quoteParameters">The Lead Quote Parameter.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{leadId}/GetLeadQuotes")]
        public async Task<IActionResult> GetLeadQuotes(int leadId, [FromQuery] LeadQuoteParameters quoteParameters)
        {

            var getLeadQuotesQuery = new GetAllLeadQuotesQuery(quoteParameters, leadId);

            var result = await mediator.Send(getLeadQuotesQuery);

            if (result.Code == HttpStatusCode.OK) Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));

            return StatusCode((int)result.Code, result.Value);

        }

        /// <summary>
        /// creates lead quote against each vendor
        /// </summary>
        /// <param name="leadId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{leadId}/CreateLeadQuote")]
        public async Task<IActionResult> CreateLeadQuote(int leadId, [FromBody] CreateLeadQuoteRequest request)
        {
            var createLeadQuoteCommand = new CreateLeadQuoteCommand(leadId, request);
            var result = await mediator.Send(createLeadQuoteCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// updates lead quote.
        /// </summary>
        /// <param name="quoteId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{quoteId}/UpdateLeadQuote")]
        public async Task<IActionResult> UpdateLeadQuote(int quoteId, [FromBody] UpdateLeadQuoteRequest request)
        {
            var updateLeadQuoteCommand = new UpdateLeadQuoteCommand(quoteId, request);
            var result = await mediator.Send(updateLeadQuoteCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Delete lead quote.
        /// </summary>
        /// <param name="quoteId"></param>
        /// <returns></returns>
        [Route("{quoteId}/DeleteLeadQuote")]
        [HttpDelete]
        public async Task<IActionResult> DeleteLeadQuote(int quoteId)
        {
            var deleteLeadQuoteCommand = new DeleteLeadQuoteCommand(quoteId);
            var result = await mediator.Send(deleteLeadQuoteCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        #endregion

        #region LeadStatus

        /// <summary>
        /// GetLeadStatus
        /// </summary>
        /// <param name="leadId"></param>
        /// <param name="leadStatusParameter"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{leadId}/GetLeadStatus")]
        public async Task<IActionResult> GetLeadStatus(int leadId, [FromQuery] LeadStatusParameter leadStatusParameter)
        {

            var getLeadStatusQuery = new GetAllLeadStatusQuery(leadStatusParameter, leadId);

            var result = await mediator.Send(getLeadStatusQuery);

            if (result.Code == HttpStatusCode.OK) Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));

            return StatusCode((int)result.Code, result.Value);

        }
        #endregion

        #region LeadCount

        /// <summary>
        /// Gets the lead count.
        /// </summary>
        /// <param name="vendorId">The lead identifier.</param>
        /// <param name="leadCountParameter">The lead count parameter.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{vendorId}/GetLeadCount")]
        public async Task<IActionResult> GetLeadCount(string vendorId, [FromQuery] LeadCountTotAmtParameter leadCountParameter)
        {

            var getLeadCountQuery = new GetAllLeadCountQuery(leadCountParameter, vendorId);

            var result = await mediator.Send(getLeadCountQuery);         

            return StatusCode((int)result.Code, result.Value);


        }
        #endregion

        #region LeadTotalAmount

        /// <summary>
        /// Gets the lead count.
        /// </summary>
        /// <param name="vendorId">The lead identifier.</param>
        /// <param name="leadCountParameter">The lead count parameter.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{vendorId}/GetLeadTotalAmount")]
        public async Task<IActionResult> GetLeadTotalAmount(string vendorId, [FromQuery] LeadCountTotAmtParameter leadCountParameter)
        {

            var getLeadTotalAmountQuery = new GetAllLeadTotalAmountQuery(leadCountParameter, vendorId);

            var result = await mediator.Send(getLeadTotalAmountQuery);

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
            var getLeadIdQuery = new GetLeadIdQuery(idParameters);
            var result = await mediator.Send(getLeadIdQuery);
            return StatusCode((int)result.Code, result.Value);
        }

        #endregion
    }
}
