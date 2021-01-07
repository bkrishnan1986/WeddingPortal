using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.Vendor.SuggestionList;
using Happy.Weddings.Gateway.Core.Services.v1.Vendor;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Gateway.API.Controllers.v1.Vendor
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
        /// The suggestionlist service
        /// </summary>
        private readonly ISuggestionListService suggestionlistService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SuggestionlistsController"/> class.
        /// </summary>
        /// <param name="suggestionlistService">The suggestionlist service.</param>
        public SuggestionlistsController(
            ISuggestionListService suggestionlistService)
        {
            this.suggestionlistService = suggestionlistService;
        }

        /// <summary>
        /// Gets the Suggestionlists
        /// </summary>
        /// <param name="suggestionListsParameters">The Suggestionlists Parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetSuggestionLists([FromQuery] SuggestionListParameter suggestionListsParameters)
        {
            var result = await suggestionlistService.GetSuggestionLists(suggestionListsParameters);
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
            var result = await suggestionlistService.GetSuggestionList(suggestionlistId);
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
            var result = await suggestionlistService.CreateSuggestionList(request);
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
            var result = await suggestionlistService.UpdateSuggestionList(suggestionlistId,request);
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
            var result = await suggestionlistService.DeleteSuggestionList(suggestionlistId);
            return StatusCode((int)result.Code, result.Value);
        }

    }
}
