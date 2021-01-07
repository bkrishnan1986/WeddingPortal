#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  21-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | SuggestionlistsController-- Controller.
//----------------------------------------------------------------------------------------------

#endregion File Header

using System.Net;
using System.Threading.Tasks;
using Happy.Weddings.Vendor.Core.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Happy.Weddings.Vendor.Core.DTO.Requests.SuggestionList;
using Happy.Weddings.Vendor.Service.Queries.v1.SuggesstionList;
using Happy.Weddings.Vendor.Core.DTO.Requests.SuggesstionList;
using Happy.Weddings.Vendor.Service.Commands.v1.SuggestionList;

namespace Happy.Weddings.Vendor.API.Controllers.v1
{
    /// <summary>
    /// Suggestionlists operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("suggestionlists")]
    [ApiController]
    public class SuggestionlistsController : Controller
    {
        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionsController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public SuggestionlistsController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Gets the Suggestionlists
        /// </summary>
        /// <param name="suggestionListsParameters">The Suggestionlists Parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetSuggestionLists([FromQuery] SuggestionListParameter suggestionListsParameters)
        {
            var getAllSuggestionListsQuery = new GetAllSuggestionListsQuery(suggestionListsParameters);
            var result = await mediator.Send(getAllSuggestionListsQuery);

            if (result.Code == HttpStatusCode.OK)
            {
                Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));
            }

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Get the Suggestion list
        /// </summary>
        /// <param name="suggestionlistId">The Suggestionlists identifier.</param>
        /// <returns></returns>
        [Route("{suggestionlistId}")]
        [HttpGet]
        public async Task<IActionResult> GetSuggestionList(int suggestionlistId)
        {
            var getSuggestionListQuery = new GetSuggestionListQuery(suggestionlistId);
            var result = await mediator.Send(getSuggestionListQuery);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Create the Suggestionlist
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateSuggestionList([FromBody] CreateSuggestionListRequest request)
        {
            var createSuggestionListCommand = new CreateSuggestionListCommand(request);
            var result = await mediator.Send(createSuggestionListCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Update the Suggestion list
        /// </summary>
        /// <param name="suggestionlistId">The Suggestionlist identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{suggestionlistId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateSuggestionList(int suggestionlistId, [FromBody] UpdateSuggestionListRequest request)
        {
            var updateSuggestionListCommand = new UpdateSuggestionListCommand(suggestionlistId, request);
            var result = await mediator.Send(updateSuggestionListCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Delete the Suggestion list
        /// </summary>
        /// <param name="suggestionlistId">The Suggestionlist identifier.</param>
        /// <returns></returns>
        [Route("{suggestionlistId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSuggestionList(int suggestionlistId)
        {
            var deleteSuggestionListCommand = new DeleteSuggestionListCommand(suggestionlistId);
            var result = await mediator.Send(deleteSuggestionListCommand);
            return StatusCode((int)result.Code, result.Value);
        }

    }
}