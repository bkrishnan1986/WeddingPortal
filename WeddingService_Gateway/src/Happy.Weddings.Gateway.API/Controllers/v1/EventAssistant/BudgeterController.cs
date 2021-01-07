using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.EventAssistant.Budgeter;
using Happy.Weddings.Gateway.Core.Services.v1.EventAssistant;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Gateway.API.Controllers.v1.EventAssistant
{
    /// <summary>
    /// Subscriptions operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("/api/v1/EventAssistant-management/budgeter")]
    [ApiController]
    public class BudgeterController : Controller
    {
        /// <summary>
        /// The budgeter service
        /// </summary>
        private readonly IBudgeterService budgeterService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BudgeterController"/> class.
        /// </summary>
        /// <param name="budgeterService">The budgeter service.</param>
        public BudgeterController(
            IBudgeterService budgeterService)
        {
            this.budgeterService = budgeterService;
        }

        /// <summary>
        /// Gets the budgeters.
        /// </summary>
        /// <param name="budgeterParameters">The budgeter parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetBudgeters([FromQuery] BudgeterParameters budgeterParameters)
        {
            var result = await budgeterService.GetBudgeters(budgeterParameters);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the budgeter by identifier.
        /// </summary>
        /// <param name="budgeterId">The budgeter identifier.</param>
        /// <returns></returns>
        [Route("{budgeterId}")]
        [HttpGet]
        public async Task<IActionResult> GetBudgeterById(int budgeterId)
        {
            var result = await budgeterService.GetBudgeterById(budgeterId);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the budgeters.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateBudgeters([FromBody] CreateBudgeterRequest request)
        {
            var result = await budgeterService.CreateBudgeters(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the budgeters.
        /// </summary>
        /// <param name="budgeterId">The budgeter identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{budgeterId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateBudgeters(int budgeterId, [FromBody] UpdateBudgeterRequest request)
        {
            var result = await budgeterService.UpdateBudgeters(budgeterId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the budgeters.
        /// </summary>
        /// <param name="budgeterId">The budgeter identifier.</param>
        /// <returns></returns>
        [Route("{budgeterId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteBudgeters(int budgeterId)
        {
            var result = await budgeterService.DeleteBudgeters(budgeterId);
            return StatusCode((int)result.Code, result.Value);
        }

    }
}
