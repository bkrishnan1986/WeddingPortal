using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.EventAssistant.Guestlist;
using Happy.Weddings.Gateway.Core.Services.v1.EventAssistant;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Gateway.API.Controllers.v1.EventAssistant
{
    /// <summary>
    /// Subscriptions operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("/api/v1/EventAssistant-management/guestlists")]
    [ApiController]
    public class GuestlistController : Controller
    {
        /// <summary>
        /// The checklist service
        /// </summary>
        private readonly IGuestlistService guestlistService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChecklistController"/> class.
        /// </summary>
        /// <param name="guestlistService">The checklist service.</param>
        public GuestlistController(
            IGuestlistService guestlistService)
        {
            this.guestlistService = guestlistService;
        }

        /// <summary>
        /// Gets the guestlists.
        /// </summary>
        /// <param name="guestlistParameters">The guestlist Parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetGuestlists([FromQuery] GuestlistParameters guestlistParameters)
        {
            var result = await guestlistService.GetGuestlists(guestlistParameters);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the guestlist by identifier.
        /// </summary>
        /// <param name="guestlistId">The checklist identifier.</param>
        /// <returns></returns>
        [Route("{guestlistId}")]
        [HttpGet]
        public async Task<IActionResult> GetGuestlistById(int guestlistId)
        {
            var result = await guestlistService.GetGuestlistById(guestlistId);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the guestlists.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateGuestlists([FromBody] CreateGuestlistRequest request)
        {
            var result = await guestlistService.CreateGuestlists(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the guestlists.
        /// </summary>
        /// <param name="guestlistId">The checklist identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{guestlistId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateGuestlists(int guestlistId, [FromBody] UpdateGuestlistRequest request)
        {
            var result = await guestlistService.UpdateGuestlists(guestlistId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the guestlists.
        /// </summary>
        /// <param name="guestlistId">The checklist identifier.</param>
        /// <returns></returns>
        [Route("{guestlistId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteGuestlists(int guestlistId)
        {
            var result = await guestlistService.DeleteGuestlists(guestlistId);
            return StatusCode((int)result.Code, result.Value);
        }

    }
}
