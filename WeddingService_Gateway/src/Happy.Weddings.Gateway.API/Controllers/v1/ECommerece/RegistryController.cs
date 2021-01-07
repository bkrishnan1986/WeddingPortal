using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.ECommerce.Registry;
using Happy.Weddings.Gateway.Core.Services.v1.ECommerce;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Gateway.API.Controllers.v1.ECommerce
{
    /// <summary>
    /// OrderreturnController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("/api/v1/E-Commerce-Management/registry")]
    [ApiController]
    public class RegistryController : Controller
    {

        private readonly IRegistryService registryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderreturnController"/> class.
        /// </summary>
        /// <param name="registryService">The orderreturn service.</param>
        public RegistryController(
            IRegistryService registryService)
        {
            this.registryService = registryService;
        }

        /// <summary>
        /// Gets the registrys.
        /// </summary>
        /// <param name="registryParameters">The registry parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetRegistrys([FromQuery] RegistryParameters registryParameters)
        {
            var result = await registryService.GetRegistrys(registryParameters);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the registry by identifier.
        /// </summary>
        /// <param name="registryId">The registry identifier.</param>
        /// <returns></returns>
        [Route("{registryId}")]
        [HttpGet]
        public async Task<IActionResult> GetRegistryById(int registryId)
        {
            var result = await registryService.GetRegistryById(registryId);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the registrys.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateRegistrys([FromBody] CreateRegistryRequest request)
        {
            var result = await registryService.CreateRegistrys(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the registrys.
        /// </summary>
        /// <param name="registryId">The registry identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{registryId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateRegistrys(int registryId, [FromBody] UpdateRegistryRequest request)
        {
            var result = await registryService.UpdateRegistrys(registryId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the orderreturns.
        /// </summary>
        /// <param name="registryId">The registry identifier.</param>
        /// <returns></returns>
        [Route("{registryId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteOrderreturns(int registryId)
        {
            var result = await registryService.DeleteRegistrys(registryId);
            return StatusCode((int)result.Code, result.Value);
        }

    }
}
