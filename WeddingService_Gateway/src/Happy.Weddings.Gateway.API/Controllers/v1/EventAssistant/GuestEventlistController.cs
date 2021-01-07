using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.EventAssistant.Guesteventlist;
using Happy.Weddings.Gateway.Core.Services.v1.EventAssistant;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Gateway.API.Controllers.v1.EventAssistant
{
    /// <summary>
    /// Subscriptions operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("/api/v1/EventAssistant-management/guesteventlists")]
    [ApiController]
    public class GuestEventlistController : Controller
    {
        /// <summary>
        /// The checklist service
        /// </summary>
        private readonly IGuesteventlistService guesteventlistService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChecklistController"/> class.
        /// </summary>
        /// <param name="guesteventlistService">The checklist service.</param>
        public GuestEventlistController(
            IGuesteventlistService guesteventlistService)
        {
            this.guesteventlistService = guesteventlistService;
        }


        /// <summary>
        /// Gets the guesteventlists.
        /// </summary>
        /// <param name="guesteventlistParameters">The guesteventlist parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetGuesteventlists([FromQuery] GuesteventlistParameters guesteventlistParameters)
        {
            var result = await guesteventlistService.GetGuesteventlists(guesteventlistParameters);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the guesteventlist by identifier.
        /// </summary>
        /// <param name="guesteventlistId">The guesteventlist identifier.</param>
        /// <returns></returns>
        [Route("{guesteventlistId}")]
        [HttpGet]
        public async Task<IActionResult> GetGuesteventlistById(int guesteventlistId)
        {
            var result = await guesteventlistService.GetGuesteventlistById(guesteventlistId);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the guesteventlists.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateGuesteventlists([FromBody] CreateGuesteventlistRequest request)
        {
            var result = await guesteventlistService.CreateGuesteventlists(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the guesteventlists.
        /// </summary>
        /// <param name="guesteventlistId">The guesteventlist identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{guesteventlistId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateGuesteventlists(int guesteventlistId, [FromBody] UpdateGuesteventlistRequest request)
        {
            var result = await guesteventlistService.UpdateGuesteventlists(guesteventlistId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the guestlists.
        /// </summary>
        /// <param name="guesteventlistId">The guesteventlist identifier.</param>
        /// <returns></returns>
        [Route("{guesteventlistId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteGuestlists(int guesteventlistId)
        {
            var result = await guesteventlistService.DeleteGuesteventlists(guesteventlistId);
            return StatusCode((int)result.Code, result.Value);
        }

    }
}
