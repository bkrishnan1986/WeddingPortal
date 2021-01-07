using Happy.Weddings.Gateway.Core.DTO.Vendor.Service;
using Happy.Weddings.Gateway.Core.Services.v1.Vendor;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.API.Controllers.v1.Vendor
{
    /// <summary>
    /// Vendor Services operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v1/services")]
    [ApiController]
    public class ServicesController : Controller
    {
        /// <summary>
        /// The services service
        /// </summary>
        private readonly IServicesService servicesService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServicesController"/> class.
        /// </summary>
        /// <param name="servicesService">The services service.</param>
        public ServicesController(
            IServicesService servicesService)
        {
            this.servicesService = servicesService;
        }
        /// <summary>
        /// Add the Vendor Services.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddService([FromBody] AddServicesRequests request)
        {
            var result = await servicesService.AddService(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the service.
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("update/{serviceId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateService(int serviceId, [FromBody] UpdateServiceRequest request)
        {
            var result = await servicesService.UpdateService(serviceId,request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the service.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns></returns>
        [Route("delete/{serviceId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteService(int serviceId)
        {
            var result = await servicesService.DeleteService(serviceId);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <param name="serviceParameters">The service parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllServices([FromQuery] ServicesParameters serviceParameters)
        {
            var result = await servicesService.GetAllServices(serviceParameters);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        ///Search the Services.
        /// </summary>
        /// <param name="searchParameters">The search services parameters.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("SearchServices")]

        public async Task<IActionResult> SearchServices([FromQuery] SearchParameters searchParameters)
        {
            var result = await servicesService.SearchServices(searchParameters);
            return StatusCode((int)result.Code, result.Value);
        }


        /// <summary>
        /// Gets the services of vendor.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns></returns>
        [Route("vendor/{vendorId}")]
        [HttpGet]
        public async Task<IActionResult> GetServicesofVendor(string vendorId)
        {
            var result = await servicesService.GetServicesofVendor(vendorId);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the service offered by service identifier.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns></returns>
        [Route("{serviceId}")]
        [HttpGet]
        public async Task<IActionResult> GetServiceOfferedByServiceId(int serviceId)
        {
            var result = await servicesService.GetServiceOfferedByServiceId(serviceId);
            return StatusCode((int)result.Code, result.Value);
        }

    }
}
