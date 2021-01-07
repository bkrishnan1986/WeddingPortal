using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.Vendor.ServiceTopup;
using Happy.Weddings.Gateway.Core.Services.v1.Vendor;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Gateway.API.Controllers.v1.Vendor
{
    /// <summary>
    /// ServiceTopup operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v1/vendor/servicetopup")]
    [ApiController]
    public class ServiceTopupsController : Controller
    {
        /// <summary>
        /// The service topup service
        /// </summary>
        private readonly IServiceTopupService serviceTopupService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceTopupsController"/> class.
        /// </summary>
        /// <param name="serviceTopupService">The service topup service.</param>
        public ServiceTopupsController(
            IServiceTopupService serviceTopupService)
        {
            this.serviceTopupService = serviceTopupService;
        }

        /// <summary>
        /// Gets the ServiceTopup
        /// </summary>
        /// <param name="serviceTopupParameter">The ServiceTopup  Parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetServiceTopups([FromQuery] ServiceTopupParameter serviceTopupParameter)
        {
            var result = await serviceTopupService.GetServiceTopups(serviceTopupParameter);
            return StatusCode((int)result.Code, result.Value);
        }
        /// <summary>
        /// Get the ServiceTopup
        /// </summary>
        /// <param name="servicetopupId">The ServiceTopupidentifier.</param>
        /// <returns></returns>
        [Route("{servicetopupId}")]
        [HttpGet]
        public async Task<IActionResult> GetServiceTopupById(int servicetopupId)
        {
            var result = await serviceTopupService.GetServiceTopupById(servicetopupId);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Create the ServiceTopup
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateServiceTopup([FromBody] CreateServiceTopupRequest request)
        {
            var result = await serviceTopupService.CreateServiceTopup(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Update the ServiceTopup
        /// </summary>
        /// <param name="servicesubscriptionId">The ServiceTopup identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{servicetopupId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateServiceTopup(int servicesubscriptionId, [FromBody] UpdateServiceTopupRequest request)
        {
            var result = await serviceTopupService.UpdateServiceTopup(servicesubscriptionId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Delete the ServiceTopup
        /// </summary>
        /// <param name="servicetopupId">The ServiceTopup identifier.</param>
        /// <returns></returns>
        [Route("{servicetopupId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteServiceTopup(int servicetopupId)
        {
            var result = await serviceTopupService.DeleteServiceTopup(servicetopupId);
            return StatusCode((int)result.Code, result.Value);
        }

    }
}
