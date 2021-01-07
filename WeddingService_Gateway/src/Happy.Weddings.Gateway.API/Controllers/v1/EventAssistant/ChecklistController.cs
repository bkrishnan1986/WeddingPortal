using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.EventAssistant.Checklist;
using Happy.Weddings.Gateway.Core.Services.v1.EventAssistant;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Gateway.API.Controllers.v1.EventAssistant
{
    /// <summary>
    /// Subscriptions operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("/api/v1/EventAssistant-management/checklist")]
    [ApiController]
    public class ChecklistController : Controller
    {
        /// <summary>
        /// The checklist service
        /// </summary>
        private readonly IChecklistService checklistService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChecklistController"/> class.
        /// </summary>
        /// <param name="checklistService">The checklist service.</param>
        public ChecklistController(
            IChecklistService checklistService)
        {
            this.checklistService = checklistService;
        }

        /// <summary>
        /// Gets the checklists.
        /// </summary>
        /// <param name="checklistParameters">The checklist parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetChecklists([FromQuery] ChecklistParameters checklistParameters)
        {
            var result = await checklistService.GetChecklists(checklistParameters);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the checklist by identifier.
        /// </summary>
        /// <param name="checklistId">The checklist identifier.</param>
        /// <returns></returns>
        [Route("{checklistId}")]
        [HttpGet]
        public async Task<IActionResult> GetChecklistById(int checklistId)
        {
            var result = await checklistService.GetChecklistById(checklistId);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the checklists.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateChecklists([FromBody] CreateChecklistRequest request)
        {
            var result = await checklistService.CreateChecklists(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the checklists.
        /// </summary>
        /// <param name="checklistId">The checklist identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{checklistId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateChecklists(int checklistId, [FromBody] UpdateChecklistRequest request)
        {
            var result = await checklistService.UpdateChecklists(checklistId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the checklists.
        /// </summary>
        /// <param name="checklistId">The checklist identifier.</param>
        /// <returns></returns>
        [Route("{checklistId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteChecklists(int checklistId)
        {
            var result = await checklistService.DeleteChecklists(checklistId);
            return StatusCode((int)result.Code, result.Value);
        }

    }
}
